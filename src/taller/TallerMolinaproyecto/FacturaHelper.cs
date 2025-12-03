using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMolinaproyecto
{
    internal class FacturaHelper
    {
        public static int CrearFactura(int clienteId, int empleadoId, string codigo, string tipoFactura = "SERVICIO")
        {
            string sql = @"
        INSERT INTO FACTURAS (ClienteID, EmpleadoID, Codigo, TipoFactura)
        VALUES (@cli, @emp, @cod, @tipo);
        SELECT LAST_INSERT_ID();"; // MySQL obtiene el último ID generado

            var dt = DBHelper.Query(sql,
                DBHelper.P("@cli", clienteId),
                DBHelper.P("@emp", empleadoId),
                DBHelper.P("@cod", codigo),
                DBHelper.P("@tipo", tipoFactura));

            return Convert.ToInt32(dt.Rows[0][0]);
        }


        public static void AgregarDetalle(int facturaId, int? servicioId, int? repuestoId,
                                  string descripcion, int cantidad, decimal precioUnitario)
        {
            decimal subtotal = cantidad * precioUnitario;

            string sql = @"
        INSERT INTO DETALLE_FACTURA (FacturaID, ServicioID, RepuestoID, Descripcion, Cantidad, PrecioUnitario, Subtotal)
        VALUES (@fact, @serv, @rep, @desc, @cant, @precio, @sub);";

            DBHelper.ExecNonQuery(sql,
                DBHelper.P("@fact", facturaId),
                DBHelper.P("@serv", (object?)servicioId ?? DBNull.Value),
                DBHelper.P("@rep", (object?)repuestoId ?? DBNull.Value),
                DBHelper.P("@desc", descripcion),
                DBHelper.P("@cant", cantidad),
                DBHelper.P("@precio", precioUnitario),
                DBHelper.P("@sub", subtotal));
        }



       


    }


}
