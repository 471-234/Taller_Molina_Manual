using System;
using System.Data;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class EMPLEADOS : UserControl
    {
        private int empleadoIdActual = 0;

        public EMPLEADOS()
        {
            InitializeComponent();
        }

        private void EMPLEADOS_Load(object sender, EventArgs e)
        {
            try
            {
                CargarRoles();
                CargarAreas();
                CargarEmpleados();

                dgvEmpleados.SelectionChanged += dgvEmpleados_SelectionChanged;
                btnNuevo.Click += btnNuevo_Click;
                btnGuardar.Click += btnGuardar_Click;
                btnEliminar.Click += btnEliminar_Click;
                btnBuscar.Click += btnBuscar_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        // ================== CARGA COMBOS ==================
        private void CargarRoles()
        {
            string sql = "SELECT RolID, Nombre FROM Roles ORDER BY Nombre;";
            DataTable dt = DBHelper.Query(sql);

            cmbRol.DataSource = dt;
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "RolID";
            cmbRol.SelectedIndex = -1;
        }

        private void CargarAreas()
        {
            cmbArea.Items.Clear();
            cmbArea.Items.Add("Administración");
            cmbArea.Items.Add("Mecánica");
            cmbArea.Items.Add("Pintura");
            cmbArea.Items.Add("Revisión");
            cmbArea.Items.Add("Caja");
            cmbArea.Items.Add("Bodega");
            cmbArea.SelectedIndex = -1;
        }

        // ================== GRID EMPLEADOS ==================
        private void CargarEmpleados(string filtro = "")
        {
            string sql = @"
                SELECT 
                    e.EmpleadoID,
                    e.Nombre,
                    e.Usuario,
                    e.Telefono,
                    e.Correo,
                    r.Nombre AS Rol,
                    e.RolID,
                    e.Area,
                    e.Activo,
                    e.ContrasenaHash
                FROM Empleados e
                LEFT JOIN Roles r ON r.RolID = e.RolID";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                sql += @"
                WHERE e.Nombre LIKE @f
                   OR e.Usuario LIKE @f
                   OR e.Area LIKE @f
                   OR r.Nombre LIKE @f";
            }

            sql += " ORDER BY e.EmpleadoID DESC;";

            DataTable dt = string.IsNullOrWhiteSpace(filtro)
                ? DBHelper.Query(sql)
                : DBHelper.Query(sql, DBHelper.P("@f", "%" + filtro + "%"));

            dgvEmpleados.DataSource = dt;

            // Ocultar columnas internas
            if (dgvEmpleados.Columns.Contains("ContrasenaHash"))
                dgvEmpleados.Columns["ContrasenaHash"].Visible = false;
            if (dgvEmpleados.Columns.Contains("RolID"))
                dgvEmpleados.Columns["RolID"].Visible = false;
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0) return;
            var row = dgvEmpleados.SelectedRows[0];
            if (row == null || row.Cells["EmpleadoID"].Value == null) return;

            empleadoIdActual = Convert.ToInt32(row.Cells["EmpleadoID"].Value);
            txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
            txtUsuario.Text = row.Cells["Usuario"].Value?.ToString();
            txtTelefono.Text = row.Cells["Telefono"].Value?.ToString();
            txtCorreo.Text = row.Cells["Correo"].Value?.ToString();
            cmbArea.Text = row.Cells["Area"].Value?.ToString();

            if (row.Cells["RolID"].Value != null)
                cmbRol.SelectedValue = Convert.ToInt32(row.Cells["RolID"].Value);

            if (row.Cells["Activo"].Value != null)
                chkActivo.Checked = Convert.ToBoolean(row.Cells["Activo"].Value);

            // Por seguridad, nunca mostramos la contraseña
            txtContrasena.Clear();
        }

        // ================== BOTONES ==================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string usuario = txtUsuario.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                string area = cmbArea.Text.Trim();
                bool activo = chkActivo.Checked;

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(usuario))
                {
                    MessageBox.Show("Nombre y Usuario son obligatorios.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbRol.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un rol.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rolID = Convert.ToInt32(cmbRol.SelectedValue);
                string passTexto = txtContrasena.Text.Trim();
                string passHash = null;

                // Si estamos creando uno nuevo, la contraseña es obligatoria
                if (empleadoIdActual == 0)
                {
                    if (string.IsNullOrEmpty(passTexto))
                    {
                        MessageBox.Show("Ingrese una contraseña para el nuevo empleado.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    passHash = Security.Sha256(passTexto);
                }
                else
                {
                    // Editando: si no escribió contraseña, mantener la anterior
                    if (!string.IsNullOrEmpty(passTexto))
                    {
                        passHash = Security.Sha256(passTexto);
                    }
                    else
                    {
                        // tomar la del grid
                        var row = dgvEmpleados.SelectedRows.Count > 0 ? dgvEmpleados.SelectedRows[0] : null;
                        if (row != null && row.Cells["ContrasenaHash"].Value != null)
                            passHash = row.Cells["ContrasenaHash"].Value.ToString();
                    }
                }

                if (empleadoIdActual == 0)
                {
                    // INSERT
                    string sql = @"
                        INSERT INTO Empleados
                        (Nombre, Usuario, ContrasenaHash, Telefono, Correo, RolID, Area, Activo)
                        VALUES(@n, @u, @p, @t, @c, @r, @a, @ac);";

                    DBHelper.ExecNonQuery(sql,
                        DBHelper.P("@n", nombre),
                        DBHelper.P("@u", usuario),
                        DBHelper.P("@p", passHash),
                        DBHelper.P("@t", telefono),
                        DBHelper.P("@c", correo),
                        DBHelper.P("@r", rolID),
                        DBHelper.P("@a", area),
                        DBHelper.P("@ac", activo));

                    MessageBox.Show("Empleado creado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // UPDATE
                    string sql = @"
                        UPDATE Empleados
                        SET Nombre=@n,
                            Usuario=@u,
                            ContrasenaHash=@p,
                            Telefono=@t,
                            Correo=@c,
                            RolID=@r,
                            Area=@a,
                            Activo=@ac
                        WHERE EmpleadoID=@id;";

                    DBHelper.ExecNonQuery(sql,
                        DBHelper.P("@n", nombre),
                        DBHelper.P("@u", usuario),
                        DBHelper.P("@p", passHash),
                        DBHelper.P("@t", telefono),
                        DBHelper.P("@c", correo),
                        DBHelper.P("@r", rolID),
                        DBHelper.P("@a", area),
                        DBHelper.P("@ac", activo),
                        DBHelper.P("@id", empleadoIdActual));

                    MessageBox.Show("Empleado actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarEmpleados();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar empleado:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (empleadoIdActual == 0)
            {
                MessageBox.Show("Seleccione un empleado primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (MessageBox.Show("¿Seguro que desea eliminar este empleado?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ////////////////
            int tienePagos = Convert.ToInt32(DBHelper.ExecScalar(
                 "SELECT COUNT(*) FROM PAGOS WHERE EmpleadoID=@id",
                  DBHelper.P("@id", empleadoIdActual)));

            if (tienePagos > 0)
            {
                MessageBox.Show(
                    "No puede eliminar este empleado porque tiene pagos asociados.",
                    "Operación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            /////////////////

            try
            {
                string sql = "DELETE FROM Empleados WHERE EmpleadoID=@id;";
                DBHelper.ExecNonQuery(sql, DBHelper.P("@id", empleadoIdActual));

                MessageBox.Show("Empleado eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEmpleados();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CargarEmpleados(filtro);
        }

        // ================== UTILIDADES ==================
        private void LimpiarFormulario()
        {
            empleadoIdActual = 0;
            txtNombre.Clear();
            txtUsuario.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            txtBuscar.Clear();
            cmbRol.SelectedIndex = -1;
            cmbArea.SelectedIndex = -1;
            chkActivo.Checked = true;
            dgvEmpleados.ClearSelection();
        }
    }
}
