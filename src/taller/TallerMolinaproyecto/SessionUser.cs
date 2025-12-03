namespace TallerMolinaproyecto
{
    internal static class SessionUser
    {
        public static int UsuarioID { get; set; }
        public static string Username { get; set; } = "";
        public static string Rol { get; set; } = "";         // ADMIN | EMPLEADO | CLIENTE
        public static string? Area { get; set; }              // MECANICA | PINTURA | REVISION | SECRETARIA | null
        public static int? EmpleadoID { get; set; }
        public static int? ClienteID { get; set; }
        public static bool IsAdmin => Rol == "ADMIN";
        public static bool IsEmpleado => Rol == "EMPLEADO";
        public static bool IsCliente => Rol == "CLIENTE";
    }
}
