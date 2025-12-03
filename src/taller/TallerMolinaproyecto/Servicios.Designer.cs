namespace TallerMolinaproyecto
{
    partial class Servicios
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
            lblPlaca = new Label();
            lblDescripcion = new Label();
            lblEstado = new Label();
            lblArea = new Label();
            lblEmpleado = new Label();
            txtDescripcion = new TextBox();
            cmbPlaca = new ComboBox();
            cmbEstado = new ComboBox();
            cmbArea = new ComboBox();
            cmbEmpleado = new ComboBox();
            dgvServicios = new DataGridView();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            panel1 = new Panel();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblPlaca
            // 
            lblPlaca.Location = new Point(386, 275);
            lblPlaca.Margin = new Padding(4, 0, 4, 0);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(79, 41);
            lblPlaca.TabIndex = 14;
            lblPlaca.Text = "Placa:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(364, 358);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(139, 40);
            lblDescripcion.TabIndex = 15;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblEstado
            // 
            lblEstado.Location = new Point(369, 402);
            lblEstado.Margin = new Padding(4, 0, 4, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(96, 38);
            lblEstado.TabIndex = 16;
            lblEstado.Text = "Estado:";
            // 
            // lblArea
            // 
            lblArea.Location = new Point(386, 458);
            lblArea.Margin = new Padding(4, 0, 4, 0);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(75, 38);
            lblArea.TabIndex = 17;
            lblArea.Text = "Área:";
            // 
            // lblEmpleado
            // 
            lblEmpleado.Location = new Point(322, 515);
            lblEmpleado.Margin = new Padding(4, 0, 4, 0);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(164, 41);
            lblEmpleado.TabIndex = 18;
            lblEmpleado.Text = "Asignado por:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(544, 354);
            txtDescripcion.Margin = new Padding(4);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(374, 31);
            txtDescripcion.TabIndex = 19;
            // 
            // cmbPlaca
            // 
            cmbPlaca.Location = new Point(601, 281);
            cmbPlaca.Margin = new Padding(4);
            cmbPlaca.Name = "cmbPlaca";
            cmbPlaca.Size = new Size(249, 33);
            cmbPlaca.TabIndex = 20;
            // 
            // cmbEstado
            // 
            cmbEstado.Items.AddRange(new object[] { "PENDIENTE", "EN_PROCESO", "TERMINADO", "ENTREGADO", "CANCELADO" });
            cmbEstado.Location = new Point(601, 405);
            cmbEstado.Margin = new Padding(4);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(249, 33);
            cmbEstado.TabIndex = 21;
            // 
            // cmbArea
            // 
            cmbArea.Location = new Point(601, 460);
            cmbArea.Margin = new Padding(4);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(249, 33);
            cmbArea.TabIndex = 22;
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.Location = new Point(601, 521);
            cmbEmpleado.Margin = new Padding(4);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new Size(249, 33);
            cmbEmpleado.TabIndex = 23;
            // 
            // dgvServicios
            // 
            dgvServicios.ColumnHeadersHeight = 34;
            dgvServicios.Location = new Point(205, 638);
            dgvServicios.Margin = new Padding(4);
            dgvServicios.Name = "dgvServicios";
            dgvServicios.RowHeadersWidth = 62;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.Size = new Size(1218, 421);
            dgvServicios.TabIndex = 24;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(1262, 255);
            btnNuevo.Margin = new Padding(4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(119, 85);
            btnNuevo.TabIndex = 25;
            btnNuevo.Text = "Nuevo";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1262, 382);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(119, 79);
            btnGuardar.TabIndex = 26;
            btnGuardar.Text = "Guardar";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1262, 504);
            btnEliminar.Margin = new Padding(4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(119, 68);
            btnEliminar.TabIndex = 27;
            btnEliminar.Text = "Eliminar";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-21, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1749, 126);
            panel1.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(636, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(228, 50);
            label1.TabIndex = 0;
            label1.Text = "SERVICIOS";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(224, 651);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1182, 394);
            dataGridView1.TabIndex = 29;
            // 
            // Servicios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(lblPlaca);
            Controls.Add(lblDescripcion);
            Controls.Add(lblEstado);
            Controls.Add(lblArea);
            Controls.Add(lblEmpleado);
            Controls.Add(txtDescripcion);
            Controls.Add(cmbPlaca);
            Controls.Add(cmbEstado);
            Controls.Add(cmbArea);
            Controls.Add(cmbEmpleado);
            Controls.Add(dgvServicios);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Margin = new Padding(4);
            Name = "Servicios";
            Size = new Size(1698, 1166);
            Load += Servicios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlaca;
        private Label lblDescripcion;
        private Label lblEstado;
        private Label lblArea;
        private Label lblEmpleado;
        private TextBox txtDescripcion;
        private ComboBox cmbPlaca;
        private ComboBox cmbEstado;
        private ComboBox cmbArea;
        private ComboBox cmbEmpleado;
        private DataGridView dgvServicios;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Panel panel1;
        private Label label1;
        private DataGridView dataGridView1;
    }
}
