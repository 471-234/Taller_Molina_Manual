namespace TallerMolinaproyecto
{
    partial class ServicioRevision
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRevision;
        private System.Windows.Forms.TextBox txtNombre, txtDescripcion, txtPrecio, txtBuscar;
        private System.Windows.Forms.Button btnGuardar, btnEditar, btnEliminar, btnRefrescar, btnBuscar;
        private System.Windows.Forms.Label lblTitulo, lblNombre, lblDescripcion, lblPrecio;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TextBox txtCodigoIngreso;
        private System.Windows.Forms.TextBox txtDetalleIngreso;
        private System.Windows.Forms.Label lblCodigoIngreso;
        private System.Windows.Forms.Label lblDetalleIngreso;


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvRevision = new DataGridView();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtBuscar = new TextBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnRefrescar = new Button();
            btnBuscar = new Button();
            lblTitulo = new Label();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblPrecio = new Label();
            panelHeader = new Panel();
            lblCodigoIngreso = new Label();
            txtCodigoIngreso = new TextBox();
            lblDetalleIngreso = new Label();
            txtDetalleIngreso = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvRevision).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRevision
            // 
            dgvRevision.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevision.BackgroundColor = Color.WhiteSmoke;
            dgvRevision.BorderStyle = BorderStyle.None;
            dgvRevision.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Firebrick;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRevision.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRevision.ColumnHeadersHeight = 34;
            dgvRevision.Dock = DockStyle.Top;
            dgvRevision.EnableHeadersVisualStyles = false;
            dgvRevision.Location = new Point(0, 0);
            dgvRevision.Name = "dgvRevision";
            dgvRevision.ReadOnly = true;
            dgvRevision.RowHeadersVisible = false;
            dgvRevision.RowHeadersWidth = 62;
            dgvRevision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevision.Size = new Size(1200, 380);
            dgvRevision.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(195, 490);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 31);
            txtNombre.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(195, 530);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(500, 31);
            txtDescripcion.TabIndex = 6;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(195, 570);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(150, 31);
            txtPrecio.TabIndex = 7;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(783, 497);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 31);
            txtBuscar.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(180, 687);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(88, 40);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(288, 687);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 40);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(394, 687);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(101, 40);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(514, 687);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(109, 40);
            btnRefrescar.TabIndex = 13;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(889, 488);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(103, 48);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1200, 70);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ÁREA DE REVISIÓN";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(105, 493);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(84, 31);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(80, 530);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(109, 31);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            lblPrecio.Location = new Point(120, 570);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(69, 31);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio:";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Firebrick;
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 380);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblCodigoIngreso
            // 
            lblCodigoIngreso.Location = new Point(105, 610);
            lblCodigoIngreso.Name = "lblCodigoIngreso";
            lblCodigoIngreso.Size = new Size(120, 30);
            lblCodigoIngreso.TabIndex = 14;
            lblCodigoIngreso.Text = "Código ingreso:";
            // 
            // txtCodigoIngreso
            // 
            txtCodigoIngreso.Location = new Point(230, 610);
            txtCodigoIngreso.Name = "txtCodigoIngreso";
            txtCodigoIngreso.Size = new Size(200, 31);
            txtCodigoIngreso.TabIndex = 15;
            // 
            // lblDetalleIngreso
            // 
            lblDetalleIngreso.Location = new Point(105, 650);
            lblDetalleIngreso.Name = "lblDetalleIngreso";
            lblDetalleIngreso.Size = new Size(120, 30);
            lblDetalleIngreso.TabIndex = 16;
            lblDetalleIngreso.Text = "Detalle ingreso:";
            // 
            // txtDetalleIngreso
            // 
            txtDetalleIngreso.Location = new Point(230, 650);
            txtDetalleIngreso.Name = "txtDetalleIngreso";
            txtDetalleIngreso.Size = new Size(500, 31);
            txtDetalleIngreso.TabIndex = 17;
            // 
            // ServicioRevision
            // 
            Controls.Add(panelHeader);
            Controls.Add(dgvRevision);
            Controls.Add(lblNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(lblPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtDescripcion);
            Controls.Add(txtPrecio);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnRefrescar);
            Controls.Add(lblCodigoIngreso);
            Controls.Add(txtCodigoIngreso);
            Controls.Add(lblDetalleIngreso);
            Controls.Add(txtDetalleIngreso);
            Name = "ServicioRevision";
            Size = new Size(1200, 748);
            ((System.ComponentModel.ISupportInitialize)dgvRevision).EndInit();
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
