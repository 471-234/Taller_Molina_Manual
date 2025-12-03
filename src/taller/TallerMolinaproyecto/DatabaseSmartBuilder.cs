using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace TallerMolinaproyecto
{
    internal static class DatabaseSmartBuilder
    {
        public const string MYSQL = "MYSQL";
        private const string MySqlServerConnBase =
             "Server=localhost;Port=3306;Uid=root;Pwd=kook21_;SslMode=None;AllowPublicKeyRetrieval=True;";
        private const string MySqlDb = "TallerMolina_v2";


        // =================================================================
        // CREA LA BASE SI NO EXISTE
        // =================================================================
        public static void EnsureDatabaseExists(string engine)
        {
            try
            {
                using var connection = new MySqlConnection(MySqlServerConnBase);
                connection.Open();

                using var cmd = new MySqlCommand($@"
                    CREATE DATABASE IF NOT EXISTS `{MySqlDb}` 
                    CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;", connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando la base de datos: " + ex.Message);
            }
        }

        public static MySqlConnection GetConnection()
        {
            string connStr = MySqlServerConnBase + $"Database={MySqlDb};";
            return new MySqlConnection(connStr);
        }


        // =================================================================
        // EJECUTA EL SCRIPT COMPLETO (TABLAS + COLUMNAS + LLAVES)
        // =================================================================
        public static void RunScript()
        {
            try
            {
                string schema = GetMySqlSchema();
                string seed = GetMySqlSeed();

                string connStr = MySqlServerConnBase + $"Database={MySqlDb};";
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                using (var cmd = new MySqlCommand(schema, conn) { CommandTimeout = 0 })
                    cmd.ExecuteNonQuery();

                using (var cmd = new MySqlCommand(seed, conn) { CommandTimeout = 0 })
                    cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ejecutando script: " + ex.Message);
            }
        }



        // =================================================================
        // SCHEMA MYSQL COMPLETO
        // =================================================================
        private static string GetMySqlSchema()
        { 
          return @"
        
-- ROLES
CREATE TABLE IF NOT EXISTS ROLES (
  RolID INT AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(50) NOT NULL UNIQUE,
  Descripcion VARCHAR(200)
);

-- EMPLEADOS
CREATE TABLE IF NOT EXISTS EMPLEADOS (
  EmpleadoID INT AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL,
  Telefono VARCHAR(20),
  Correo VARCHAR(100),
  RolID INT,
  Usuario VARCHAR(50),
  ContrasenaHash VARCHAR(128),
  Area VARCHAR(100),
  Activo TINYINT NOT NULL DEFAULT 1,
  CONSTRAINT FK_EmpRol FOREIGN KEY (RolID) REFERENCES ROLES(RolID)
);

-- CLIENTES
CREATE TABLE IF NOT EXISTS CLIENTES (
  ClienteID INT AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL,
  Telefono VARCHAR(20),
  Correo VARCHAR(100),
  Direccion VARCHAR(255),
  FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- SERVICIOS
CREATE TABLE IF NOT EXISTS SERVICIOS (
  ServicioID INT AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL UNIQUE,
  Categoria VARCHAR(50),
  Descripcion VARCHAR(255),
  Precio DECIMAL(12,2) NOT NULL DEFAULT 0,
  Activo TINYINT NOT NULL DEFAULT 1
);

-- FACTURAS
CREATE TABLE IF NOT EXISTS FACTURAS (
  FacturaID INT AUTO_INCREMENT PRIMARY KEY,
  ClienteID INT,
  EmpleadoID INT,
  Fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  Total DECIMAL(12,2) NOT NULL DEFAULT 0,
  Codigo VARCHAR(50),
  TipoFactura VARCHAR(20) NOT NULL DEFAULT 'SERVICIO'
);

-- REPUESTOS
CREATE TABLE IF NOT EXISTS REPUESTOS (
  RepuestoID INT AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(150) NOT NULL,
  Categoria VARCHAR(80),
  Precio DECIMAL(12,2) NOT NULL DEFAULT 0,
  Stock INT NOT NULL DEFAULT 0,
  Activo TINYINT NOT NULL DEFAULT 1
);

-- INVENTARIO
CREATE TABLE IF NOT EXISTS INVENTARIO (
  InventarioID INT AUTO_INCREMENT PRIMARY KEY,
  RepuestoID INT,
  Cantidad INT NOT NULL DEFAULT 0,
  CostoPromedio DECIMAL(12,2) NOT NULL DEFAULT 0,
  FechaActualizacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  CONSTRAINT FK_InvRep FOREIGN KEY (RepuestoID) REFERENCES REPUESTOS(RepuestoID)
);

-- DETALLE_FACTURA
CREATE TABLE IF NOT EXISTS DETALLE_FACTURA (
  DetalleID INT AUTO_INCREMENT PRIMARY KEY,
  FacturaID INT NOT NULL,
  ServicioID INT,
  RepuestoID INT,
  Descripcion VARCHAR(255),
  Cantidad INT NOT NULL DEFAULT 1,
  PrecioUnitario DECIMAL(12,2) NOT NULL DEFAULT 0,
  Subtotal DECIMAL(12,2) NOT NULL DEFAULT 0,
  CONSTRAINT FK_Det_Fact FOREIGN KEY (FacturaID) REFERENCES FACTURAS(FacturaID),
  CONSTRAINT FK_Det_Serv FOREIGN KEY (ServicioID) REFERENCES SERVICIOS(ServicioID),
  CONSTRAINT FK_Det_Rep FOREIGN KEY (RepuestoID) REFERENCES REPUESTOS(RepuestoID)
);

-- PAGOS
CREATE TABLE IF NOT EXISTS PAGOS (
  PagoID INT AUTO_INCREMENT PRIMARY KEY,
  FacturaID INT,
  EmpleadoID INT,
  NumeroCuenta VARCHAR(100),
  Metodo VARCHAR(100),
  Monto DECIMAL(12,2) NOT NULL DEFAULT 0,
  FechaPago DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  Observacion VARCHAR(400)
);

-- BITACORA
CREATE TABLE IF NOT EXISTS BITACORA (
  BitacoraID INT AUTO_INCREMENT PRIMARY KEY,
  EmpleadoID INT,
  Accion VARCHAR(200) NOT NULL,
  Fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  Detalle VARCHAR(500),
  CONSTRAINT FK_Bit_Emp FOREIGN KEY (EmpleadoID) REFERENCES EMPLEADOS(EmpleadoID)
);
";
        }

        // =================================================================
        // SEED MYSQL COMPLETO
        // =================================================================
        private static string GetMySqlSeed()
        {
            return @"
              INSERT INTO ROLES(Nombre,Descripcion) VALUES('Administrador','Acceso total')
              ON DUPLICATE KEY UPDATE Descripcion=VALUES(Descripcion);

              INSERT INTO ROLES(Nombre,Descripcion) VALUES('Secretario','Operación')
              ON DUPLICATE KEY UPDATE Descripcion=VALUES(Descripcion);

              INSERT INTO ROLES(Nombre,Descripcion) VALUES('Mecánico','Taller')
              ON DUPLICATE KEY UPDATE Descripcion=VALUES(Descripcion);

              INSERT INTO ROLES(Nombre,Descripcion) VALUES('Pintor','Pintura')
              ON DUPLICATE KEY UPDATE Descripcion=VALUES(Descripcion);
           ";
        }
    }
}
