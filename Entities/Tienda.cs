namespace YourSolution.Entities
{
    public class Tienda
    {
        public int TiendaID { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        // Relación Tienda - Articulo
        public List<RelacionArticuloTienda> RelacionArticuloTiendas { get; set; }
    }
}