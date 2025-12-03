using System;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class FormRegistrarPago : Form
    {
        private int empleadoID;

        public FormRegistrarPago()
        {
            InitializeComponent();
        }

        private void FormRegistrarPago_Load(object sender, EventArgs e)
        {
            // Métodos de pago
            cmbMetodo.Items.Clear();
            cmbMetodo.Items.AddRange(new string[] { "Efectivo", "Transferencia", "Depósito", "Cheque", "Otro" });
            cmbMetodo.SelectedIndex = 0;

            // Recibir ID de empleado
            if (this.Tag != null && int.TryParse(this.Tag.ToString(), out int id))
            {
                empleadoID = id;
                txtEmpleadoID.Text = empleadoID.ToString();
            }
            else
                empleadoID = 0;

            // Generar código único para la factura tipo PAGO
            string codigo = $"PAG-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";
            txtCodigoFactura.Text = codigo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (empleadoID <= 0 || !DBHelper.EmpleadoExiste(empleadoID))
                {
                    MessageBox.Show("Empleado inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numMonto.Value <= 0)
                {
                    MessageBox.Show("Monto inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string codigoFactura = txtCodigoFactura.Text.Trim();
                decimal monto = numMonto.Value;

                var (facturaID, codigo) = DBHelper.CrearFacturaPago(empleadoID, codigoFactura);

                string sqlPago = @"
                    INSERT INTO PAGOS (FacturaID, EmpleadoID, NumeroCuenta, Metodo, Monto, FechaPago, Observacion)
                    VALUES (@Fac, @Emp, @Cuenta, @Metodo, @Monto, GETDATE(), @Obs);";

                DBHelper.ExecNonQuery(sqlPago,
                    DBHelper.P("@Fac", facturaID),
                    DBHelper.P("@Emp", empleadoID),
                    DBHelper.P("@Cuenta", txtNumeroCuenta.Text.Trim()),
                    DBHelper.P("@Metodo", cmbMetodo.Text.Trim()),
                    DBHelper.P("@Monto", monto),
                    DBHelper.P("@Obs", txtObservacion.Text.Trim()));

                DBHelper.ExecNonQuery("UPDATE FACTURAS SET Total=@t WHERE FacturaID=@f;",
                    DBHelper.P("@t", monto), DBHelper.P("@f", facturaID));

                MessageBox.Show($"✅ Pago registrado correctamente.\nFactura: {codigo}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al guardar el pago:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCodigoFactura_Click(object sender, EventArgs e)
        {

        }
    }
}
