using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TallerMolinaproyecto
{
    public partial class UC_BuscadorGeneral : UserControl
    {
        // Botones de exportación creados dinámicamente (no en designer)
        private Button btnPDF;
        private Button btnExcel;

        public UC_BuscadorGeneral()
        {
            InitializeComponent();
        }

        private void UC_BuscadorGeneral_Load(object sender, EventArgs e)
        {
            // Opciones de búsqueda (ya depuradas)
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[]
            {
                "Clientes",
                "Roles",
                "Empleados",
                "Facturas",
                "Detalles de Factura",
                "Pagos",
                "Inventario",
                "Repuestos",
                "Servicio Mecánica",
                "Servicio Pintura",
                "Servicio Revisión"
            });

            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string term = txtTermino.Text.Trim();
            string cat = cmbCategoria.Text;
            DataTable dt = new();

            try
            {
                switch (cat)
                {
                    case "Clientes":
                        dt = DBHelper.Query(@"
                            SELECT ClienteID, Nombre, Telefono, Correo, Direccion, FechaRegistro
                            FROM Clientes
                            WHERE @t = '' OR Nombre LIKE CONCAT('%',@t,'%');",
                            DBHelper.P("@t", term));
                        break;

                    case "Roles":
                        dt = DBHelper.Query(@"
                            SELECT RolID, Nombre
                            FROM Roles
                            WHERE @t = '' OR Nombre LIKE CONCAT('%',@t,'%');",
                            DBHelper.P("@t", term));
                        break;

                    case "Empleados":
                        dt = DBHelper.Query(@"
                            SELECT EmpleadoID, Nombre, Telefono, Correo, RolID, Usuario, Area, Activo
                            FROM Empleados
                            WHERE @t = '' OR Nombre LIKE CONCAT('%',@t,'%') OR Usuario LIKE CONCAT('%',@t,'%');",
                            DBHelper.P("@t", term));
                        break;

                    case "Facturas":
                        int.TryParse(term, out int fId);
                        dt = DBHelper.Query(@"
                            SELECT FacturaID, ClienteID, EmpleadoID, Fecha, Total
                            FROM Facturas
                            WHERE @t = '' OR FacturaID=@id;",
                            DBHelper.P("@t", term), DBHelper.P("@id", fId));
                        break;

                    case "Detalles de Factura":
                        dt = DBHelper.Query(@"
                            SELECT DetalleID, FacturaID, ServicioID, RepuestoID, Cantidad, Subtotal
                            FROM Detalle_Factura
                            WHERE @t = '' OR FacturaID LIKE CONCAT('%',@t,'%');",
                            DBHelper.P("@t", term));
                        break;

                    case "Pagos":
                        dt = DBHelper.Query(@"
                            SELECT PagoID, FacturaID, Monto, FechaPago
                            FROM Pagos
                            WHERE @t = '' OR FacturaID LIKE CONCAT('%',@t,'%');",
                            DBHelper.P("@t", term));
                        break;

                    case "Inventario":
                        dt = DBHelper.Query(@"
                            SELECT RepuestoID, Nombre, Cantidad, StockMinimo, Categoria
                            FROM Inventario
                            WHERE @t = '' OR Nombre LIKE CONCAT('%',@t,'%');",
                            DBHelper.P("@t", term));
                        break;

                    case "Repuestos":
                        dt = DBHelper.Query(@"
                            SELECT RepuestoID, Nombre, Cantidad, Categoria
                            FROM Inventario
                            WHERE @t = '' OR Categoria LIKE CONCAT('%',@t,'%');",
                            DBHelper.P("@t", term));
                        break;

                    case "Servicio Mecánica":
                        dt = DBHelper.Query(@"
                            SELECT ServicioID, Nombre, Descripcion, Precio
                            FROM Servicios
                            WHERE Categoria='Mecanica' AND (@t = '' OR Nombre LIKE CONCAT('%',@t,'%'));",
                            DBHelper.P("@t", term));
                        break;

                    case "Servicio Pintura":
                        dt = DBHelper.Query(@"
                            SELECT ServicioID, Nombre, Descripcion, Precio
                            FROM Servicios
                            WHERE Categoria='Pintura' AND (@t = '' OR Nombre LIKE CONCAT('%',@t,'%'));",
                            DBHelper.P("@t", term));
                        break;

                    case "Servicio Revisión":
                        dt = DBHelper.Query(@"
                            SELECT ServicioID, Nombre, Descripcion, Precio
                            FROM Servicios
                            WHERE Categoria='Revision' AND (@t = '' OR Nombre LIKE CONCAT('%',@t,'%'));",
                            DBHelper.P("@t", term));
                        break;
                }

                dgvResultados.DataSource = dt;
                dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvResultados.ReadOnly = true;
                dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvResultados.MultiSelect = true; // permite exportar solo seleccionadas
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar búsqueda: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // EXPORTAR: muestra botones PDF/Excel debajo del botón
        // =====================================================
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear solo una vez
                if (btnPDF == null)
                {
                    btnPDF = new Button
                    {
                        Text = "📄 PDF",
                        Width = 100,
                        Height = 34
                    };
                    btnPDF.Click += (s, ev) => ExportarPDF();
                    this.Controls.Add(btnPDF);
                }

                if (btnExcel == null)
                {
                    btnExcel = new Button
                    {
                        Text = "📘 Excel",
                        Width = 100,
                        Height = 34
                    };
                    btnExcel.Click += (s, ev) => ExportarExcel();
                    this.Controls.Add(btnExcel);
                }

                // Posicionar debajo de btnExportar (del diseñador)
                var origin = btnExportar.Parent.PointToScreen(btnExportar.Location);
                var local = this.PointToClient(origin);

                btnPDF.Location = new Point(local.X, local.Y + btnExportar.Height + 6);
                btnExcel.Location = new Point(local.X + btnPDF.Width + 8, local.Y + btnExportar.Height + 6);

                btnPDF.BringToFront();
                btnExcel.BringToFront();

                // Mostrar/ocultar tipo toggle
                bool show = !btnPDF.Visible || !btnExcel.Visible;
                btnPDF.Visible = show;
                btnExcel.Visible = show;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo mostrar las opciones de exportación: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========= Helpers iText (evita conflicto con System.Drawing.Font) =========
        private static iTextSharp.text.Font MakeFont(float size, int style = iTextSharp.text.Font.NORMAL)
        {
            var bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            return new iTextSharp.text.Font(bf, size, style);
        }

        // ======================= PDF ==========================
        private void ExportarPDF()
        {
            if (dgvResultados.DataSource == null)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Tabla_{cmbCategoria.Text}_{DateTime.Now:yyyyMMddHHmm}.pdf"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            // Construir DataTable a exportar: si hay filas seleccionadas, solo esas
            DataTable dtBase = (DataTable)dgvResultados.DataSource;
            DataTable dt = dtBase.Clone();

            if (dgvResultados.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dgvResultados.SelectedRows)
                {
                    if (r.DataBoundItem is DataRowView drv)
                        dt.ImportRow(drv.Row);
                }
            }
            else
            {
                dt = dtBase;
            }

            try
            {
                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                {
                    var doc = new Document(PageSize.A4.Rotate(), 28, 28, 28, 28);
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    // Encabezado
                    var titulo = new Paragraph($"Taller Molina - {cmbCategoria.Text}", MakeFont(16f, iTextSharp.text.Font.BOLD))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 6
                    };
                    var fecha = new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}", MakeFont(9f, iTextSharp.text.Font.ITALIC))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 12
                    };
                    doc.Add(titulo);
                    doc.Add(fecha);

                    // Tabla
                    PdfPTable table = new PdfPTable(dt.Columns.Count) { WidthPercentage = 100 };

                    // Cabeceras
                    foreach (DataColumn col in dt.Columns)
                    {
                        var th = new PdfPCell(new Phrase(col.ColumnName, MakeFont(10f, iTextSharp.text.Font.BOLD)))
                        {
                            BackgroundColor = new BaseColor(230, 230, 230),
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5f
                        };
                        table.AddCell(th);
                    }

                    // Filas
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            var td = new PdfPCell(new Phrase(cell?.ToString() ?? "", MakeFont(10f)))
                            {
                                Padding = 4f
                            };
                            table.AddCell(td);
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }

                MessageBox.Show("Archivo PDF creado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================= Excel ==========================
        // ======================= Excel ==========================
        private void ExportarExcel()
        {
            if (dgvResultados.DataSource == null)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                FileName = $"Tabla_{cmbCategoria.Text}_{DateTime.Now:yyyyMMddHHmm}.xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            // Construir DataTable a exportar (solo seleccionadas si hay)
            DataTable dtBase = (DataTable)dgvResultados.DataSource;
            DataTable dt = dtBase.Clone();

            if (dgvResultados.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dgvResultados.SelectedRows)
                {
                    if (r.DataBoundItem is DataRowView drv)
                        dt.ImportRow(drv.Row);
                }
            }
            else
            {
                dt = dtBase;
            }

            try
            {
                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(dt, $"{cmbCategoria.Text}");

                // Agregar encabezado manual arriba
                ws.Row(1).InsertRowsAbove(2); // ✅ corregido, ahora se usa Row()
                ws.Cell(1, 1).Value = $"Taller Molina - {cmbCategoria.Text}";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 16;

                ws.Cell(2, 1).Value = $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}";
                ws.Cell(2, 1).Style.Font.Italic = true;

                ws.Tables.First().ShowAutoFilter = true;
                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);

                MessageBox.Show("Archivo Excel creado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

