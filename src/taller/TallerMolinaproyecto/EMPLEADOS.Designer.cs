namespace TallerMolinaproyecto
{
    partial class EMPLEADOS
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EMPLEADOS));
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            chkActivo = new CheckBox();
            cmbArea = new ComboBox();
            lblArea = new Label();
            cmbRol = new ComboBox();
            lblRol = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtContrasena = new TextBox();
            lblContrasena = new Label();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            dgvEmpleados = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(642, 653);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(96, 51);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Eliminar";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(505, 653);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 51);
            btnGuardar.TabIndex = 21;
            btnGuardar.Text = "Guardar";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(360, 653);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 51);
            btnNuevo.TabIndex = 20;
            btnNuevo.Text = "Nuevo";
            // 
            // chkActivo
            // 
            chkActivo.Location = new Point(820, 580);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(104, 24);
            chkActivo.TabIndex = 19;
            chkActivo.Text = "Activo";
            // 
            // cmbArea
            // 
            cmbArea.Location = new Point(586, 576);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(200, 33);
            cmbArea.TabIndex = 18;
            // 
            // lblArea
            // 
            lblArea.Location = new Point(519, 579);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(61, 29);
            lblArea.TabIndex = 17;
            lblArea.Text = "Área:";
            // 
            // cmbRol
            // 
            cmbRol.Location = new Point(295, 576);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(200, 33);
            cmbRol.TabIndex = 16;
            // 
            // lblRol
            // 
            lblRol.Location = new Point(236, 580);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(53, 29);
            lblRol.TabIndex = 15;
            lblRol.Text = "Rol:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(883, 530);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(200, 31);
            txtCorreo.TabIndex = 14;
            // 
            // lblCorreo
            // 
            lblCorreo.Location = new Point(800, 530);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(77, 28);
            lblCorreo.TabIndex = 13;
            lblCorreo.Text = "Correo:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(630, 527);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 31);
            txtTelefono.TabIndex = 12;
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(541, 530);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(83, 28);
            lblTelefono.TabIndex = 11;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(330, 527);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(200, 31);
            txtContrasena.TabIndex = 10;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblContrasena
            // 
            lblContrasena.Location = new Point(206, 530);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(114, 28);
            lblContrasena.TabIndex = 9;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(724, 477);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(200, 31);
            txtUsuario.TabIndex = 8;
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(630, 480);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(86, 28);
            lblUsuario.TabIndex = 7;
            lblUsuario.Text = "Usuario:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(314, 477);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 31);
            txtNombre.TabIndex = 6;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(202, 480);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(710, 133);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 32);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(295, 135);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(400, 31);
            txtBuscar.TabIndex = 2;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.BackgroundColor = Color.White;
            dgvEmpleados.BorderStyle = BorderStyle.Fixed3D;
            dgvEmpleados.ColumnHeadersHeight = 34;
            dgvEmpleados.Location = new Point(150, 200);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersWidth = 62;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Size = new Size(980, 250);
            dgvEmpleados.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1860, 100);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold);
            label1.Location = new Point(400, 30);
            label1.Name = "label1";
            label1.Size = new Size(498, 50);
            label1.TabIndex = 0;
            label1.Text = "GESTIÓN DE EMPLEADOS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(240, 125);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // EMPLEADOS
            // 
            AutoScroll = true;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(dgvEmpleados);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(lblRol);
            Controls.Add(cmbRol);
            Controls.Add(lblArea);
            Controls.Add(cmbArea);
            Controls.Add(chkActivo);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Name = "EMPLEADOS";
            Size = new Size(1860, 914);
            Load += EMPLEADOS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnEliminar, btnGuardar, btnNuevo, btnBuscar;
        private CheckBox chkActivo;
        private ComboBox cmbArea, cmbRol;
        private Label lblArea, lblRol, lblCorreo, lblTelefono, lblContrasena, lblUsuario, lblNombre, label1;
        private TextBox txtCorreo, txtTelefono, txtContrasena, txtUsuario, txtNombre, txtBuscar;
        private DataGridView dgvEmpleados;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}
