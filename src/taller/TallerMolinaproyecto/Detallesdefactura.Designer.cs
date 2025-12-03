using System.Drawing;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    partial class DetalleFactura
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panel1;
        private DataGridView dgvDetalleFactura;
        private Label labelTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            dgvDetalleFactura = new DataGridView();
            labelTitulo = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(dgvDetalleFactura);
            panel1.Location = new Point(53, 125);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1571, 752);
            panel1.TabIndex = 0;
            // 
            // dgvDetalleFactura
            // 
            dgvDetalleFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleFactura.Dock = DockStyle.Fill;
            dgvDetalleFactura.Location = new Point(0, 0);
            dgvDetalleFactura.Margin = new Padding(2);
            dgvDetalleFactura.Name = "dgvDetalleFactura";
            dgvDetalleFactura.RowHeadersWidth = 51;
            dgvDetalleFactura.RowTemplate.Height = 35;
            dgvDetalleFactura.Size = new Size(1571, 752);
            dgvDetalleFactura.TabIndex = 0;
            dgvDetalleFactura.CellContentClick += dgvDetalleFactura_CellContentClick_1;
            // 
            // labelTitulo
            // 
            labelTitulo.BackColor = Color.Firebrick;
            labelTitulo.Dock = DockStyle.Top;
            labelTitulo.Font = new Font("Showcard Gothic", 26.25F);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(0, 0);
            labelTitulo.Margin = new Padding(2, 0, 2, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(1639, 104);
            labelTitulo.TabIndex = 1;
            labelTitulo.Text = "DETALLES DE FACTURA";
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            labelTitulo.Click += labelTitulo_Click;
            // 
            // DetalleFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panel1);
            Controls.Add(labelTitulo);
            Margin = new Padding(2);
            Name = "DetalleFactura";
            Size = new Size(1639, 948);
            Load += DetalleFactura_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).EndInit();
            ResumeLayout(false);
        }
    }
}
