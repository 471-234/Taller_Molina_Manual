using System;
using System.Data;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class BitacoraControl : UserControl
    {
        public BitacoraControl()
        {
            InitializeComponent();
            CargarBitacora();
        }

        private void CargarBitacora()
        {
            try
            {
                string sql = @"
                    SELECT 
                        B.BitacoraID,
                        E.Nombre AS Usuario,
                        B.Accion,
                        B.Fecha,
                        B.Detalle
                    FROM BITACORA B
                    LEFT JOIN EMPLEADOS E ON E.EmpleadoID = B.EmpleadoID
                    ORDER BY B.Fecha DESC;
                ";

                dgvBitacora.DataSource = DBHelper.Query(sql);

                dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBitacora.ReadOnly = true;
                dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la bitácora:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
