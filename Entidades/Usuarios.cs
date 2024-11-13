namespace Borboletas.Entidades
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdRol { get; set; }
        public string Clave { get; set; }

    }

    public class InicioSesion
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }

    public class UsuarioLogin
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string NombreUsuario { get; set; }
        public string Usuario { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public int IdEstado { get; set; }
    }

    public class NuevoUsuario
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }
    }

    public class EditarUsuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }
        public int IdEstado { get; set; }
    }

    public class UsuarioRol
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
    }
}
