using System;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // 🔧 Auto-detección y preparación de base de datos
                DatabaseInitializer.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inicializando base de datos:\n" + ex.Message,
                    "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🟢 Siempre inicia con Login
            Application.Run(new Login());
        }
    }
}
