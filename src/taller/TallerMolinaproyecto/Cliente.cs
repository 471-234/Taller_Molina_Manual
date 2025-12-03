using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public partial class Cliente : UserControl
    {
        public Cliente()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Resize += (s, e) => AjustarCentrado();
        }

        private void AjustarCentrado()
        {
            try
            {
                panel2.Dock = DockStyle.Top;
                panel2.Height = 130;
                panel2.BackColor = Color.Brown;

                pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = new Size(190, 140);
                pictureBox1.Location = new Point(panel2.Width - pictureBox1.Width - 20, -5);

                label1.Location = new Point((panel2.Width - label1.Width) / 2, 35);

                panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
                panel1.BackColor = Color.Brown;

                int margenDerecho = 60;
                int margenIzquierdo = 520;
                int margenSuperior = 200;
                int margenInferior = 150;

                panel1.Location = new Point(margenIzquierdo, margenSuperior);
                panel1.Size = new Size(this.Width - margenIzquierdo - margenDerecho, this.Height - margenSuperior - margenInferior);

                dataGridView1.Location = new Point(30, 30);
                dataGridView1.Size = new Size(panel1.Width - 60, panel1.Height - 120);
                dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                bningresar.Location = new Point(panel1.Right - bningresar.Width - 10, panel1.Bottom + 10);
            }
            catch { }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            AjustarCentrado();
            CargarClientes();

            // REGISTRAR EVENTO NECESARIO PARA CARGAR LOS DATOS AL SELECCIONAR
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        // ---------------------------------------------
        // CARGA DE CLIENTES (YA CON FECHA)
        // ---------------------------------------------
        private void CargarClientes()
        {
            dataGridView1.DataSource = DBHelper.Query(
                "SELECT ClienteID, Nombre, Telefono, Correo, Direccion, FechaRegistro FROM CLIENTES ORDER BY ClienteID DESC");
        }

        // ---------------------------------------------
        // INSERTAR CLIENTE (YA GUARDA FECHA)
        // ---------------------------------------------
        private void Bningresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text)) return;

            DBHelper.ExecNonQuery(
                @"INSERT INTO CLIENTES (Nombre,Telefono,Correo,Direccion,FechaRegistro)
                  VALUES(@n,@t,@c,@d,@f)",
                DBHelper.P("@n", textBox2.Text.Trim()),
                DBHelper.P("@t", textBox4.Text.Trim()),
                DBHelper.P("@c", textBox5.Text.Trim()),
                DBHelper.P("@d", textBox6.Text.Trim()),
                DBHelper.P("@f", dateTimePicker1.Value)
            );
            CargarClientes();
            Limpiar();
        }

        // ---------------------------------------------
        // ELIMINAR CLIENTE
        // ---------------------------------------------
        private void Bneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteID"].Value);

            DBHelper.ExecNonQuery("DELETE FROM CLIENTES WHERE ClienteID=@id",
                DBHelper.P("@id", id));

            CargarClientes();
            Limpiar();
        }

        // ---------------------------------------------
        // ACTUALIZAR CLIENTE (YA ACTUALIZA FECHA)
        // ---------------------------------------------
        private void Bnactualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteID"].Value);

            DBHelper.ExecNonQuery(
                @"UPDATE CLIENTES 
                  SET Nombre=@n, Telefono=@t, Correo=@c, Direccion=@d, FechaRegistro=@f 
                  WHERE ClienteID=@id",
                DBHelper.P("@n", textBox2.Text.Trim()),
                DBHelper.P("@t", textBox4.Text.Trim()),
                DBHelper.P("@c", textBox5.Text.Trim()),
                DBHelper.P("@d", textBox6.Text.Trim()),
                DBHelper.P("@f", dateTimePicker1.Value),
                DBHelper.P("@id", id)
            );

            CargarClientes();
            Limpiar();
        }

        // ---------------------------------------------
        // CARGAR CAMPOS AL SELECCIONAR EN EL GRID (INCLUYE FECHA)
        // ---------------------------------------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            textBox2.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();

            if (dataGridView1.CurrentRow.Cells["FechaRegistro"].Value != DBNull.Value)
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaRegistro"].Value);
        }

        private void Limpiar()
        {
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
