namespace TallerMolinaproyecto
{
    public static class AppState
    {
        // ================================================
        // MOTOR ACTUAL
        // ================================================
        public static string MotorActual = "SQLSERVER";


        public static void SetMotor(string motor)
        {
            motor = (motor ?? "").Trim().ToUpper();

            if (motor == "MYSQL")
                MotorActual = "MYSQL";
            else
                MotorActual = "SQLSERVER";
        }

        public static bool IsMySql => MotorActual == "MYSQL";
        public static bool IsSqlServer => MotorActual == "SQLSERVER";

        // ================================================
        // CADENAS DE CONEXIÓN
        // ================================================
        // ================================================
        // CADENAS DE CONEXIÓN
        // ================================================
        public static string MySqlConnectionString { get; set; } =
            "Server=localhost;Uid=root;Pwd=2006;Database=TallerMolina_v2;SslMode=None;AllowPublicKeyRetrieval=True;";

        public static string SqlServerConnectionString { get; set; } =
            "Server=localhost;Database=TallerMolina;Integrated Security=True;TrustServerCertificate=True;";

        // ================================================
        // SESIÓN DE USUARIO
        // ================================================
        public static int UsuarioID { get; set; }
        public static string UsuarioNombre { get; set; } = "";
        public static string Rol { get; set; } = "";
        public static int RolID { get; set; }

        public static bool SesionActiva => UsuarioID > 0;

        public static void CerrarSesion()
        {
            UsuarioID = 0;
            UsuarioNombre = "";
            Rol = "";
            RolID = 0;
        }

        // Info display
        public static string MotorEnUso()
        {
            if (IsMySql) return "MySQL";
            if (IsSqlServer) return "SQL Server";
            return "No definido";
        }
    }
}
