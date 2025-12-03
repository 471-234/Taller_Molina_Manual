using System;
using System.Data;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class ServicioPintura : UserControl
    {
        public ServicioPintura()
        {
            InitializeComponent();
            CargarServicios();
        }

        private void CargarServicios()
        {
            dgvPintura.DataSource = DBHelper.Query(
                "SELECT ServicioID, Nombre, Descripcion, Precio FROM Servicios WHERE Categoria='Pintura'");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string desc = txtDescripcion.Text.Trim();
            decimal precio = decimal.TryParse(txtPrecio.Text, out decimal p) ? p : 0;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Complete el nombre del servicio.");
                return;
            }

            // Insertar servicio
            DBHelper.ExecNonQuery(
                @"INSERT INTO Servicios(Nombre,Descripcion,Precio,Categoria)
                  VALUES(@n,@d,@p,'Pintura')",
                DBHelper.P("@n", nombre),
                DBHelper.P("@d", desc),
                DBHelper.P("@p", precio));

            CargarServicios();
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPintura.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvPintura.SelectedRows[0].Cells["ServicioID"].Value);

            string nombre = txtNombre.Text.Trim();
            string desc = txtDescripcion.Text.Trim();
            decimal precio = decimal.TryParse(txtPrecio.Text, out decimal p) ? p : 0;

            DBHelper.ExecNonQuery(
                @"UPDATE Servicios SET Nombre=@n,Descripcion=@d,Precio=@p
                  WHERE ServicioID=@id AND Categoria='Pintura'",
                DBHelper.P("@n", nombre),
                DBHelper.P("@d", desc),
                DBHelper.P("@p", precio),
                DBHelper.P("@id", id));

            CargarServicios();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPintura.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvPintura.SelectedRows[0].Cells["ServicioID"].Value);

            // Eliminar SOLO del servicio
            DBHelper.ExecNonQuery("DELETE FROM Servicios WHERE ServicioID=@id", DBHelper.P("@id", id));

            CargarServicios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPintura.DataSource = DBHelper.Query(
                @"SELECT ServicioID,Nombre,Descripcion,Precio 
                  FROM Servicios 
                  WHERE Categoria='Pintura' AND Nombre LIKE CONCAT('%',@t,'%')",
                DBHelper.P("@t", txtBuscar.Text.Trim()));
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtBuscar.Clear();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarServicios();
        }
    }
}
