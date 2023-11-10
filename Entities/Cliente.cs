namespace YourSolution.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Relación Cliente - Articulo
        public List<RelacionClienteArticulo> RelacionClienteArticulos { get; set; }
    }
}