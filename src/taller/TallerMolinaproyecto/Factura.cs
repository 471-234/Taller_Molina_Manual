using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System.Data;

namespace TallerMolinaproyecto
{
    public partial class Factura : UserControl
    {
        public Factura()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            DoubleBuffered = true;
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            // Configuración DataGridView
            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ComboBox de servicios
            cmbServicio.Items.Clear();
            cmbServicio.Items.AddRange(new[] { "Revisión", "Mecánica", "Pintura" });

            // Encabezado
            header.BackColor = Color.Firebrick;
            lblTitulo.Text = "FACTURACIÓN";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Black", 24, FontStyle.Bold);

            // Cargar logo
            var logoPath = Path.Combine(Application.StartupPath, "Assets", "logo_taller.png");
            if (File.Exists(logoPath))
            {
                picLogo.Image = System.Drawing.Image.FromFile(logoPath);
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }

           // GenerarNumeroFactura();
        }


        private void GenerarNumeroFactura()
        {
            try
            {
                var lastIdObj = DBHelper.ExecScalar("SELECT COALESCE(MAX(FacturaID),0) FROM FACTURAS");
                int nextId = Convert.ToInt32(lastIdObj ?? 0) + 1;
                txtNumeroFactura.Text = nextId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar número de factura: " + ex.Message);
                txtNumeroFactura.Text = "1"; // Valor por defecto si falla
            }
        }


