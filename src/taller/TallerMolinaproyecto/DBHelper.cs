using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TallerMolinaproyecto
{
    public static class DBHelper
    {
        // ==========================================================
        // OBTENER CONEXIÓN SEGÚN MOTOR
        // ==========================================================
        public static IDbConnection GetConnection()
        {
            if (AppState.IsMySql)
            {
                if (string.IsNullOrWhiteSpace(AppState.MySqlConnectionString))
                    throw new InvalidOperationException("La cadena de conexión MySQL no está inicializada.");

                return new MySqlConnection(AppState.MySqlConnectionString);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(AppState.SqlServerConnectionString))
                    throw new InvalidOperationException("La cadena de conexión SQL Server no está inicializada.");

                return new SqlConnection(AppState.SqlServerConnectionString);
            }
        }

        // ==========================================================
        // PARÁMETROS
        // ==========================================================
        public static IDataParameter P(string name, object value)
        {
            return AppState.IsMySql
                ? new MySqlParameter(name, value ?? DBNull.Value)
                : new SqlParameter(name, value ?? DBNull.Value);
        }

        // ==========================================================
        // CONSULTAS SELECT
        // ==========================================================
        public static DataTable Query(string sql, params IDataParameter[] ps)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (ps != null)
                foreach (var p in ps) cmd.Parameters.Add(p);
            var dt = new DataTable();
            if (AppState.IsMySql)
            {
                using var da = new MySqlDataAdapter((MySqlCommand)cmd);
                da.Fill(dt);
            }
            else
            {
                using var da = new SqlDataAdapter((SqlCommand)cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // ==========================================================
        // INSERT / UPDATE / DELETE
        // ==========================================================
        public static int ExecNonQuery(string sql, params IDataParameter[] ps)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (ps != null)
                foreach (var p in ps) cmd.Parameters.Add(p);
            return cmd.ExecuteNonQuery();
        }

        // ==========================================================
        // ESCALARES (COUNT, MAX, etc.)
        // ==========================================================
        public static object ExecScalar(string sql, params IDataParameter[] ps)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (ps != null)
                foreach (var p in ps) cmd.Parameters.Add(p);
            return cmd.ExecuteScalar();
        }

        // ==========================================================
        // REGISTRO EN BITÁCORA
        // ==========================================================
        public static void RegistrarBitacora(string usuario, string accion)
        {
            try
            {
                // Si no te mandan usuario, usamos el de la sesión actual
                string user = !string.IsNullOrWhiteSpace(usuario)
                    ? usuario
                    : (AppState.UsuarioNombre ?? "Desconocido");

                string sql = AppState.IsMySql
                    ? @"INSERT INTO BITACORA(Usuario,Accion,FechaHora)
                        VALUES (@u,@a,NOW());"
                    : @"INSERT INTO BITACORA(Usuario,Accion,FechaHora)
                        VALUES (@u,@a,GETDATE());";

                ExecNonQuery(sql,
                    P("@u", user),
                    P("@a", accion ?? ""));
            }
            catch
            {
                // IMPORTANTE: si hay error en bitácora, NO reventar el programa.
                // Lo ignoramos silenciosamente.
            }
        }

        public static (int facturaId, string codigoFactura) CrearFacturaPago(int empleadoId, string codigo)
        {
            int clientePagoId;

            if (AppState.IsMySql)
            {
                var obj = ExecScalar("SELECT ClienteID FROM CLIENTES WHERE Nombre='PAGO' LIMIT 1;");
                if (obj == null)
                {
                    ExecNonQuery("INSERT INTO CLIENTES (Nombre, FechaRegistro) VALUES ('PAGO', NOW());");
                    obj = ExecScalar("SELECT ClienteID FROM CLIENTES WHERE Nombre='PAGO' LIMIT 1;");
                }
                clientePagoId = Convert.ToInt32(obj);

                ExecNonQuery(@"
                    INSERT INTO FACTURAS (ClienteID, EmpleadoID, Fecha, Total, Codigo, TipoFactura)
                    VALUES (@cli,@emp,NOW(),0,@cod,'PAGO');",
                    P("@cli", clientePagoId),
                    P("@emp", empleadoId),
                    P("@cod", codigo));

                var id = ExecScalar("SELECT LAST_INSERT_ID();");
                return (Convert.ToInt32(id), codigo);
            }
            else
            {
                var obj = ExecScalar("SELECT TOP 1 ClienteID FROM CLIENTES WHERE Nombre='PAGO';");
                if (obj == null)
                {
                    ExecNonQuery("INSERT INTO CLIENTES (Nombre, FechaRegistro) VALUES ('PAGO', GETDATE());");
                    obj = ExecScalar("SELECT TOP 1 ClienteID FROM CLIENTES WHERE Nombre='PAGO';");
                }
                clientePagoId = Convert.ToInt32(obj);

                var idObj = ExecScalar(@"
                    INSERT INTO FACTURAS (ClienteID, EmpleadoID, Fecha, Total, Codigo, TipoFactura)
                    OUTPUT INSERTED.FacturaID
                    VALUES (@cli,@emp,GETDATE(),0,@cod,'PAGO');",
                    P("@cli", clientePagoId),
                    P("@emp", empleadoId),
                    P("@cod", codigo));

                return (Convert.ToInt32(idObj), codigo);
            }
        }




        // ==========================================================
        // USUARIO DESARROLLADOR AUTO
        // ==========================================================
        public static void VerificarUsuarioDesarrollador()
        {
            try
            {
                // Crear rol Administrador si no existe
                string checkRol = AppState.IsSqlServer
                    ? @"IF NOT EXISTS (SELECT 1 FROM ROLES WHERE Nombre='Administrador')
                        INSERT INTO ROLES (Nombre,Descripcion) VALUES ('Administrador','Acceso total');"
                    : @"INSERT INTO ROLES (Nombre,Descripcion)
                        SELECT 'Administrador','Acceso total'
                        WHERE NOT EXISTS (SELECT 1 FROM ROLES WHERE Nombre='Administrador');";

                ExecNonQuery(checkRol);

                // Crear usuario admin si no existe
                string exists = Convert.ToString(ExecScalar("SELECT COUNT(*) FROM EMPLEADOS WHERE Usuario='admin'"));
                if (exists == "0")
                {
                    string sqlInsert = AppState.IsSqlServer
                        ? @"
                            DECLARE @rol INT = (SELECT TOP 1 RolID FROM ROLES WHERE Nombre='Administrador');
                            INSERT INTO EMPLEADOS (Nombre,Telefono,Correo,RolID,Usuario,ContrasenaHash,Area,Activo)
                            VALUES ('Desarrollador','0000','dev@sys.com',@rol,'admin',
                            LOWER(CONVERT(VARCHAR(64),HASHBYTES('SHA2_256','2006'),2)),'Administración',1);
                          "
                        : @"
                            INSERT INTO EMPLEADOS (Nombre,Telefono,Correo,RolID,Usuario,ContrasenaHash,Area,Activo)
                            VALUES ('Desarrollador','0000','dev@sys.com',
                            (SELECT RolID FROM ROLES WHERE Nombre='Administrador' LIMIT 1),
                            'admin',LOWER(SHA2('2006',256)),'Administración',1);
                          ";

                    ExecNonQuery(sqlInsert);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando usuario admin:\n" + ex.Message);
            }
        }

        // ==========================================================
        // FUNCIONES PARA PAGO A EMPLEADOS
        // ==========================================================
        public static bool EmpleadoExiste(int empleadoId)
        {
            string sql = "SELECT COUNT(*) FROM EMPLEADOS WHERE EmpleadoID=@id;";
            return Convert.ToInt32(ExecScalar(sql, P("@id", empleadoId))) > 0;
        }

        public static int EnsureServicioPago()
        {
            const string nombre = "PAGO A EMPLEADO";

            if (AppState.IsMySql)
            {
                ExecNonQuery(@"
                    INSERT INTO SERVICIOS (Nombre,Descripcion,Precio)
                    SELECT @n,'',0
                    WHERE NOT EXISTS (SELECT 1 FROM SERVICIOS WHERE Nombre=@n);",
                    P("@n", nombre));

                return Convert.ToInt32(
                    ExecScalar("SELECT ServicioID FROM SERVICIOS WHERE Nombre=@n LIMIT 1;", P("@n", nombre))
                );
            }
            else
            {
                ExecNonQuery(@"
                    IF NOT EXISTS (SELECT 1 FROM SERVICIOS WHERE Nombre=@n)
                    INSERT INTO SERVICIOS (Nombre,Descripcion,Precio) VALUES (@n,'',0);",
                    P("@n", nombre));

                return Convert.ToInt32(
                    ExecScalar("SELECT TOP 1 ServicioID FROM SERVICIOS WHERE Nombre=@n;", P("@n", nombre))
                );
            }
        }
    }
}
