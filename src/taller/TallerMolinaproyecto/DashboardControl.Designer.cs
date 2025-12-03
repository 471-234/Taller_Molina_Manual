namespace TallerMolinaproyecto
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código del Diseñador

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblJefe = new System.Windows.Forms.Label();
            this.panelCards = new System.Windows.Forms.Panel();

            this.cardClientes = this.CrearCard("Clientes", out this.lblClientes);
            this.cardEmpleados = this.CrearCard("Empleados", out this.lblEmpleados);
            this.cardFacturas = this.CrearCard("Facturas", out this.lblFacturas);
            this.cardPagos = this.CrearCard("Pagos", out this.lblPagos);

            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBars = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBars)).BeginInit();
            this.SuspendLayout();

            // ========== PANEL HEADER ==========
            this.panelHeader.BackColor = System.Drawing.Color.Firebrick;
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 80;

            this.lblTitulo.Text = "📊 PANEL GENERAL (BOA)";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 22);
            this.lblTitulo.AutoSize = true;

            // ========= JEFE ==========
            this.lblJefe.AutoSize = true;
            this.lblJefe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblJefe.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJefe.Location = new System.Drawing.Point(20, 90);

            // ========= CARDS ==========
            this.panelCards.Location = new System.Drawing.Point(0, 130);
            this.panelCards.Size = new System.Drawing.Size(1200, 150);

            this.cardClientes.Location = new System.Drawing.Point(40, 30);
            this.cardEmpleados.Location = new System.Drawing.Point(320, 30);
            this.cardFacturas.Location = new System.Drawing.Point(600, 30);
            this.cardPagos.Location = new System.Drawing.Point(880, 30);

            this.panelCards.Controls.Add(this.cardClientes);
            this.panelCards.Controls.Add(this.cardEmpleados);
            this.panelCards.Controls.Add(this.cardFacturas);
            this.panelCards.Controls.Add(this.cardPagos);

            // ========= PIE CHART ==========
            this.chartPie.Location = new System.Drawing.Point(30, 300);
            this.chartPie.Size = new System.Drawing.Size(500, 320);

            // ========= BAR CHART ==========
            this.chartBars.Location = new System.Drawing.Point(560, 300);
            this.chartBars.Size = new System.Drawing.Size(580, 320);

            // ========= CONTROL ==========
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblJefe);
            this.Controls.Add(this.panelCards);
            this.Controls.Add(this.chartPie);
            this.Controls.Add(this.chartBars);

            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += DashboardControl_Load;

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblJefe;

        private System.Windows.Forms.Panel panelCards;
        private System.Windows.Forms.Panel cardClientes;
        private System.Windows.Forms.Panel cardEmpleados;
        private System.Windows.Forms.Panel cardFacturas;
        private System.Windows.Forms.Panel cardPagos;

        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Label lblFacturas;
        private System.Windows.Forms.Label lblPagos;

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBars;
    }
}
