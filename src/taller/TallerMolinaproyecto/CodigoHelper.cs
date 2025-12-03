using System;
using System.Data;

namespace TallerMolinaproyecto
{
    public static class CodigoHelper
    {
        public static string Prefijo(string categoria)
        {
            return categoria.ToUpper() switch
            {
                "MECANICA" => "MEC",
                "PINTURA" => "PIN",
                "REVISION" => "REV",
                _ => "ING"
            };
        }

        public static string GenerarCodigo(string categoria)
        {
            string pfx = Prefijo(categoria);
            string sql = AppState.IsMySql
                ? "SELECT Codigo FROM Ingresos WHERE Codigo LIKE @pfx ORDER BY IngresoID DESC LIMIT 1;"
                : "SELECT TOP 1 Codigo FROM Ingresos WHERE Codigo LIKE @pfx ORDER BY IngresoID DESC;";

            var dt = DBHelper.Query(sql, DBHelper.P("@pfx", pfx + "-%"));
            int n = 1;

            if (dt.Rows.Count > 0)
            {
                var c = dt.Rows[0]["Codigo"].ToString() ?? "";
                var parts = c.Split('-');
                if (parts.Length >= 2 && int.TryParse(parts[^1], out int num))
                    n = num + 1;
            }

            return $"{pfx}-{n:0000}";
        }

        public static string CrearIngreso(string categoria, int servicioId, int? clienteId = null, string notas = null)
        {
            string codigo = GenerarCodigo(categoria);
            string sql = @"INSERT INTO Ingresos (Codigo, Categoria, ServicioID, ClienteID, Notas)
                           VALUES (@c, @cat, @s, @cli, @n)";
            DBHelper.ExecNonQuery(sql,
                DBHelper.P("@c", codigo),
                DBHelper.P("@cat", categoria),
                DBHelper.P("@s", servicioId),
                DBHelper.P("@cli", (object?)clienteId ?? DBNull.Value),
                DBHelper.P("@n", (object?)notas ?? DBNull.Value));
            return codigo;
        }

        public static DataRow? ObtenerIngreso(string codigo)
        {
            string sql = @"SELECT i.IngresoID, i.Codigo, i.Categoria, i.ServicioID, i.ClienteID,
                                  i.FechaIngreso, i.Notas, s.Nombre AS Servicio, s.Precio
                           FROM Ingresos i
                           JOIN Servicios s ON s.ServicioID = i.ServicioID
                           WHERE i.Codigo = @c";
            var dt = DBHelper.Query(sql, DBHelper.P("@c", codigo));
            return dt.Rows.Count == 1 ? dt.Rows[0] : null;
        }
    }
}