        private void txtNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumeroFactura.Text, out int facturaID))
                CargarDetalleFactura(facturaID);
            else
                dgvDetalle.DataSource = null;
        }

        private void CargarDetalleFactura(int facturaID)
        {
            try
            {
                using var conn = DatabaseSmartBuilder.GetConnection();
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT d.DetalleID, s.Nombre AS Servicio, d.Cantidad, d.Subtotal
                    FROM DETALLE_FACTURA d
                    LEFT JOIN SERVICIOS s ON s.ServicioID=d.ServicioID
                    WHERE d.FacturaID=@f
                    ORDER BY d.DetalleID DESC";
                cmd.Parameters.AddWithValue("@f", facturaID);

                var dt = new DataTable();
                using var adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);

                dgvDetalle.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    decimal total = dt.AsEnumerable().Sum(r => r.Field<decimal>("Subtotal"));
                    lblTotal.Text = $"TOTAL: {total:C2}";
                }
                else
                {
                    lblTotal.Text = "TOTAL: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles de factura: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumeroFactura.Text, out int facturaID))
            {
                MessageBox.Show("Ingrese un número de factura válido.");
                return;
            }

            string servicioCat = cmbServicio.Text.Trim();
            if (string.IsNullOrEmpty(servicioCat))
            {
                MessageBox.Show("Seleccione un servicio.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cant))
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }

            try
            {
                using var conn = DatabaseSmartBuilder.GetConnection();
                conn.Open();

                using var cmd = conn.CreateCommand();

                // =========================
                // 1) Verificar o crear factura
                // =========================
                cmd.CommandText = "SELECT COUNT(*) FROM FACTURAS WHERE FacturaID=@f";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@f", facturaID);

                long count = (long)cmd.ExecuteScalar();
                if (count == 0)
                {
                    // Insertar nueva factura (sin especificar FacturaID, MySQL auto_increment lo genera)
                    cmd.CommandText = @"INSERT INTO FACTURAS(Codigo, Fecha, Total) 
                                VALUES(@c, NOW(), 0)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@c", "FAC-" + facturaID.ToString("0000"));
                    cmd.ExecuteNonQuery();

                    // Obtener el último ID generado
                    facturaID = (int)cmd.LastInsertedId;
                }

                // =========================
                // 2) Obtener o crear ServicioID
                // =========================
                cmd.CommandText = "SELECT ServicioID FROM SERVICIOS WHERE Nombre=@n";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@n", servicioCat);

                object result = cmd.ExecuteScalar();
                int servicioID;
                if (result == null)
                {
                    cmd.CommandText = "INSERT INTO SERVICIOS(Nombre, Descripcion, Precio) VALUES(@n, '', 0)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@n", servicioCat);
                    cmd.ExecuteNonQuery();

                    servicioID = (int)cmd.LastInsertedId;
                }
                else
                {
                    servicioID = Convert.ToInt32(result);
                }

                // =========================
                // 3) Insertar detalle
                // =========================
                decimal subtotal = precio * cant;
                cmd.CommandText = @"INSERT INTO DETALLE_FACTURA(FacturaID, ServicioID, Cantidad, PrecioUnitario, Subtotal)
                            VALUES(@f, @s, @c, @p, @sub)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@f", facturaID);
                cmd.Parameters.AddWithValue("@s", servicioID);
                cmd.Parameters.AddWithValue("@c", cant);
                cmd.Parameters.AddWithValue("@p", precio);
                cmd.Parameters.AddWithValue("@sub", subtotal);
                cmd.ExecuteNonQuery();

                // =========================
                // 4) Actualizar total de la factura
                // =========================
                cmd.CommandText = "SELECT COALESCE(SUM(Subtotal),0) FROM DETALLE_FACTURA WHERE FacturaID=@f";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@f", facturaID);
                decimal total = Convert.ToDecimal(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE FACTURAS SET Total=@t WHERE FacturaID=@f";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@t", total);
                cmd.Parameters.AddWithValue("@f", facturaID);
                cmd.ExecuteNonQuery();

                // =========================
                // 5) Recargar grid
                // =========================
                CargarDetalleFactura(facturaID);

                // =========================
                // 6) Limpiar campos
                // =========================
                txtPrecio.Clear();
                txtCantidad.Clear();
                cmbServicio.SelectedIndex = -1;

                MessageBox.Show("Detalle agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumeroFactura.Text, out int facturaID))
            {
                MessageBox.Show("Ingrese un número de factura válido.");
                return;
            }

            if (dgvDetalle.DataSource == null || dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay elementos para imprimir.");
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Factura_{facturaID}_{DateTime.Now:yyyyMMddHHmm}.pdf"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    GenerarPdfFactura(sfd.FileName, facturaID, txtCodigoIngreso.Text.Trim());
                    MessageBox.Show("PDF generado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========================= PDF =========================
        private void GenerarPdfFactura(string filePath, int facturaId, string codigoIngreso)
        {
            var dt = (DataTable)dgvDetalle.DataSource;

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var doc = new iTextSharp.text.Document(PageSize.A4, 36, 36, 36, 36);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                var title = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                var label = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                var normal = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                iTextSharp.text.Image logo = TryLoadPdfImage(Path.Combine(Application.StartupPath, "Assets", "logo_taller.png"));
                PdfPTable headerTbl = new PdfPTable(2) { WidthPercentage = 100 };
                headerTbl.SetWidths(new float[] { 1.2f, 2.8f });

                PdfPCell cLogo = new PdfPCell { Border = 0, Padding = 4 };
                if (logo != null)
                {
                    logo.ScaleToFit(110f, 60f);
                    cLogo.AddElement(logo);
                }
                headerTbl.AddCell(cLogo);

                PdfPCell cText = new PdfPCell { Border = 0, Padding = 4 };
                cText.AddElement(new Paragraph("TALLER MOLINA", title));
                cText.AddElement(new Paragraph("Dirección: [tu dirección aquí]\nTeléfono: [tu teléfono]\nEmail: [tu email]", normal));
                headerTbl.AddCell(cText);

                doc.Add(headerTbl);
                doc.Add(new Paragraph(" "));

                // Info factura
                PdfPTable info = new PdfPTable(4) { WidthPercentage = 100 };
                info.SetWidths(new float[] { 1, 1, 1, 1 });
                AddInfo(info, "Factura Nº", facturaId.ToString(), label, normal);
                AddInfo(info, "Fecha", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), label, normal);
                AddInfo(info, "Código Ingreso", string.IsNullOrWhiteSpace(codigoIngreso) ? "-" : codigoIngreso, label, normal);
                AddInfo(info, "Atendido por", string.IsNullOrWhiteSpace(AppState.UsuarioNombre) ? "admin" : AppState.UsuarioNombre, label, normal);

                doc.Add(info);
                doc.Add(new Paragraph(" "));

                // Tabla de detalles
                PdfPTable tbl = new PdfPTable(4) { WidthPercentage = 100 };
                tbl.SetWidths(new float[] { 5, 2, 2, 2 });
                AddHeader(tbl, "Servicio");
                AddHeader(tbl, "Cantidad");
                AddHeader(tbl, "Precio");
                AddHeader(tbl, "Subtotal");

                decimal total = 0;
                foreach (DataRow r in dt.Rows)
                {
                    string servicio = Convert.ToString(r["Servicio"]);
                    int cantidad = Convert.ToInt32(r["Cantidad"]);
                    decimal subtotal = Convert.ToDecimal(r["Subtotal"]);
                    decimal precio = cantidad > 0 ? subtotal / cantidad : 0;

                    tbl.AddCell(new PdfPCell(new Phrase(servicio, normal)));
                    tbl.AddCell(new PdfPCell(new Phrase(cantidad.ToString(), normal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tbl.AddCell(new PdfPCell(new Phrase(precio.ToString("C2"), normal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tbl.AddCell(new PdfPCell(new Phrase(subtotal.ToString("C2"), normal)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                    total += subtotal;
                }

                doc.Add(tbl);
                doc.Add(new Paragraph(" "));

                // Total
                PdfPTable tot = new PdfPTable(2) { WidthPercentage = 40, HorizontalAlignment = Element.ALIGN_RIGHT };
                tot.SetWidths(new float[] { 1, 1 });
                tot.AddCell(new PdfPCell(new Phrase("TOTAL", label)) { BackgroundColor = new BaseColor(220, 220, 220) });
                tot.AddCell(new PdfPCell(new Phrase(total.ToString("C2"), label)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = new BaseColor(220, 220, 220) });
                doc.Add(tot);

                doc.Add(new Paragraph("\nGracias por confiar en Taller Molina.", normal));
                doc.Close();
            }
        }

        private static iTextSharp.text.Image TryLoadPdfImage(string path)
        {
            if (!File.Exists(path)) return null;
            byte[] bytes = File.ReadAllBytes(path);
            return iTextSharp.text.Image.GetInstance(bytes);
        }

        private static void AddHeader(PdfPTable t, string text)
        {
            var bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            var font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            var cell = new PdfPCell(new Phrase(text, font))
            {
                BackgroundColor = new BaseColor(178, 34, 34),
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 6
            };
            t.AddCell(cell);
        }

        private static void AddInfo(PdfPTable t, string k, string v, iTextSharp.text.Font fk, iTextSharp.text.Font fv)
        {
            t.AddCell(new PdfPCell(new Phrase(k, fk)) { BackgroundColor = new BaseColor(245, 245, 245) });
            t.AddCell(new PdfPCell(new Phrase(v, fv)));
        }

        private void lblServicio_Click(object sender, EventArgs e)
        {

        }

        private void grpDatos_Enter(object sender, EventArgs e)
        {

        }
    }
}
