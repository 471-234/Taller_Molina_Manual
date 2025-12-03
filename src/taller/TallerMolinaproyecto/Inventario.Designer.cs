namespace TallerMolinaproyecto
{
    partial class Inventario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            bningresar = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label8 = new Label();
            txtrepuesto = new TextBox();
            txtcanti = new TextBox();
            txtminimo = new TextBox();
            bneliminar = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(649, 174);
            panel2.Name = "panel2";
            panel2.Size = new Size(544, 531);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeight = 34;
            dataGridView1.Location = new Point(16, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(507, 480);
            dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1676, 140);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 26F, FontStyle.Bold);
            label1.Location = new Point(408, 38);
            label1.Name = "label1";
            label1.Size = new Size(339, 65);
            label1.TabIndex = 0;
            label1.Text = "INVENTARIO";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(240, 474);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(350, 31);
            dateTimePicker1.TabIndex = 9;
            // 
            // bningresar
            // 
            bningresar.Location = new Point(408, 609);
            bningresar.Name = "bningresar";
            bningresar.Size = new Size(150, 60);
            bningresar.TabIndex = 10;
            bningresar.Text = "Ingresar";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 395);
            label6.Name = "label6";
            label6.Size = new Size(143, 25);
            label6.TabIndex = 6;
            label6.Text = "STOCK MINIMO:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 305);
            label5.Name = "label5";
            label5.Size = new Size(87, 25);
            label5.TabIndex = 4;
            label5.Text = "Cantidad:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 219);
            label4.Name = "label4";
            label4.Size = new Size(99, 25);
            label4.TabIndex = 2;
            label4.Text = "REPUESTO:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(55, 479);
            label8.Name = "label8";
            label8.Size = new Size(161, 25);
            label8.TabIndex = 8;
            label8.Text = "ULTIMA ENTRADA:";
            // 
            // txtrepuesto
            // 
            txtrepuesto.Location = new Point(206, 216);
            txtrepuesto.Name = "txtrepuesto";
            txtrepuesto.Size = new Size(399, 31);
            txtrepuesto.TabIndex = 3;
            // 
            // txtcanti
            // 
            txtcanti.Location = new Point(206, 305);
            txtcanti.Name = "txtcanti";
            txtcanti.Size = new Size(399, 31);
            txtcanti.TabIndex = 5;
            // 
            // txtminimo
            // 
            txtminimo.Location = new Point(206, 395);
            txtminimo.Name = "txtminimo";
            txtminimo.Size = new Size(399, 31);
            txtminimo.TabIndex = 7;
            // 
            // bneliminar
            // 
            bneliminar.Location = new Point(151, 609);
            bneliminar.Name = "bneliminar";
            bneliminar.Size = new Size(150, 60);
            bneliminar.TabIndex = 11;
            bneliminar.Text = "Eliminar";
            // 
            // Inventario
            // 
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(txtrepuesto);
            Controls.Add(label5);
            Controls.Add(txtcanti);
            Controls.Add(label6);
            Controls.Add(txtminimo);
            Controls.Add(label8);
            Controls.Add(dateTimePicker1);
            Controls.Add(bningresar);
            Controls.Add(bneliminar);
            Name = "Inventario";
            Size = new Size(1235, 1170);
            Load += Inventario_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private TextBox txtrepuesto;
        private TextBox txtcanti;
        private TextBox txtminimo;
        private DateTimePicker dateTimePicker1;
        private Button bningresar;
        private Button bneliminar;
        private DataGridView dataGridView1;
    }
}
