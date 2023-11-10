using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSolution.Entities
{
    public class RelacionArticuloTienda
    {
        public int RelacionID { get; set; }
        public int ArticuloID { get; set; }
        public int TiendaID { get; set; }
        public DateTime Fecha { get; set; }

        public Articulo Articulo { get; set; }
        public Tienda Tienda { get; set; }
    }
}
