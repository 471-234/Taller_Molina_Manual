namespace TallerMolinaproyecto
{
    partial class BitacoraControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBitacora;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvBitacora = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            SuspendLayout();

            // dgvBitacora
            dgvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Location = new System.Drawing.Point(0, 0);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.RowHeadersWidth = 51;
            dgvBitacora.Size = new System.Drawing.Size(1200, 700);

            // BitacoraControl
            Controls.Add(dgvBitacora);
            Name = "BitacoraControl";
            Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            ResumeLayout(false);
        }
    }
}
