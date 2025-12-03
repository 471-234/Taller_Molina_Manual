using System;
using System.Data;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class Inventario : UserControl
    {
        public bool TopLevel { get; internal set; }

        public Inventario()
        {
            InitializeComponent();

            // 🔹 AQUÍ conectamos los botones a sus eventos
            bningresar.Click += bningresar_Click;
            // si luego haces eliminar, puedes usar:
            // bneliminar.Click += bneliminar_Click;
        }

        // Se llama al cargar el UserControl (ya está conectado en el Designer)
        private void Inventario_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            CargarInventario();
        }

        // ===========================
        // Cargar inventario desde SQL
        // ===========================
        private void CargarInventario()
        {
            try
            {
                string sql = @"
                    SELECT I.InventarioID,
                           I.RepuestoID,
                           R.Nombre AS NombreRepuesto,
                           I.Cantidad,
                           I.CostoPromedio,
                           I.FechaActualizacion
                    FROM INVENTARIO I
                    INNER JOIN REPUESTOS R ON I.RepuestoID = R.RepuestoID
                    ORDER BY I.InventarioID DESC";

                dataGridView1.DataSource = DBHelper.Query(sql);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario:\n" + ex.Message);
            }
        }

        // ===========================
        // INGRESAR REGISTRO
        // ===========================
        private void bningresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Nombre del repuesto
                string nombreRep = txtrepuesto.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombreRep))
                {
                    MessageBox.Show("Debe escribir el nombre EXACTO del repuesto.");
                    return;
                }

                // Buscar el RepuestoID real en la tabla REPUESTOS
                string sqlBuscar = "SELECT RepuestoID FROM REPUESTOS WHERE Nombre = @n";
                object result = DBHelper.ExecScalar(sqlBuscar, DBHelper.P("@n", nombreRep));

                if (result == null)
                {
                    MessageBox.Show("No existe un repuesto con ese nombre en la tabla REPUESTOS.");
                    return;
                }

                int repuestoID = Convert.ToInt32(result);

                // Cantidad
                if (!int.TryParse(txtcanti.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida.");
                    return;
                }

                // Insertar en INVENTARIO
                string sqlInsert = @"
                    INSERT INTO INVENTARIO (RepuestoID, Cantidad, CostoPromedio, FechaActualizacion)
                    VALUES (@rep, @cant, 0, @fec);";

                DBHelper.ExecNonQuery(sqlInsert,
                    DBHelper.P("@rep", repuestoID),
                    DBHelper.P("@cant", cantidad),
                    DBHelper.P("@fec", dateTimePicker1.Value));

                MessageBox.Show("Inventario agregado correctamente.");

                // Limpiar campos
                // (txtrepuesto NO lo limpio si quieres seguir metiendo el mismo repuesto)
                txtcanti.Clear();
                txtminimo.Clear();

                // Recargar grilla
                CargarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar inventario:\n" + ex.Message);
            }
        }
    }
}
