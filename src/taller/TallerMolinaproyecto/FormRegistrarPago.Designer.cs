namespace TallerMolinaproyecto
{
    partial class FormRegistrarPago
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblCodigoFactura = new Label();
            lblEmpleado = new Label();
            lblMonto = new Label();
            lblCuenta = new Label();
            lblMetodo = new Label();
            lblObservacion = new Label();
            txtCodigoFactura = new TextBox();
            txtEmpleadoID = new TextBox();
            txtNumeroCuenta = new TextBox();
            cmbMetodo = new ComboBox();
            txtObservacion = new TextBox();
            numMonto = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Firebrick;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(644, 88);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRAR PAGO / TRANSFERENCIA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCodigoFactura
            // 
            lblCodigoFactura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCodigoFactura.Location = new Point(60, 199);
            lblCodigoFactura.Name = "lblCodigoFactura";
            lblCodigoFactura.Size = new Size(167, 38);
            lblCodigoFactura.TabIndex = 1;
            lblCodigoFactura.Text = "Código Factura:";
            lblCodigoFactura.Click += lblCodigoFactura_Click;
            // 
            // lblEmpleado
            // 
            lblEmpleado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmpleado.Location = new Point(78, 130);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(140, 38);
            lblEmpleado.TabIndex = 2;
            lblEmpleado.Text = "ID Empleado:";
            // 
            // lblMonto
            // 
            lblMonto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMonto.Location = new Point(111, 386);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(120, 38);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto (L):";
            // 
            // lblCuenta
            // 
            lblCuenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCuenta.Location = new Point(25, 270);
            lblCuenta.Name = "lblCuenta";
            lblCuenta.Size = new Size(200, 38);
            lblCuenta.TabIndex = 4;
            lblCuenta.Text = "Número de cuenta:";
            // 
            // lblMetodo
            // 
            lblMetodo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMetodo.Location = new Point(44, 333);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(174, 38);
            lblMetodo.TabIndex = 5;
            lblMetodo.Text = "Método de pago:";
            // 
            // lblObservacion
            // 
            lblObservacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblObservacion.Location = new Point(85, 463);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(146, 38);
            lblObservacion.TabIndex = 6;
            lblObservacion.Text = "Observación:";
            // 
            // txtCodigoFactura
            // 
            txtCodigoFactura.BackColor = Color.Gainsboro;
            txtCodigoFactura.Font = new Font("Segoe UI", 10F);
            txtCodigoFactura.Location = new Point(244, 196);
            txtCodigoFactura.Margin = new Padding(3, 4, 3, 4);
            txtCodigoFactura.Name = "txtCodigoFactura";
            txtCodigoFactura.ReadOnly = true;
            txtCodigoFactura.Size = new Size(311, 34);
            txtCodigoFactura.TabIndex = 7;
            // 
            // txtEmpleadoID
            // 
            txtEmpleadoID.BackColor = Color.Gainsboro;
            txtEmpleadoID.Font = new Font("Segoe UI", 10F);
            txtEmpleadoID.Location = new Point(244, 130);
            txtEmpleadoID.Margin = new Padding(3, 4, 3, 4);
            txtEmpleadoID.Name = "txtEmpleadoID";
            txtEmpleadoID.ReadOnly = true;
            txtEmpleadoID.Size = new Size(111, 34);
            txtEmpleadoID.TabIndex = 8;
            // 
            // txtNumeroCuenta
            // 
            txtNumeroCuenta.Font = new Font("Segoe UI", 10F);
            txtNumeroCuenta.Location = new Point(244, 267);
            txtNumeroCuenta.Margin = new Padding(3, 4, 3, 4);
            txtNumeroCuenta.Name = "txtNumeroCuenta";
            txtNumeroCuenta.Size = new Size(311, 34);
            txtNumeroCuenta.TabIndex = 10;
            // 
            // cmbMetodo
            // 
            cmbMetodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodo.Font = new Font("Segoe UI", 10F);
            cmbMetodo.Location = new Point(244, 330);
            cmbMetodo.Margin = new Padding(3, 4, 3, 4);
            cmbMetodo.Name = "cmbMetodo";
            cmbMetodo.Size = new Size(200, 36);
            cmbMetodo.TabIndex = 11;
            // 
            // txtObservacion
            // 
            txtObservacion.Font = new Font("Segoe UI", 10F);
            txtObservacion.Location = new Point(244, 463);
            txtObservacion.Margin = new Padding(3, 4, 3, 4);
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(311, 112);
            txtObservacion.TabIndex = 12;
            // 
            // numMonto
            // 
            numMonto.DecimalPlaces = 2;
            numMonto.Font = new Font("Segoe UI", 10F);
            numMonto.Location = new Point(244, 384);
            numMonto.Margin = new Padding(3, 4, 3, 4);
            numMonto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMonto.Name = "numMonto";
            numMonto.Size = new Size(167, 34);
            numMonto.TabIndex = 9;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Firebrick;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(111, 650);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(167, 50);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Gray;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(367, 650);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(167, 50);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormRegistrarPago
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(644, 725);
            Controls.Add(lblTitulo);
            Controls.Add(lblCodigoFactura);
            Controls.Add(lblEmpleado);
            Controls.Add(lblMonto);
            Controls.Add(lblCuenta);
            Controls.Add(lblMetodo);
            Controls.Add(lblObservacion);
            Controls.Add(txtCodigoFactura);
            Controls.Add(txtEmpleadoID);
            Controls.Add(numMonto);
            Controls.Add(txtNumeroCuenta);
            Controls.Add(cmbMetodo);
            Controls.Add(txtObservacion);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegistrarPago";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Pago / Transferencia";
            Load += FormRegistrarPago_Load;
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigoFactura;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.Label lblObservacion;

        private System.Windows.Forms.TextBox txtCodigoFactura;
        private System.Windows.Forms.TextBox txtEmpleadoID;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.TextBox txtNumeroCuenta;
        private System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
