using System.Drawing;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    partial class Pagos
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvPagos;
        private Panel panelTop;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Label lblEmpleadoID;
        private TextBox txtEmpleadoID;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvPagos = new DataGridView();
            panelTop = new Panel();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            lblEmpleadoID = new Label();
            txtEmpleadoID = new TextBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPagos
            // 
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.BackgroundColor = Color.White;
            dgvPagos.ColumnHeadersHeight = 40;
            dgvPagos.Dock = DockStyle.Fill;
            dgvPagos.Location = new Point(0, 70);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.RowTemplate.Height = 35;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.Size = new Size(1516, 849);
            dgvPagos.TabIndex = 0;
            dgvPagos.CellContentClick += dgvPagos_CellContentClick;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Brown;
            panelTop.Controls.Add(btnAgregar);
            panelTop.Controls.Add(btnEditar);
            panelTop.Controls.Add(btnEliminar);
            panelTop.Controls.Add(lblEmpleadoID);
            panelTop.Controls.Add(txtEmpleadoID);
            panelTop.Controls.Add(txtBuscar);
            panelTop.Controls.Add(btnBuscar);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1516, 70);
            panelTop.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.White;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F);
            btnAgregar.Location = new Point(20, 20);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(90, 36);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.White;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.Location = new Point(130, 20);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(90, 36);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "✏️ Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F);
            btnEliminar.Location = new Point(240, 20);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 36);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "❌ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblEmpleadoID
            // 
            lblEmpleadoID.AutoSize = true;
            lblEmpleadoID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpleadoID.ForeColor = Color.White;
            lblEmpleadoID.Location = new Point(360, 27);
            lblEmpleadoID.Name = "lblEmpleadoID";
            lblEmpleadoID.Size = new Size(102, 20);
            lblEmpleadoID.TabIndex = 3;
            lblEmpleadoID.Text = "ID Empleado:";
            // 
            // txtEmpleadoID
            // 
            txtEmpleadoID.Location = new Point(491, 27);
            txtEmpleadoID.Name = "txtEmpleadoID";
            txtEmpleadoID.Size = new Size(80, 27);
            txtEmpleadoID.TabIndex = 4;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBuscar.Location = new Point(1116, 25);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(250, 27);
            txtBuscar.TabIndex = 5;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F);
            btnBuscar.Location = new Point(1376, 25);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 30);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // Pagos
            // 
            Controls.Add(dgvPagos);
            Controls.Add(panelTop);
            Name = "Pagos";
            Size = new Size(1516, 919);
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }
    }
}
