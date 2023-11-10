using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSolution.Entities
{
    public class RelacionClienteArticulo
    {
        public int RelacionID { get; set; }
        public int ClienteID { get; set; }
        public int ArticuloID { get; set; }
        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; }
        public Articulo Articulo { get; set; }
    }
}
