using System.Drawing;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    partial class ServicioMecanica
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvMecanica;
        private TextBox txtNombre, txtDescripcion, txtPrecio, txtBuscar, txtCodigoIngreso, txtDetalleIngreso;
        private Button btnGuardar, btnEditar, btnEliminar, btnRefrescar, btnBuscar;
        private Label lblTitulo, lblNombre, lblDescripcion, lblPrecio, lblCodigoIngreso, lblDetalleIngreso;
        private Panel panelHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvMecanica = new DataGridView();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtBuscar = new TextBox();
            txtCodigoIngreso = new TextBox();
            txtDetalleIngreso = new TextBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnRefrescar = new Button();
            btnBuscar = new Button();
            lblTitulo = new Label();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblPrecio = new Label();
            lblCodigoIngreso = new Label();
            lblDetalleIngreso = new Label();
            panelHeader = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvMecanica).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMecanica
            // 
            dgvMecanica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMecanica.BackgroundColor = Color.WhiteSmoke;
            dgvMecanica.BorderStyle = BorderStyle.None;
            dgvMecanica.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Firebrick;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMecanica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMecanica.ColumnHeadersHeight = 34;
            dgvMecanica.Dock = DockStyle.Top;
            dgvMecanica.EnableHeadersVisualStyles = false;
            dgvMecanica.Location = new Point(0, 0);
            dgvMecanica.Name = "dgvMecanica";
            dgvMecanica.ReadOnly = true;
            dgvMecanica.RowHeadersVisible = false;
            dgvMecanica.RowHeadersWidth = 62;
            dgvMecanica.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMecanica.Size = new Size(1200, 360);
            dgvMecanica.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(200, 464);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 31);
            txtNombre.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(200, 504);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(500, 31);
            txtDescripcion.TabIndex = 6;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(200, 544);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(150, 31);
            txtPrecio.TabIndex = 7;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(785, 464);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 31);
            txtBuscar.TabIndex = 10;
            // 
            // txtCodigoIngreso
            // 
            txtCodigoIngreso.Location = new Point(200, 593);
            txtCodigoIngreso.Name = "txtCodigoIngreso";
            txtCodigoIngreso.Size = new Size(200, 31);
            txtCodigoIngreso.TabIndex = 8;
            // 
            // txtDetalleIngreso
            // 
            txtDetalleIngreso.Location = new Point(200, 630);
            txtDetalleIngreso.Multiline = true;
            txtDetalleIngreso.Name = "txtDetalleIngreso";
            txtDetalleIngreso.Size = new Size(500, 60);
            txtDetalleIngreso.TabIndex = 9;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(184, 696);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 45);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(304, 696);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(78, 45);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(424, 696);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(91, 45);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(544, 696);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(96, 45);
            btnRefrescar.TabIndex = 14;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(900, 462);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(87, 33);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1200, 68);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ÁREA DE MECÁNICA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(112, 464);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 31);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(85, 504);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(109, 31);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            lblPrecio.Location = new Point(128, 544);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(66, 31);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio:";
            // 
            // lblCodigoIngreso
            // 
            lblCodigoIngreso.Location = new Point(70, 593);
            lblCodigoIngreso.Name = "lblCodigoIngreso";
            lblCodigoIngreso.Size = new Size(130, 31);
            lblCodigoIngreso.TabIndex = 16;
            lblCodigoIngreso.Text = "Código ingreso:";
            // 
            // lblDetalleIngreso
            // 
            lblDetalleIngreso.Location = new Point(70, 630);
            lblDetalleIngreso.Name = "lblDetalleIngreso";
            lblDetalleIngreso.Size = new Size(130, 31);
            lblDetalleIngreso.TabIndex = 17;
            lblDetalleIngreso.Text = "Detalle ingreso:";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Firebrick;
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 360);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 68);
            panelHeader.TabIndex = 0;
            // 
            // ServicioMecanica
            // 
            Controls.Add(panelHeader);
            Controls.Add(dgvMecanica);
            Controls.Add(lblNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(lblPrecio);
            Controls.Add(lblCodigoIngreso);
            Controls.Add(lblDetalleIngreso);
            Controls.Add(txtNombre);
            Controls.Add(txtDescripcion);
            Controls.Add(txtPrecio);
            Controls.Add(txtCodigoIngreso);
            Controls.Add(txtDetalleIngreso);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnRefrescar);
            Name = "ServicioMecanica";
            Size = new Size(1200, 777);
            ((System.ComponentModel.ISupportInitialize)dgvMecanica).EndInit();
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
