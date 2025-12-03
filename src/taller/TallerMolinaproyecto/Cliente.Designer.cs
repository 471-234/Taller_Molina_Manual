#nullable disable
namespace TallerMolinaproyecto
{
    partial class Cliente
    {
        // ✅ Ya sin advertencias, completamente limpio
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código del Diseñador de Windows Form

        private void InitializeComponent()
        {
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            bningresar = new Button();
            bneliminar = new Button();
            bnactualizar = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(275, 22);
            label1.Name = "label1";
            label1.Size = new Size(571, 70);
            label1.TabIndex = 0;
            label1.Text = "Registrar Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 224);
            label3.Name = "label3";
            label3.Size = new Size(165, 25);
            label3.TabIndex = 5;
            label3.Text = "Nombre de Cliente:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 292);
            label4.Name = "label4";
            label4.Size = new Size(165, 25);
            label4.TabIndex = 4;
            label4.Text = "Num. de Identidad:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 356);
            label5.Name = "label5";
            label5.Size = new Size(83, 25);
            label5.TabIndex = 3;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(44, 426);
            label6.Name = "label6";
            label6.Size = new Size(70, 25);
            label6.TabIndex = 2;
            label6.Text = "Correo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 496);
            label7.Name = "label7";
            label7.Size = new Size(89, 25);
            label7.TabIndex = 1;
            label7.Text = "Dirección:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(44, 560);
            label8.Name = "label8";
            label8.Size = new Size(156, 25);
            label8.TabIndex = 0;
            label8.Text = "Fecha de Registro:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(553, 224);
            panel1.Name = "panel1";
            panel1.Size = new Size(867, 340);
            panel1.TabIndex = 16;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(798, 289);
            dataGridView1.TabIndex = 0;
            // 
            // bningresar
            // 
            bningresar.Location = new Point(476, 653);
            bningresar.Name = "bningresar";
            bningresar.Size = new Size(115, 59);
            bningresar.TabIndex = 12;
            bningresar.Text = "Ingresar";
            bningresar.UseVisualStyleBackColor = true;
            bningresar.Click += Bningresar_Click;
            // 
            // bneliminar
            // 
            bneliminar.Location = new Point(103, 653);
            bneliminar.Name = "bneliminar";
            bneliminar.Size = new Size(128, 59);
            bneliminar.TabIndex = 13;
            bneliminar.Text = "Eliminar";
            bneliminar.UseVisualStyleBackColor = true;
            bneliminar.Click += Bneliminar_Click;
            // 
            // bnactualizar
            // 
            bnactualizar.Location = new Point(302, 653);
            bnactualizar.Name = "bnactualizar";
            bnactualizar.Size = new Size(122, 59);
            bnactualizar.TabIndex = 14;
            bnactualizar.Text = "Actualizar";
            bnactualizar.UseVisualStyleBackColor = true;
            bnactualizar.Click += Bnactualizar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Brown;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1516, 130);
            panel2.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2025_09_23_at_11_10_53_PM;
            pictureBox1.Location = new Point(1051, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(211, 224);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(302, 31);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(211, 289);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(302, 31);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(211, 353);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(302, 31);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(211, 423);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(302, 31);
            textBox5.TabIndex = 9;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(211, 490);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(302, 31);
            textBox6.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(225, 558);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 31);
            dateTimePicker1.TabIndex = 11;
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox5);
            Controls.Add(textBox6);
            Controls.Add(dateTimePicker1);
            Controls.Add(bningresar);
            Controls.Add(bneliminar);
            Controls.Add(bnactualizar);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Cliente";
            Size = new Size(1698, 1166);
            Load += Cliente_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1, label3, label4, label5, label6, label7, label8;
        private Panel panel1, panel2;
        private Button bningresar, bneliminar, bnactualizar;
        private PictureBox pictureBox1;
        private TextBox textBox2, textBox3, textBox4, textBox5, textBox6;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
    }
}
#nullable restore

