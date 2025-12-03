namespace TallerMolinaproyecto
{
    partial class Repuestos
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvRepuestos = new DataGridView();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrecio = new Label();
            numPrecio = new NumericUpDown();
            lblStock = new Label();
            numStock = new NumericUpDown();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRepuestos
            // 
            dgvRepuestos.AllowUserToAddRows = false;
            dgvRepuestos.AllowUserToDeleteRows = false;
            dgvRepuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepuestos.Location = new Point(161, 324);
            dgvRepuestos.Margin = new Padding(4);
            dgvRepuestos.MultiSelect = false;
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.ReadOnly = true;
            dgvRepuestos.RowHeadersWidth = 62;
            dgvRepuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRepuestos.Size = new Size(1152, 250);
            dgvRepuestos.TabIndex = 14;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(852, 190);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(374, 31);
            txtBuscar.TabIndex = 15;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(1238, 190);
            btnBuscar.Margin = new Padding(4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(104, 39);
            btnBuscar.TabIndex = 16;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(350, 654);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 17;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(606, 654);
            txtNombre.Margin = new Padding(4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(249, 31);
            txtNombre.TabIndex = 18;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(339, 734);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(108, 25);
            lblDescripcion.TabIndex = 19;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(606, 725);
            txtDescripcion.Margin = new Padding(4);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(374, 31);
            txtDescripcion.TabIndex = 20;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(368, 800);
            lblPrecio.Margin = new Padding(4, 0, 4, 0);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(64, 25);
            lblPrecio.TabIndex = 21;
            lblPrecio.Text = "Precio:";
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Location = new Point(606, 800);
            numPrecio.Margin = new Padding(4);
            numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(150, 31);
            numPrecio.TabIndex = 22;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(374, 879);
            lblStock.Margin = new Padding(4, 0, 4, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(59, 25);
            lblStock.TabIndex = 23;
            lblStock.Text = "Stock:";
            // 
            // numStock
            // 
            numStock.Location = new Point(606, 879);
            numStock.Margin = new Padding(4);
            numStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(150, 31);
            numStock.TabIndex = 24;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(1192, 716);
            btnNuevo.Margin = new Padding(4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(110, 68);
            btnNuevo.TabIndex = 25;
            btnNuevo.Text = "Nuevo";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1198, 860);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 68);
            btnGuardar.TabIndex = 26;
            btnGuardar.Text = "Guardar";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(161, 966);
            btnEliminar.Margin = new Padding(4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 68);
            btnEliminar.TabIndex = 27;
            btnEliminar.Text = "Eliminar";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-8, -10);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1702, 141);
            panel1.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(532, 54);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(253, 50);
            label1.TabIndex = 0;
            label1.Text = "REPUESTOS";
            // 
            // Repuestos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(dgvRepuestos);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblPrecio);
            Controls.Add(numPrecio);
            Controls.Add(lblStock);
            Controls.Add(numStock);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Margin = new Padding(4);
            Name = "Repuestos";
            Size = new Size(1676, 1170);
            Load += Repuestos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRepuestos;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblPrecio;
        private NumericUpDown numPrecio;
        private Label lblStock;
        private NumericUpDown numStock;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Panel panel1;
        private Label label1;
    }
}
