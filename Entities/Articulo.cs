using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSolution.Entities
{
    public class Articulo
    {
        public int ArticuloID { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }

        // Relación Tienda - Articulo
        public List<RelacionArticuloTienda> RelacionArticuloTiendas { get; set; }

        // Relación Cliente - Articulo
        public List<RelacionClienteArticulo> RelacionClienteArticulos { get; set; }
    }
}
