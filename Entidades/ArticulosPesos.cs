namespace Borboletas.Entidades
{
    public class ArticulosPesos
    {
        public int IdArticulo { get; set; }
        public string Articulo { get; set; }
        public double Peso { get; set; }
        public string Link { get; set; }
    }

    public class NuevoArticulo
    {
        public string Articulo { get; set; }
        public double Peso { get; set; }
        public string Link { get; set; }
    }
}
