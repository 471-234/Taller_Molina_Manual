using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class DetalleFactura : UserControl
    {
        public DetalleFactura()
        {
            InitializeComponent();
            CargarDetalleFactura(); // carga todos los registros al iniciar
            ConfigurarDataGridView();
        }

        // MÉTODO PRINCIPAL
        // =========================================================
        // MÉTODO PRINCIPAL PARA CARGAR LOS DETALLES DE FACTURAS/PAGOS
        // =========================================================

        private void ConfigurarDataGridView()
        {
            dgvDetalleFactura.Dock = DockStyle.Fill;                      // ocupa todo el UserControl
            dgvDetalleFactura.RowTemplate.Height = 35;                     // filas más altas
            dgvDetalleFactura.DefaultCellStyle.Font = new Font("Segoe UI", 12); // fuente de contenido
            dgvDetalleFactura.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold); // fuente headers
            dgvDetalleFactura.RowTemplate.DefaultCellStyle.Padding = new Padding(15); // espacio interno de celda
            dgvDetalleFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleFactura.ReadOnly = true;
            dgvDetalleFactura.AllowUserToAddRows = false;
            dgvDetalleFactura.AllowUserToDeleteRows = false;
        }




        public void CargarDetalleFactura(int? facturaID = null)
        {
            try
            {
                // Consulta unificada para facturas normales y pagos
                string sql = @"
-- FACTURAS NORMALES
SELECT 
    f.FacturaID,
    f.Codigo AS CodigoFactura,
    'VENTA / SERVICIO' AS TipoFactura,
    COALESCE(e.Nombre,'') AS Empleado,
    COALESCE(s.Nombre,'') AS Servicio,
    COALESCE(r.Nombre,'') AS Repuesto,
    COALESCE(d.Cantidad,0) AS Cantidad,
    COALESCE(d.PrecioUnitario,0) AS PrecioUnitario,
    COALESCE(d.Subtotal,0) AS Subtotal,
    COALESCE(p.Metodo,'') AS MetodoPago,
    COALESCE(p.Monto,0) AS MontoPago,
    COALESCE(p.FechaPago,f.Fecha) AS Fecha,
    COALESCE(p.Observacion,'') AS Observacion
FROM FACTURAS f
LEFT JOIN DETALLE_FACTURA d ON f.FacturaID = d.FacturaID
LEFT JOIN SERVICIOS s ON d.ServicioID = s.ServicioID
LEFT JOIN REPUESTOS r ON d.RepuestoID = r.RepuestoID
LEFT JOIN PAGOS p ON f.FacturaID = p.FacturaID
LEFT JOIN EMPLEADOS e ON p.EmpleadoID = e.EmpleadoID
WHERE f.Codigo NOT LIKE 'PAG-%'

UNION ALL

-- FACTURAS DE PAGO
SELECT
    f.FacturaID,
    f.Codigo AS CodigoFactura,
    'PAGO A EMPLEADO' AS TipoFactura,
    COALESCE(e.Nombre,'') AS Empleado,
    '' AS Servicio,
    '' AS Repuesto,
    0 AS Cantidad,
    0 AS PrecioUnitario,
    0 AS Subtotal,
    COALESCE(p.Metodo,'') AS MetodoPago,
    COALESCE(p.Monto,0) AS MontoPago,
    COALESCE(p.FechaPago,f.Fecha) AS Fecha,
    COALESCE(p.Observacion,'') AS Observacion
FROM FACTURAS f
LEFT JOIN PAGOS p ON f.FacturaID = p.FacturaID
LEFT JOIN EMPLEADOS e ON p.EmpleadoID = e.EmpleadoID
WHERE f.Codigo LIKE 'PAG-%'
";

                // Si se pasa facturaID, filtramos
                DataTable dt;
                if (facturaID.HasValue)
                {
                    dt = DBHelper.Query(sql + " AND f.FacturaID=@id ORDER BY FacturaID DESC",
                        DBHelper.P("@id", facturaID.Value));
                }
                else
                {
                    dt = DBHelper.Query(sql + " ORDER BY FacturaID DESC");
                }

                dgvDetalleFactura.DataSource = dt;

                // Configuración del DataGridView
                dgvDetalleFactura.ReadOnly = true;
                dgvDetalleFactura.AllowUserToAddRows = false;
                dgvDetalleFactura.AllowUserToDeleteRows = false;
                dgvDetalleFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDetalleFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvDetalleFactura.DefaultCellStyle.Font = new Font("Segoe UI", 11);
                dgvDetalleFactura.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                // Colorear filas tipo PAGO
                foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
                {
                    if (row.Cells["TipoFactura"].Value?.ToString() == "PAGO A EMPLEADO")
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

                labelTitulo.Text = "DETALLES Y COMPROBANTES DE FACTURAS / PAGOS";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "❌ Error al cargar los detalles:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvDetalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // opcional
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetalleFactura_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
