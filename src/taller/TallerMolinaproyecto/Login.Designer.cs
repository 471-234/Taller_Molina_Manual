namespace TallerMolinaproyecto
{
    partial class Login
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            txtuser = new TextBox();
            txtcontrasena = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            bningresar = new Button();
            bnsalir = new Button();
            checkBox1 = new CheckBox();

            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(368, 0);
            label1.Name = "label1";
            label1.Size = new Size(761, 114);
            label1.Text = "TALLER MOLINA";

            // txtuser
            txtuser.Location = new Point(402, 374);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(384, 31);

            // txtcontrasena
            txtcontrasena.Location = new Point(402, 496);
            txtcontrasena.Name = "txtcontrasena";
            txtcontrasena.PasswordChar = '*';
            txtcontrasena.Size = new Size(384, 31);

            // panel1
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1649, 126);

            // pictureBox1
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(959, 241);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(562, 501);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // pictureBox2
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(244, 334);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(110, 100);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            // pictureBox3
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(256, 464);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(98, 101);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            // bningresar
            bningresar.Location = new Point(636, 850);
            bningresar.Name = "bningresar";
            bningresar.Size = new Size(135, 56);
            bningresar.Text = "INGRESAR";
            bningresar.UseVisualStyleBackColor = true;
            bningresar.Click += bningresar_Click;

            // bnsalir
            bnsalir.Location = new Point(959, 850);
            bnsalir.Name = "bnsalir";
            bnsalir.Size = new Size(135, 61);
            bnsalir.Text = "SALIR";
            bnsalir.UseVisualStyleBackColor = true;
            bnsalir.Click += bnsalir_Click;

            // checkBox1
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = Color.DeepSkyBlue;
            checkBox1.Location = new Point(360, 611);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(224, 34);
            checkBox1.Text = "Mostrar contraseña";
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            // Login
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1640, 1009);
            Controls.Add(checkBox1);
            Controls.Add(pictureBox1);
            Controls.Add(bnsalir);
            Controls.Add(bningresar);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(txtcontrasena);
            Controls.Add(txtuser);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;

            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtuser;
        private TextBox txtcontrasena;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button bningresar;
        private Button bnsalir;
        private CheckBox checkBox1;
    }
}
