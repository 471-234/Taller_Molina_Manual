namespace TallerMolinaproyecto
{
    partial class Factura
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigoIngreso;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvDetalle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            header = new Panel();
            lblTitulo = new Label();
            content = new Panel();
            dgvDetalle = new DataGridView();
            lblTotal = new Label();
            grpDatos = new GroupBox();
            lblNum = new Label();
            txtNumeroFactura = new TextBox();
            lblCodigo = new Label();
            txtCodigoIngreso = new TextBox();
            lblServicio = new Label();
            cmbServicio = new ComboBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblCantidad = new Label();
            txtCantidad = new TextBox();
            btnAgregar = new Button();
            btnImprimir = new Button();
            header.SuspendLayout();
            content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            grpDatos.SuspendLayout();
            SuspendLayout();
            // 
            // header
            // 
            header.BackColor = Color.Brown;
            header.Controls.Add(lblTitulo);
            header.Dock = DockStyle.Top;
            header.Location = new Point(0, 0);
            header.Name = "header";
            header.Padding = new Padding(20, 10, 20, 10);
            header.Size = new Size(1200, 70);
            header.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Left;
            lblTitulo.Font = new Font("Segoe UI Black", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(390, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "FACTURACIÓN";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // content
            // 
            content.BackColor = Color.WhiteSmoke;
            content.Controls.Add(dgvDetalle);
            content.Controls.Add(lblTotal);
            content.Controls.Add(grpDatos);
            content.Dock = DockStyle.Fill;
            content.Location = new Point(0, 70);
            content.Name = "content";
            content.Padding = new Padding(20);
            content.Size = new Size(1200, 630);
            content.TabIndex = 0;
            // 
            // dgvDetalle
            // 
            dgvDetalle.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Firebrick;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalle.ColumnHeadersHeight = 34;
            dgvDetalle.Dock = DockStyle.Fill;
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.Location = new Point(20, 180);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.RowHeadersWidth = 62;
            dgvDetalle.Size = new Size(1160, 400);
            dgvDetalle.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Bottom;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Brown;
            lblTotal.Location = new Point(20, 580);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(1160, 30);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "TOTAL: L0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblNum);
            grpDatos.Controls.Add(txtNumeroFactura);
            grpDatos.Controls.Add(lblCodigo);
            grpDatos.Controls.Add(txtCodigoIngreso);
            grpDatos.Controls.Add(lblServicio);
            grpDatos.Controls.Add(cmbServicio);
            grpDatos.Controls.Add(lblPrecio);
            grpDatos.Controls.Add(txtPrecio);
            grpDatos.Controls.Add(lblCantidad);
            grpDatos.Controls.Add(txtCantidad);
            grpDatos.Controls.Add(btnAgregar);
            grpDatos.Controls.Add(btnImprimir);
            grpDatos.Dock = DockStyle.Top;
            grpDatos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDatos.ForeColor = Color.Brown;
            grpDatos.Location = new Point(20, 20);
            grpDatos.Name = "grpDatos";
            grpDatos.Padding = new Padding(15);
            grpDatos.Size = new Size(1160, 160);
            grpDatos.TabIndex = 2;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos de Factura";
            grpDatos.Enter += grpDatos_Enter;
            // 
            // lblNum
            // 
            lblNum.ForeColor = Color.Brown;
            lblNum.Location = new Point(30, 40);
            lblNum.Name = "lblNum";
            lblNum.Size = new Size(122, 33);
            lblNum.TabIndex = 0;
            lblNum.Text = "N° Factura:";
            // 
            // txtNumeroFactura
            // 
            txtNumeroFactura.Location = new Point(157, 38);
            txtNumeroFactura.Name = "txtNumeroFactura";
            txtNumeroFactura.Size = new Size(150, 30);
            txtNumeroFactura.TabIndex = 1;
            txtNumeroFactura.TextChanged += txtNumeroFactura_TextChanged;
            // 
            // lblCodigo
            // 
            lblCodigo.ForeColor = Color.Brown;
            lblCodigo.Location = new Point(320, 40);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(160, 39);
            lblCodigo.TabIndex = 2;
            lblCodigo.Text = "Código Ingreso:";
            // 
            // txtCodigoIngreso
            // 
            txtCodigoIngreso.Location = new Point(489, 39);
            txtCodigoIngreso.Name = "txtCodigoIngreso";
            txtCodigoIngreso.Size = new Size(150, 30);
            txtCodigoIngreso.TabIndex = 3;
            // 
            // lblServicio
            // 
            lblServicio.ForeColor = Color.Brown;
            lblServicio.Location = new Point(30, 90);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(94, 32);
            lblServicio.TabIndex = 4;
            lblServicio.Text = "Servicio:";
            lblServicio.Click += lblServicio_Click;
            // 
            // cmbServicio
            // 
            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicio.Location = new Point(130, 88);
            cmbServicio.Name = "cmbServicio";
            cmbServicio.Size = new Size(150, 31);
            cmbServicio.TabIndex = 5;
            // 
            // lblPrecio
            // 
            lblPrecio.ForeColor = Color.Brown;
            lblPrecio.Location = new Point(309, 90);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(81, 34);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(390, 88);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(104, 30);
            txtPrecio.TabIndex = 7;
            // 
            // lblCantidad
            // 
            lblCantidad.ForeColor = Color.Brown;
            lblCantidad.Location = new Point(500, 90);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(108, 34);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(606, 86);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(137, 30);
            txtCantidad.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Brown;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(903, 40);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(160, 39);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar Servicio";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.Brown;
            btnImprimir.Location = new Point(905, 85);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(160, 39);
            btnImprimir.TabIndex = 11;
            btnImprimir.Text = "Imprimir PDF";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // Factura
            // 
            Controls.Add(content);
            Controls.Add(header);
            Name = "Factura";
            Size = new Size(1200, 700);
            Load += Factura_Load;
            header.ResumeLayout(false);
            content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }
    }
}
