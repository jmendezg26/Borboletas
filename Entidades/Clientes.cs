namespace Borboletas.Entidades
{
    public class Clientes
    {
    }

    public class NuevoCliente
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string TelefonoSecundario { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public int IdEstado { get; set; }
    }

    public class EditarCliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string TelefonoSecundario { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public int IdEstado { get; set; }
    }
}
