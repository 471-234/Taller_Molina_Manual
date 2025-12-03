#nullable disable
using System.Data;
using MySql.Data.MySqlClient;

namespace TallerMolinaproyecto
{
    public class VehiculosSearch : ISearchSource
    {
        private readonly string cs =
            "Server=localhost;Port=3306;Database=TallerMolina_v2;Uid=root;Pwd=kook21_;SslMode=None;";

        public string Title => "🔍 Buscar Vehículos en Venta";

        public IEnumerable<string> GetCategories()
            => new[] { "Placa", "Marca", "Modelo", "Anio", "Estado" };

        public DataTable Search(string category, string term)
        {
            string sql = $@"SELECT Placa, Marca, Modelo, Anio, Estado, Precio
                            FROM VEHICULOS_VENTA
                            WHERE {category} LIKE CONCAT('%', @term, '%')";

            using var cn = new MySqlConnection(cs);
            using var da = new MySqlDataAdapter(sql, cn);
            da.SelectCommand.Parameters.AddWithValue("@term", term);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void OnRowDoubleClick(DataGridViewRow row)
        {
            string placa = row.Cells["Placa"].Value.ToString();
            MessageBox.Show($"Vehículo seleccionado: {placa}");
        }
    }
}
