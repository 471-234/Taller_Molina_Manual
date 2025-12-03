namespace TallerMolinaproyecto
{
    partial class menu_principal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            areaMantenumientoToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            rolesEmpleadosToolStripMenuItem = new ToolStripMenuItem();
            areaOperacionesToolStripMenuItem = new ToolStripMenuItem();
            facturcionToolStripMenuItem = new ToolStripMenuItem();
            detallesDeFacturasToolStripMenuItem = new ToolStripMenuItem();
            pagosToolStripMenuItem = new ToolStripMenuItem();
            rEPUESTOSToolStripMenuItem = new ToolStripMenuItem();
            rEPUESTOSToolStripMenuItem1 = new ToolStripMenuItem();
            iNVENTARIOToolStripMenuItem = new ToolStripMenuItem();
            sERVICIOSToolStripMenuItem1 = new ToolStripMenuItem();
            rEVICIONToolStripMenuItem = new ToolStripMenuItem();
            mECANICAToolStripMenuItem = new ToolStripMenuItem();
            pINTURAToolStripMenuItem = new ToolStripMenuItem();
            buscadorGeneralToolStripMenuItem = new ToolStripMenuItem();
            boaToolStripMenuItem = new ToolStripMenuItem();
            bitacoraToolStripMenuItem = new ToolStripMenuItem();
            configuracionToolStripMenuItem = new ToolStripMenuItem();
            cambiarMotorToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            menu = new Panel();
            aYUDAToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Firebrick;
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { areaMantenumientoToolStripMenuItem, areaOperacionesToolStripMenuItem, rEPUESTOSToolStripMenuItem, sERVICIOSToolStripMenuItem1, buscadorGeneralToolStripMenuItem, boaToolStripMenuItem, bitacoraToolStripMenuItem, configuracionToolStripMenuItem, aYUDAToolStripMenuItem, cerrarSesionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1600, 28);
            menuStrip1.TabIndex = 1;
            // 
            // areaMantenumientoToolStripMenuItem
            // 
            areaMantenumientoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientesToolStripMenuItem, rolesEmpleadosToolStripMenuItem });
            areaMantenumientoToolStripMenuItem.Name = "areaMantenumientoToolStripMenuItem";
            areaMantenumientoToolStripMenuItem.Size = new Size(103, 24);
            areaMantenumientoToolStripMenuItem.Text = "REGISTROS";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(224, 26);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += ClientesToolStripMenuItem_Click;
            // 
            // rolesEmpleadosToolStripMenuItem
            // 
            rolesEmpleadosToolStripMenuItem.Name = "rolesEmpleadosToolStripMenuItem";
            rolesEmpleadosToolStripMenuItem.Size = new Size(224, 26);
            rolesEmpleadosToolStripMenuItem.Text = "Roles / Empleados";
            rolesEmpleadosToolStripMenuItem.Click += RolesEmpleadosToolStripMenuItem_Click;
            // 
            // areaOperacionesToolStripMenuItem
            // 
            areaOperacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { facturcionToolStripMenuItem, detallesDeFacturasToolStripMenuItem, pagosToolStripMenuItem });
            areaOperacionesToolStripMenuItem.Name = "areaOperacionesToolStripMenuItem";
            areaOperacionesToolStripMenuItem.Size = new Size(72, 24);
            areaOperacionesToolStripMenuItem.Text = "PAGOS";
            // 
            // facturcionToolStripMenuItem
            // 
            facturcionToolStripMenuItem.Name = "facturcionToolStripMenuItem";
            facturcionToolStripMenuItem.Size = new Size(204, 26);
            facturcionToolStripMenuItem.Text = "Facturación";
            facturcionToolStripMenuItem.Click += FacturcionToolStripMenuItem_Click;
            // 
            // detallesDeFacturasToolStripMenuItem
            // 
            detallesDeFacturasToolStripMenuItem.Name = "detallesDeFacturasToolStripMenuItem";
            detallesDeFacturasToolStripMenuItem.Size = new Size(204, 26);
            detallesDeFacturasToolStripMenuItem.Text = "Detalles Factura";
            detallesDeFacturasToolStripMenuItem.Click += DetallesDeFacturasToolStripMenuItem_Click;
            // 
            // pagosToolStripMenuItem
            // 
            pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            pagosToolStripMenuItem.Size = new Size(204, 26);
            pagosToolStripMenuItem.Text = "Pagos";
            pagosToolStripMenuItem.Click += PagosToolStripMenuItem_Click;
            // 
            // rEPUESTOSToolStripMenuItem
            // 
            rEPUESTOSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rEPUESTOSToolStripMenuItem1, iNVENTARIOToolStripMenuItem });
            rEPUESTOSToolStripMenuItem.Name = "rEPUESTOSToolStripMenuItem";
            rEPUESTOSToolStripMenuItem.Size = new Size(115, 24);
            rEPUESTOSToolStripMenuItem.Text = "INVENTARIO";
            // 
            // rEPUESTOSToolStripMenuItem1
            // 
            rEPUESTOSToolStripMenuItem1.Name = "rEPUESTOSToolStripMenuItem1";
            rEPUESTOSToolStripMenuItem1.Size = new Size(165, 26);
            rEPUESTOSToolStripMenuItem1.Text = "Repuestos";
            rEPUESTOSToolStripMenuItem1.Click += REPUESTOSToolStripMenuItem_Click;
            // 
            // iNVENTARIOToolStripMenuItem
            // 
            iNVENTARIOToolStripMenuItem.Name = "iNVENTARIOToolStripMenuItem";
            iNVENTARIOToolStripMenuItem.Size = new Size(165, 26);
            iNVENTARIOToolStripMenuItem.Text = "Inventario";
            iNVENTARIOToolStripMenuItem.Click += INVENTARIOToolStripMenuItem_Click;
            // 
            // sERVICIOSToolStripMenuItem1
            // 
            sERVICIOSToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { rEVICIONToolStripMenuItem, mECANICAToolStripMenuItem, pINTURAToolStripMenuItem });
            sERVICIOSToolStripMenuItem1.Name = "sERVICIOSToolStripMenuItem1";
            sERVICIOSToolStripMenuItem1.Size = new Size(97, 24);
            sERVICIOSToolStripMenuItem1.Text = "SERVICIOS";
            // 
            // rEVICIONToolStripMenuItem
            // 
            rEVICIONToolStripMenuItem.Name = "rEVICIONToolStripMenuItem";
            rEVICIONToolStripMenuItem.Size = new Size(157, 26);
            rEVICIONToolStripMenuItem.Text = "Revisión";
            rEVICIONToolStripMenuItem.Click += REVICIONToolStripMenuItem_Click;
            // 
            // mECANICAToolStripMenuItem
            // 
            mECANICAToolStripMenuItem.Name = "mECANICAToolStripMenuItem";
            mECANICAToolStripMenuItem.Size = new Size(157, 26);
            mECANICAToolStripMenuItem.Text = "Mecánica";
            mECANICAToolStripMenuItem.Click += MECANICAToolStripMenuItem_Click;
            // 
            // pINTURAToolStripMenuItem
            // 
            pINTURAToolStripMenuItem.Name = "pINTURAToolStripMenuItem";
            pINTURAToolStripMenuItem.Size = new Size(157, 26);
            pINTURAToolStripMenuItem.Text = "Pintura";
            pINTURAToolStripMenuItem.Click += PINTURAToolStripMenuItem_Click;
            // 
            // buscadorGeneralToolStripMenuItem
            // 
            buscadorGeneralToolStripMenuItem.Name = "buscadorGeneralToolStripMenuItem";
            buscadorGeneralToolStripMenuItem.Size = new Size(176, 24);
            buscadorGeneralToolStripMenuItem.Text = "BUSCADOR GENERAL";
            buscadorGeneralToolStripMenuItem.Click += BuscadorGeneralToolStripMenuItem_Click;
            // 
            // boaToolStripMenuItem
            // 
            boaToolStripMenuItem.Name = "boaToolStripMenuItem";
            boaToolStripMenuItem.Size = new Size(190, 24);
            boaToolStripMenuItem.Text = "PANEL GENERAL (BOA)";
            boaToolStripMenuItem.Click += BoaToolStripMenuItem_Click;
            // 
            // bitacoraToolStripMenuItem
            // 
            bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            bitacoraToolStripMenuItem.Size = new Size(98, 24);
            bitacoraToolStripMenuItem.Text = "BITÁCORA";
            bitacoraToolStripMenuItem.Click += BitacoraToolStripMenuItem_Click;
            // 
            // configuracionToolStripMenuItem
            // 
            configuracionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cambiarMotorToolStripMenuItem });
            configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            configuracionToolStripMenuItem.Size = new Size(174, 24);
            configuracionToolStripMenuItem.Text = "⚙ CONFIGURACIÓN";
            configuracionToolStripMenuItem.Click += configuracionToolStripMenuItem_Click;
            // 
            // cambiarMotorToolStripMenuItem
            // 
            cambiarMotorToolStripMenuItem.Name = "cambiarMotorToolStripMenuItem";
            cambiarMotorToolStripMenuItem.Size = new Size(224, 26);
            cambiarMotorToolStripMenuItem.Text = "Cambiar Motor";
            cambiarMotorToolStripMenuItem.Click += CambiarMotorToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(135, 24);
            cerrarSesionToolStripMenuItem.Text = "\u23fb Cerrar Sesión";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // menu
            // 
            menu.BackColor = Color.WhiteSmoke;
            menu.Dock = DockStyle.Fill;
            menu.Location = new Point(0, 28);
            menu.Name = "menu";
            menu.Size = new Size(1600, 905);
            menu.TabIndex = 0;
            // 
            // aYUDAToolStripMenuItem
            // 
            aYUDAToolStripMenuItem.Name = "aYUDAToolStripMenuItem";
            aYUDAToolStripMenuItem.Size = new Size(75, 24);
            aYUDAToolStripMenuItem.Text = "AYUDA";
            aYUDAToolStripMenuItem.Click += aYUDAToolStripMenuItem_Click;
            // 
            // menu_principal
            // 
            ClientSize = new Size(1600, 933);
            Controls.Add(menu);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "menu_principal";
            Text = "Menú Principal - Taller Molina";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Panel menu;

        private ToolStripMenuItem areaMantenumientoToolStripMenuItem, clientesToolStripMenuItem, rolesEmpleadosToolStripMenuItem;
        private ToolStripMenuItem areaOperacionesToolStripMenuItem, facturcionToolStripMenuItem, detallesDeFacturasToolStripMenuItem, pagosToolStripMenuItem;
        private ToolStripMenuItem rEPUESTOSToolStripMenuItem, rEPUESTOSToolStripMenuItem1, iNVENTARIOToolStripMenuItem;
        private ToolStripMenuItem sERVICIOSToolStripMenuItem1, rEVICIONToolStripMenuItem, mECANICAToolStripMenuItem, pINTURAToolStripMenuItem;
        private ToolStripMenuItem buscadorGeneralToolStripMenuItem, boaToolStripMenuItem;
        private ToolStripMenuItem bitacoraToolStripMenuItem;
        private ToolStripMenuItem configuracionToolStripMenuItem, cambiarMotorToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem aYUDAToolStripMenuItem;
    }
}
