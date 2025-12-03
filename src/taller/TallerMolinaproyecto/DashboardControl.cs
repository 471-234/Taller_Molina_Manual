using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TallerMolinaproyecto
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            lblJefe.Text = "👨‍🔧 Jefe: Ronny Molina";
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                int clientes = Convert.ToInt32(DBHelper.ExecScalar("SELECT COUNT(*) FROM CLIENTES;") ?? 0);
                int empleados = Convert.ToInt32(DBHelper.ExecScalar("SELECT COUNT(*) FROM EMPLEADOS;") ?? 0);
                int facturas = Convert.ToInt32(DBHelper.ExecScalar("SELECT COUNT(*) FROM FACTURAS;") ?? 0);
                int pagos = Convert.ToInt32(DBHelper.ExecScalar("SELECT COUNT(*) FROM PAGOS;") ?? 0);

                int revision = Convert.ToInt32(DBHelper.ExecScalar("SELECT COUNT(*) FROM SERVICIOS WHERE Categoria='Revision';") ?? 0);
                int mecanica = Convert.ToInt32(DBHelper.ExecScalar("SELECT COUNT(*) FROM SERVICIOS WHERE Categoria='Mecanica';") ?? 0);
                int pintura = Convert.ToInt32(DBHelper.ExecScalar("SELECT COUNT(*) FROM SERVICIOS WHERE Categoria='Pintura';") ?? 0);

                lblClientes.Text = clientes.ToString();
                lblEmpleados.Text = empleados.ToString();
                lblFacturas.Text = facturas.ToString();
                lblPagos.Text = pagos.ToString();

                CargarGraficoCircular(revision, mecanica, pintura);
                CargarGraficoBarras(clientes, empleados, facturas, pagos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos del panel:\n" + ex.Message);
            }
        }

        // ============ PIE CHART ==================
        private void CargarGraficoCircular(int revision, int mecanica, int pintura)
        {
            chartPie.Series.Clear();
            chartPie.ChartAreas.Clear();
            chartPie.Legends.Clear();

            ChartArea area = new ChartArea("PieArea")
            {
                BackColor = Color.White
            };
            chartPie.ChartAreas.Add(area);

            Series serie = new Series("Servicios")
            {
                ChartType = SeriesChartType.Pie,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            serie["PieLabelStyle"] = "Outside";
            serie["PieLineColor"] = "Black";
            serie["PieDrawingStyle"] = "SoftEdge";

            serie.Points.AddXY("Revisión", revision);
            serie.Points.AddXY("Mecánica", mecanica);
            serie.Points.AddXY("Pintura", pintura);

            serie.Palette = ChartColorPalette.BrightPastel;

            chartPie.Series.Add(serie);

            chartPie.Legends.Add(new Legend("Legend")
            {
                Docking = Docking.Right,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            });
        }

        // ============ BAR CHART ==================
        private void CargarGraficoBarras(int clientes, int empleados, int facturas, int pagos)
        {
            chartBars.Series.Clear();
            chartBars.ChartAreas.Clear();

            ChartArea area = new ChartArea("BarsArea")
            {
                BackColor = Color.WhiteSmoke
            };

            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            chartBars.ChartAreas.Add(area);

            Series serie = new Series("Totales")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Firebrick,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            serie.Points.AddXY("Clientes", clientes);
            serie.Points.AddXY("Empleados", empleados);
            serie.Points.AddXY("Facturas", facturas);
            serie.Points.AddXY("Pagos", pagos);

            chartBars.Series.Add(serie);
        }

        // ============ CREAR CARD ==================
        private Panel CrearCard(string titulo, out Label lblValor)
        {
            Panel card = new Panel
            {
                BackColor = Color.White,
                Size = new Size(260, 110)
            };

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (Pen border = new Pen(Color.LightGray, 2))
                using (SolidBrush shadow = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(shadow,
                        new Rectangle(4, 4, card.Width - 8, card.Height - 8));

                    e.Graphics.DrawRectangle(border,
                        0, 0, card.Width - 2, card.Height - 2);
                }
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Firebrick,
                Location = new Point(12, 10),
                AutoSize = true
            };

            lblValor = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(12, 45),
                AutoSize = true
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblValor);

            return card;
        }
    }
}
