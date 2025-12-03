using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    partial class UC_BuscadorGeneral
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private ComboBox cmbCategoria;
        private TextBox txtTermino;
        private Button btnBuscar;
        private Button btnExportar;
        private DataGridView dgvResultados;
        private Label lblCat, lblTerm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblCat = new Label();
            cmbCategoria = new ComboBox();
            lblTerm = new Label();
            txtTermino = new TextBox();
            btnBuscar = new Button();
            btnExportar = new Button();
            dgvResultados = new DataGridView();

            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();

            // Panel superior
            panelTop.BackColor = System.Drawing.Color.FromArgb(178, 34, 34);
            panelTop.Controls.Add(lblCat);
            panelTop.Controls.Add(cmbCategoria);
            panelTop.Controls.Add(lblTerm);
            panelTop.Controls.Add(txtTermino);
            panelTop.Controls.Add(btnBuscar);
            panelTop.Controls.Add(btnExportar);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 80;
            panelTop.Name = "panelTop";

            // Label categoría
            lblCat.ForeColor = System.Drawing.Color.White;
            lblCat.Text = "Categoría:";
            lblCat.Location = new System.Drawing.Point(20, 25);
            lblCat.Size = new System.Drawing.Size(100, 30);

            // ComboBox
            cmbCategoria.Location = new System.Drawing.Point(120, 22);
            cmbCategoria.Size = new System.Drawing.Size(200, 33);

            // Label término
            lblTerm.ForeColor = System.Drawing.Color.White;
            lblTerm.Text = "Buscar:";
            lblTerm.Location = new System.Drawing.Point(340, 25);
            lblTerm.Size = new System.Drawing.Size(80, 23);

            // TextBox
            txtTermino.Location = new System.Drawing.Point(420, 22);
            txtTermino.Size = new System.Drawing.Size(400, 31);

            // Botón Buscar
            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new System.Drawing.Point(840, 20);
            btnBuscar.Size = new System.Drawing.Size(115, 38);
            btnBuscar.Click += new System.EventHandler(btnBuscar_Click);

            // Botón Exportar
            btnExportar.Text = "Exportar";
            btnExportar.Location = new System.Drawing.Point(970, 20);
            btnExportar.Size = new System.Drawing.Size(115, 38);
            btnExportar.Click += new System.EventHandler(btnExportar_Click);

            // DataGridView
            dgvResultados.Dock = DockStyle.Fill;
            dgvResultados.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvResultados.ColumnHeadersHeight = 34;
            dgvResultados.RowHeadersWidth = 62;

            // Control principal
            Controls.Add(dgvResultados);
            Controls.Add(panelTop);
            Name = "UC_BuscadorGeneral";
            Size = new System.Drawing.Size(1425, 316);
            Load += new System.EventHandler(UC_BuscadorGeneral_Load);

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }
    }
}
