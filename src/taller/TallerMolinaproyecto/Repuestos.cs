using System;
using System.Data;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class Repuestos : UserControl
    {
        public Repuestos()
        {
            InitializeComponent();

            // Conectar eventos (SIN TOCAR EL DISEÑO)
            btnGuardar.Click += btnGuardar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnBuscar.Click += btnBuscar_Click;
        }

        private int repuestoSeleccionadoID = 0;

        private void Repuestos_Load(object sender, EventArgs e)
        {
            CargarRepuestos();
        }

        // ==========================
        // CARGAR TABLA
        // ==========================
        private void CargarRepuestos()
        {
            try
            {
                string sql = "SELECT RepuestoID, Nombre, Categoria, Precio, Stock, Activo FROM REPUESTOS";
                dgvRepuestos.DataSource = DBHelper.Query(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar repuestos:\n" + ex.Message);
            }
        }

        // ==========================
        // BOTÓN NUEVO
        // ==========================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            repuestoSeleccionadoID = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            numPrecio.Value = 0;
            numStock.Value = 0;
        }

        // ==========================
        // GUARDAR / ACTUALIZAR
        // ==========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string categoria = txtDescripcion.Text.Trim();
                decimal precio = numPrecio.Value;
                int stock = (int)numStock.Value;

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Debe escribir un nombre.");
                    return;
                }

                if (precio <= 0)
                {
                    MessageBox.Show("Precio inválido.");
                    return;
                }

                if (repuestoSeleccionadoID == 0)
                {
                    // INSERTAR
                    string sql = @"
                        INSERT INTO REPUESTOS (Nombre, Categoria, Precio, Stock, Activo)
                        VALUES (@n, @c, @p, @s, 1)";

                    DBHelper.ExecNonQuery(sql,
                        DBHelper.P("@n", nombre),
                        DBHelper.P("@c", categoria),
                        DBHelper.P("@p", precio),
                        DBHelper.P("@s", stock)
                    );

                    MessageBox.Show("Repuesto registrado correctamente.");
                }
                else
                {
                    // ACTUALIZAR
                    string sql = @"
                        UPDATE REPUESTOS
                        SET Nombre=@n, Categoria=@c, Precio=@p, Stock=@s
                        WHERE RepuestoID=@id";

                    DBHelper.ExecNonQuery(sql,
                        DBHelper.P("@n", nombre),
                        DBHelper.P("@c", categoria),
                        DBHelper.P("@p", precio),
                        DBHelper.P("@s", stock),
                        DBHelper.P("@id", repuestoSeleccionadoID)
                    );

                    MessageBox.Show("Repuesto actualizado.");
                }

                CargarRepuestos();
                btnNuevo_Click(null, null); // Limpiar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar:\n" + ex.Message);
            }
        }

        // ==========================
        // SELECCIONAR FILA
        // ==========================
        private void dgvRepuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvRepuestos.Rows[e.RowIndex];

            repuestoSeleccionadoID = Convert.ToInt32(row.Cells["RepuestoID"].Value);
            txtNombre.Text = row.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = row.Cells["Categoria"].Value.ToString();
            numPrecio.Value = Convert.ToDecimal(row.Cells["Precio"].Value);
            numStock.Value = Convert.ToInt32(row.Cells["Stock"].Value);
        }

        // ==========================
        // ELIMINAR
        // ==========================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (repuestoSeleccionadoID == 0)
            {
                MessageBox.Show("Debe seleccionar un repuesto para eliminar.");
                return;
            }

            try
            {
                string sql = "DELETE FROM REPUESTOS WHERE RepuestoID = @id";

                DBHelper.ExecNonQuery(sql,
                    DBHelper.P("@id", repuestoSeleccionadoID)
                );

                MessageBox.Show("Repuesto eliminado.");
                CargarRepuestos();
                btnNuevo_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar:\n" + ex.Message);
            }
        }

        // ==========================
        // BUSCAR
        // ==========================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string buscar = txtBuscar.Text.Trim();
                string sql = "SELECT * FROM REPUESTOS WHERE Nombre LIKE @bus";

                dgvRepuestos.DataSource = DBHelper.Query(sql,
                    DBHelper.P("@bus", "%" + buscar + "%")
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en búsqueda:\n" + ex.Message);
            }
        }
    }
}
