using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace TallerMolinaproyecto
{
    internal static class DatabaseInitializer
    {
        // Conexiones base sin nombre de base
        private const string MySqlBaseConn =
        "Server=localhost;Port=3306;Uid=root;Pwd=kook21_;SslMode=None;AllowPublicKeyRetrieval=True;";

        private const string SqlServerBaseConn =
            "Server=localhost;Integrated Security=True;TrustServerCertificate=True;";

        public static void Run()
        {
            using var overlay = new AnalyzerOverlay();
            overlay.Show();
            Application.DoEvents();

            try
            {
                overlay.UpdateStage("🔍 Detectando motores de base de datos...");
                Thread.Sleep(600);

                // 1) Detectar SQL Server
                string sqlConnDetected = DetectarSqlServerAuto();
                bool sqlOk = !string.IsNullOrWhiteSpace(sqlConnDetected);

                // 2) Probar MySQL
                bool mysqlOk = ProbarConexionMySql();
             

                if (!sqlOk && !mysqlOk)
                {
                    overlay.UpdateStage("❌ No hay SQL Server ni MySQL disponibles.");
                    Thread.Sleep(600);
                    overlay.FinalizeWithProgress(TimeSpan.FromSeconds(1), "❌ No se encontró ningún motor de BD");

                    MessageBox.Show(
                        "No se encontró ninguna base de datos.\nInstala SQL Server o MySQL.",
                        "Error crítico",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Environment.Exit(0);
                    return;
                }

                string motor = sqlOk ? "SQLSERVER" : "MYSQL";
                AppState.SetMotor(motor);

                overlay.UpdateStage(sqlOk ? "✔ SQL Server detectado." : "✔ MySQL detectado.");
                Thread.Sleep(500);

                // 3) Crear base si no existe
                overlay.UpdateStage("📦 Verificando base de datos...");
                DatabaseSmartBuilder.EnsureDatabaseExists(motor);
                Thread.Sleep(600);

                // 4) Crear/reparar tablas
                overlay.UpdateStage("🏗 Reparando tablas...");
                DatabaseSmartBuilder.RunScript();
                Thread.Sleep(600);

                // Solo crear base extra si MySQL es motor y diferente
                if (motor == "MYSQL" && mysqlOk)  // <-- nota: ya NO depende de motor
                {
                    overlay.UpdateStage("📦 Creando base MySQL (extra)...");
                    DatabaseSmartBuilder.EnsureDatabaseExists("MYSQL");
                    Thread.Sleep(400);

                    overlay.UpdateStage("🏗 Creando tablas MySQL (extra)...");
                    DatabaseSmartBuilder.RunScript();
                    Thread.Sleep(400);
                }

                // Conexión final
                if (AppState.IsMySql)
                {
                    AppState.MySqlConnectionString = MySqlBaseConn + "Database=TallerMolina_v2;";
                    overlay.UpdateStage("🔌 Conectado a MySQL (TallerMolina_v2)");
                }
                else
                {
                    var builder = new SqlConnectionStringBuilder(sqlConnDetected)
                    {
                        InitialCatalog = "TallerMolina",
                        TrustServerCertificate = true
                    };

                    AppState.SqlServerConnectionString = builder.ConnectionString;
                    overlay.UpdateStage("🔌 Conectado a SQL Server (TallerMolina)");
                }

                Thread.Sleep(600);

                // 6) Usuario admin y roles
                overlay.UpdateStage("👨‍💻 Verificando usuario admin / 2006...");
                DBHelper.VerificarUsuarioDesarrollador();
                Thread.Sleep(600);

                overlay.FinalizeWithProgress(TimeSpan.FromSeconds(1.5), "✅ Sistema listo");
            }
            catch (Exception ex)
            {
                overlay.FinalizeWithProgress(TimeSpan.FromSeconds(1), "❌ Error inicializando BD");

                MessageBox.Show("Error inicializando base de datos:\n" + ex.Message,
                    "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        // ============================================================
        // AUTO-DETECCIÓN SQL SERVER
        // ============================================================
        private static string DetectarSqlServerAuto()
        {
            string[] posibles =
            {
                @"Server=localhost;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=127.0.0.1;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=(local);Integrated Security=True;TrustServerCertificate=True;",
                @"Server=.;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=localhost\SQLEXPRESS;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=.\SQLEXPRESS;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=(localdb)\MSSQLLocalDB;Integrated Security=True;TrustServerCertificate=True;"
            };

            foreach (string conn in posibles)
            {
                try
                {
                    using var c = new SqlConnection(conn);
                    c.Open();
                    return conn;
                }
                catch
                {
                    // ignorar
                }
            }

            return "";
        }

        // ============================================================
        // PROBAR MYSQL
        // ============================================================
        private static bool ProbarConexionMySql()
        {
           
            try
            {
                using var c = new MySqlConnection(MySqlBaseConn);
                c.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ============================================================
        // OVERLAY
        // ============================================================
        private sealed class AnalyzerOverlay : Form
        {
            private readonly Label lbl;
            private readonly Label spinner;
            private readonly ProgressBar bar;
            private volatile bool activo = true;

            public AnalyzerOverlay()
            {
                Text = "Analizando Base de Datos";
                StartPosition = FormStartPosition.CenterScreen;
                FormBorderStyle = FormBorderStyle.None;
                BackColor = Color.FromArgb(30, 30, 30);
                Opacity = 0.94;
                Width = 620;
                Height = 260;
                TopMost = true;

                var panel = new Panel()
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.FromArgb(40, 40, 40),
                    Padding = new Padding(20)
                };
                Controls.Add(panel);

                spinner = new Label()
                {
                    Dock = DockStyle.Top,
                    Height = 40,
                    Font = new Font("Segoe UI Emoji", 22),
                    ForeColor = Color.DeepSkyBlue,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panel.Controls.Add(spinner);

                lbl = new Label()
                {
                    Dock = DockStyle.Top,
                    Height = 30,
                    Text = "Analizando...",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panel.Controls.Add(lbl);

                bar = new ProgressBar()
                {
                    Dock = DockStyle.Bottom,
                    Height = 10,
                    Style = ProgressBarStyle.Continuous
                };
                panel.Controls.Add(bar);

                Shown += (s, e) => IniciarSpinner();
            }

            private void IniciarSpinner()
            {
                new Thread(() =>
                {
                    string[] icons = { "🔄", "⚙️", "🔁", "🔃" };
                    int i = 0;

                    while (activo)
                    {
                        try
                        {
                            if (IsDisposed || !IsHandleCreated) break;

                            BeginInvoke(new Action(() =>
                            {
                                if (!IsDisposed && IsHandleCreated)
                                    spinner.Text = icons[i % icons.Length];
                            }));
                        }
                        catch { break; }

                        i++;
                        Thread.Sleep(250);
                    }
                })
                { IsBackground = true }.Start();
            }

            public void UpdateStage(string text)
            {
                if (IsDisposed || !IsHandleCreated) return;

                try
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (!IsDisposed) lbl.Text = text;
                    }));
                }
                catch { }
            }

            public void FinalizeWithProgress(TimeSpan dur, string msg)
            {
                activo = false;

                if (!IsDisposed && IsHandleCreated)
                    lbl.Text = msg;

                int steps = 100;
                int delay = (int)(dur.TotalMilliseconds / steps);

                for (int i = 0; i <= steps; i++)
                {
                    if (IsDisposed || !IsHandleCreated) break;

                    try { bar.Value = i; }
                    catch { break; }

                    Thread.Sleep(delay);
                }

                Thread.Sleep(300);

                if (!IsDisposed)
                    Hide();
            }

            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                activo = false;
                base.OnFormClosing(e);
            }
        }
    }
}
