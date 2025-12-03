using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class Pagos : UserControl
    {
        public Pagos()
        {
            InitializeComponent();
            CargarPagos();
        }

        // =========================================================
        // MÉTODO PRINCIPAL PARA CARGAR LOS PAGOS DESDE LA BD
        // =========================================================
        private void CargarPagos()
        {
            try
            {
                string sql = @"
                    SELECT 
                        p.PagoID,
                        p.FacturaID,
                        f.Codigo AS CodigoFactura,
                        p.EmpleadoID,
                        p.NumeroCuenta,
                        p.Metodo,
                        p.Monto,
                        p.FechaPago,
                        p.Observacion
                    FROM PAGOS p
                    LEFT JOIN FACTURAS f ON p.FacturaID = f.FacturaID
                    ORDER BY p.PagoID DESC;";

                dgvPagos.DataSource = DBHelper.Query(sql);

                dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPagos.ReadOnly = true;
                dgvPagos.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error al cargar los pagos: " + ex.Message,
                                "Error de Carga",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // BOTÓN AGREGAR PAGO
        // =========================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmpleadoID.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del empleado antes de agregar un pago.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtEmpleadoID.Text, out int empleadoID))
                {
                    MessageBox.Show("El ID del empleado debe ser un número válido.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var form = new FormRegistrarPago())
                {
                    form.Tag = empleadoID;
                    if (form.ShowDialog() == DialogResult.OK)
                        CargarPagos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al abrir el formulario de registro: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // BOTÓN EDITAR (método, monto y observación)
        // =========================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pago para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int pagoID = Convert.ToInt32(dgvPagos.CurrentRow.Cells["PagoID"].Value);
                string metodo = dgvPagos.CurrentRow.Cells["Metodo"].Value.ToString();
                decimal monto = Convert.ToDecimal(dgvPagos.CurrentRow.Cells["Monto"].Value);
                string observacion = dgvPagos.CurrentRow.Cells["Observacion"].Value.ToString();

                using (var form = new EditarPagoDialog(metodo, monto, observacion))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string sql = @"
                            UPDATE PAGOS
                            SET Metodo=@m, Monto=@mo, Observacion=@o
                            WHERE PagoID=@id;";

                        DBHelper.ExecNonQuery(sql,
                            DBHelper.P("@m", form.Metodo),
                            DBHelper.P("@mo", form.Monto),
                            DBHelper.P("@o", form.Observacion),
                            DBHelper.P("@id", pagoID));

                        MessageBox.Show("✅ Pago actualizado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPagos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al editar el pago:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // BOTÓN ELIMINAR
        // =========================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pago para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int pagoID = Convert.ToInt32(dgvPagos.CurrentRow.Cells["PagoID"].Value);
                int facturaID = Convert.ToInt32(dgvPagos.CurrentRow.Cells["FacturaID"].Value);
                string codigoFactura = dgvPagos.CurrentRow.Cells["CodigoFactura"].Value.ToString();

                var confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar este pago?\nEsto eliminará también la factura interna (PAG-) si aplica.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmar != DialogResult.Yes)
                    return;

                // 1️⃣ Eliminar de PAGOS
                DBHelper.ExecNonQuery("DELETE FROM PAGOS WHERE PagoID=@p;",
                    DBHelper.P("@p", pagoID));

                // 2️⃣ Si es una factura interna (PAG-), eliminar su detalle y factura
                if (!string.IsNullOrEmpty(codigoFactura) && codigoFactura.StartsWith("PAG-"))
                {
                    DBHelper.ExecNonQuery("DELETE FROM DETALLE_FACTURA WHERE FacturaID=@f;",
                        DBHelper.P("@f", facturaID));

                    DBHelper.ExecNonQuery("DELETE FROM FACTURAS WHERE FacturaID=@f;",
                        DBHelper.P("@f", facturaID));
                }

                MessageBox.Show("✅ Pago eliminado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al eliminar el pago:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // =========================================================
    // FORM PEQUEÑO PARA EDITAR PAGO
    // =========================================================
    internal class EditarPagoDialog : Form
    {
        private ComboBox cmbMetodo;
        private NumericUpDown numMonto;
        private TextBox txtObservacion;
        private Button btnGuardar, btnCancelar;

        public string Metodo => cmbMetodo.Text;
        public decimal Monto => numMonto.Value;
        public string Observacion => txtObservacion.Text;

        public EditarPagoDialog(string metodo, decimal monto, string obs)
        {
            Text = "Editar Pago";
            Width = 400;
            Height = 300;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = System.Drawing.Color.WhiteSmoke;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            var lbl1 = new Label { Text = "Método:", Left = 20, Top = 30, Width = 100 };
            cmbMetodo = new ComboBox
            {
                Left = 130,
                Top = 25,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbMetodo.Items.AddRange(new[] { "Efectivo", "Transferencia", "Depósito", "Cheque", "Otro" });
            cmbMetodo.SelectedItem = metodo;

            var lbl2 = new Label { Text = "Monto (L):", Left = 20, Top = 80, Width = 100 };
            numMonto = new NumericUpDown
            {
                Left = 130,
                Top = 75,
                Width = 200,
                DecimalPlaces = 2,
                Maximum = 1000000,
                Value = monto
            };

            var lbl3 = new Label { Text = "Observación:", Left = 20, Top = 130, Width = 100 };
            txtObservacion = new TextBox
            {
                Left = 130,
                Top = 125,
                Width = 200,
                Height = 60,
                Multiline = true,
                Text = obs
            };

            btnGuardar = new Button
            {
                Text = "Guardar",
                Left = 130,
                Top = 210,
                Width = 90,
                BackColor = System.Drawing.Color.Firebrick,
                ForeColor = System.Drawing.Color.White
            };
            btnGuardar.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Left = 240,
                Top = 210,
                Width = 90,
                BackColor = System.Drawing.Color.Gray,
                ForeColor = System.Drawing.Color.White
            };
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            Controls.AddRange(new Control[] {
                lbl1, cmbMetodo, lbl2, numMonto, lbl3, txtObservacion, btnGuardar, btnCancelar
            });
        }
    }
}
