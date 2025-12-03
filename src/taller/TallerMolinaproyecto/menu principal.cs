using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class menu_principal : Form
    {
        public menu_principal()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.DoubleBuffered = true;
            this.Load += menu_principal_Load;
        }

        private void menu_principal_Load(object sender, EventArgs e)
        {
            try
            {
                string motor = AppState.MotorEnUso();

                MessageBox.Show($"🟢 Bienvenido {AppState.UsuarioNombre}\nMotor: {motor}\nRol: {AppState.Rol}",
                    "Sesión iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AplicarPermisosPorRol();

                // 👇 AGREGAR ESTO
                CargarUserControl(new DashboardControl());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar menú: " + ex.Message);
            }
        }

        // ======================================================
        // PERMISOS POR ROL
        // ======================================================
        private void AplicarPermisosPorRol()
        {
            string rol = AppState.Rol.ToUpper();

            if (rol == "ADMINISTRADOR" || rol == "DESARROLLADOR")
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                    item.Visible = true;
                return;
            }

            if (rol == "SECRETARIO")
            {
                configuracionToolStripMenuItem.Visible = false;
                rolesEmpleadosToolStripMenuItem.Visible = false;
            }
            else if (rol == "EMPLEADO")
            {
                areaMantenumientoToolStripMenuItem.Visible = false;
                areaOperacionesToolStripMenuItem.Visible = false;
                configuracionToolStripMenuItem.Visible = false;
            }
        }

        // ======================================================
        // CARGADOR DE MÓDULOS (EL ÚNICO MÉTODO QUE SE USA)
        // ======================================================
        private void CargarUserControl(UserControl control)
        {
            menu.Controls.Clear();
            control.Dock = DockStyle.Fill;
            menu.Controls.Add(control);
        }

        // ======================================================
        // MENÚS PRINCIPALES
        // ======================================================
        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new Cliente());
        private void RolesEmpleadosToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new EMPLEADOS());
        private void FacturcionToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new Factura());
        private void DetallesDeFacturasToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new DetalleFactura());
        private void PagosToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new Pagos());
        private void REPUESTOSToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new Repuestos());
        private void INVENTARIOToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new Inventario());
        private void REVICIONToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new ServicioRevision());
        private void MECANICAToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new ServicioMecanica());
        private void PINTURAToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new ServicioPintura());
        private void BuscadorGeneralToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new UC_BuscadorGeneral());
        private void BoaToolStripMenuItem_Click(object sender, EventArgs e) => CargarUserControl(new DashboardControl());

        // 🚀 BITÁCORA (ya funcional)
        private void BitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarUserControl(new BitacoraControl());
        }

        // ======================================================
        // CAMBIAR MOTOR
        // ======================================================
        private void CambiarMotorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppState.Rol.ToUpper() == "ADMINISTRADOR" || AppState.Rol.ToUpper() == "DESARROLLADOR")
            {
                MessageBox.Show("⚙️ Aquí se abriría la ventana de cambio de motor de base de datos.",
                    "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ Esta función solo está disponible para el Administrador o Desarrollador.",
                    "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ======================================================
        // CERRAR SESIÓN
        // ======================================================
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas cerrar la sesión actual?", "Cerrar Sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppState.CerrarSesion();
                this.Close();
            }
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aYUDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string tempFile = Path.Combine(Path.GetTempPath(), "Manual de Usuario.pdf");

                if (!File.Exists(tempFile))
                {
                    File.WriteAllBytes(tempFile, Properties.Resources.Manual_de_Usuario);
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la ayuda: " + ex.Message);
            }
        }
    }
}
