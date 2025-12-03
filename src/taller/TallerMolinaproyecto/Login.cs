using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Apariencia general del formulario
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = Color.LavenderBlush;
            panel1.BackColor = Color.FromArgb(180, 90, 80);
            this.Resize += (s, e) => AjustarCentrado();
        }

        private void AjustarCentrado()
        {
            int ancho = this.ClientSize.Width;
            int alto = this.ClientSize.Height;

            int xCentroTexto = ancho / 3 - 150;
            int yCentro = alto / 2 - 100;

            pictureBox2.Location = new Point(xCentroTexto - 160, yCentro - 40);
            txtuser.Location = new Point(xCentroTexto, yCentro - 40);

            pictureBox3.Location = new Point(xCentroTexto - 150, yCentro + 50);
            txtcontrasena.Location = new Point(xCentroTexto, yCentro + 50);
            checkBox1.Location = new Point(xCentroTexto - 50, yCentro + 100);

           
            bningresar.Location = new Point(xCentroTexto + 200, yCentro + 200);
            bnsalir.Location = new Point(xCentroTexto + 470, yCentro + 200);

            panel1.Width = ancho;
            pictureBox1.Location = new Point(ancho - pictureBox1.Width - 200, panel1.Bottom + 100);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            AjustarCentrado();
            CrearUsuarioDesarrollador(); // 🔒 crea admin si no existe
        }

        // ==========================================================
        // BOTÓN INGRESAR (definitivo)
        // ==========================================================
        private void bningresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtuser.Text.Trim();
                string contrasena = txtcontrasena.Text.Trim();

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
                {
                    MessageBox.Show("Por favor ingrese su usuario y contraseña.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 🔐 Usuario desarrollador universal
                if (usuario.Equals("admin", StringComparison.OrdinalIgnoreCase) && contrasena == "2006")
                {
                    AppState.UsuarioID = 1;
                    AppState.UsuarioNombre = "Desarrollador Principal";
                    AppState.Rol = "Administrador";
                    AppState.RolID = 1;

                    RegistrarBitacora(AppState.UsuarioID, "Inicio de sesión (desarrollador)");

                    MessageBox.Show("✅ Bienvenido, Desarrollador del sistema.",
                        "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AbrirMenuPrincipal();
                    return;
                }

                // 🔑 Generar hash SHA256
                string hash = Security.Sha256(contrasena);

                // 🔎 Buscar usuario
                string sql = AppState.IsMySql
                    ? @"SELECT e.EmpleadoID, e.Nombre, e.RolID, r.Nombre AS Rol, e.Activo, e.ContrasenaHash
                        FROM Empleados e
                        JOIN Roles r ON r.RolID = e.RolID
                        WHERE LOWER(e.Usuario)=LOWER(@u)
                        LIMIT 1;"
                    : @"SELECT TOP 1 e.EmpleadoID, e.Nombre, e.RolID, r.Nombre AS Rol, e.Activo, e.ContrasenaHash
                        FROM Empleados e
                        JOIN Roles r ON r.RolID = e.RolID
                        WHERE LOWER(e.Usuario)=LOWER(@u);";

                DataTable dt = DBHelper.Query(sql, DBHelper.P("@u", usuario));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario no encontrado.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow row = dt.Rows[0];
                string storedPass = row["ContrasenaHash"].ToString();
                bool activo = row["Activo"] != DBNull.Value && Convert.ToBoolean(row["Activo"]);

                if (!activo)
                {
                    MessageBox.Show("El usuario está inactivo.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Comparación segura
                if (!storedPass.Equals(hash, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar sesión
                AppState.UsuarioID = Convert.ToInt32(row["EmpleadoID"]);
                AppState.UsuarioNombre = row["Nombre"].ToString();
                AppState.RolID = Convert.ToInt32(row["RolID"]);
                AppState.Rol = row["Rol"].ToString();

                RegistrarBitacora(AppState.UsuarioID, "Inicio de sesión");

                MessageBox.Show($"Bienvenido {AppState.UsuarioNombre} ({AppState.Rol})",
                    "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AbrirMenuPrincipal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirMenuPrincipal()
        {
            this.Hide(); // Oculta el login, pero no lo cierra

            var menu = new menu_principal();
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.WindowState = FormWindowState.Maximized;

            // 🔁 Cuando el menú se cierra, volver al login
            menu.FormClosed += (s, args) =>
            {
                RegistrarBitacora(AppState.UsuarioID, "Cierre de sesión");

                this.Show();
                txtuser.Clear();
                txtcontrasena.Clear();
                txtuser.Focus();
            };

            menu.Show();
        }

        // ==========================================================
        // CREA USUARIO ADMIN SI NO EXISTE (hash permanente)
        // ==========================================================
        private void CrearUsuarioDesarrollador()
        {
            try
            {
                string hashAdmin = Security.Sha256("2006");

                // Crear rol "Administrador" si no existe
                string sqlRol = AppState.IsSqlServer
                    ? "IF NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre='Administrador') INSERT INTO Roles (Nombre) VALUES ('Administrador');"
                    : "INSERT INTO Roles (Nombre) SELECT 'Administrador' WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre='Administrador');";
                DBHelper.ExecNonQuery(sqlRol);

                // Verificar existencia del usuario admin
                string checkUser = "SELECT COUNT(*) FROM Empleados WHERE LOWER(Usuario)='admin';";
                object existe = DBHelper.ExecScalar(checkUser);

                if (Convert.ToInt32(existe) == 0)
                {
                    string sqlInsert = AppState.IsSqlServer
                        ? $@"DECLARE @rol INT = (SELECT TOP 1 RolID FROM Roles WHERE Nombre='Administrador');
                            INSERT INTO Empleados (Nombre,Telefono,Correo,RolID,Usuario,ContrasenaHash,Area,Activo)
                            VALUES ('Desarrollador Principal','0000','dev@taller.com',@rol,'admin','{hashAdmin}','Administración',1);"
                        : $@"INSERT INTO Empleados (Nombre,Telefono,Correo,RolID,Usuario,ContrasenaHash,Area,Activo)
                            VALUES ('Desarrollador Principal','0000','dev@taller.com',
                            (SELECT RolID FROM Roles WHERE Nombre='Administrador' LIMIT 1),
                            'admin','{hashAdmin}','Administración',1);";
                    DBHelper.ExecNonQuery(sqlInsert);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando usuario desarrollador:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================================
        // BITÁCORA: REGISTRAR ACTIVIDAD
        // ==========================================================
        private void RegistrarBitacora(int usuarioID, string actividad)
        {
            try
            {
                string sql = @"
            INSERT INTO BITACORA (EmpleadoID, Accion, Fecha, Detalle)
            VALUES (@emp, @acc,
                    " + (AppState.IsMySql ? "NOW()" : "GETDATE()") + @",
                    @det);";

                DBHelper.ExecNonQuery(sql,
                    DBHelper.P("@emp", usuarioID),
                    DBHelper.P("@acc", actividad),
                    DBHelper.P("@det", $"Realizado por {AppState.UsuarioNombre}"));
            }
            catch
            {
                // No interrumpir el programa si falla la bitácora
            }
        }


        private void bneliminar_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtcontrasena.Clear();
            txtuser.Focus();
        }

        private void bnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtcontrasena.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
