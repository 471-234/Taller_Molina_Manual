using System;
using System.Data;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class ServicioRevision : UserControl
    {
        public ServicioRevision()
        {
            InitializeComponent();
            CargarServicios();
        }

        private void CargarServicios()
        {
            string sql = @"
                SELECT ServicioID, Nombre, Descripcion, Precio
                FROM Servicios
                WHERE Categoria='Revision'";

            dgvRevision.DataSource = DBHelper.Query(sql);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string desc = txtDescripcion.Text.Trim();
            decimal precio = decimal.TryParse(txtPrecio.Text, out decimal p) ? p : 0;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese un nombre válido");
                return;
            }

            DBHelper.ExecNonQuery(
                @"INSERT INTO Servicios (Nombre, Descripcion, Precio, Categoria)
                  VALUES (@n, @d, @p, 'Revision')",
                DBHelper.P("@n", nombre),
                DBHelper.P("@d", desc),
                DBHelper.P("@p", precio)
            );

            CargarServicios();
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRevision.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvRevision.SelectedRows[0].Cells["ServicioID"].Value);
            string nombre = txtNombre.Text.Trim();
            string desc = txtDescripcion.Text.Trim();
            decimal precio = decimal.TryParse(txtPrecio.Text, out decimal p) ? p : 0;

            DBHelper.ExecNonQuery(
                @"UPDATE Servicios 
                  SET Nombre=@n, Descripcion=@d, Precio=@p
                  WHERE ServicioID=@id AND Categoria='Revision'",
                DBHelper.P("@n", nombre),
                DBHelper.P("@d", desc),
                DBHelper.P("@p", precio),
                DBHelper.P("@id", id)
            );

            CargarServicios();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRevision.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvRevision.SelectedRows[0].Cells["ServicioID"].Value);

            DBHelper.ExecNonQuery(
                "DELETE FROM Servicios WHERE ServicioID=@id AND Categoria='Revision'",
                DBHelper.P("@id", id));

            CargarServicios();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarServicios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string term = txtBuscar.Text.Trim();

            dgvRevision.DataSource = DBHelper.Query(
                @"SELECT ServicioID, Nombre, Descripcion, Precio
                  FROM Servicios 
                  WHERE Categoria='Revision' AND Nombre LIKE '%' + @t + '%'",
                  DBHelper.P("@t", term));
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtBuscar.Clear();
        }
    }
}
