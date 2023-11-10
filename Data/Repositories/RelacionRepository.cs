using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSolution.Data;

namespace YourSolucion.Repositories
{
    public class RelacionRepository : IRelacionRepository
    {
        private readonly YourDbContext _context;

        public RelacionRepository(YourDbContext context)
        {
            _context = context;
        }

        public List<RelacionClienteArticulo> ObtenerRelacionesPorCliente(int clienteId)
        {
            return _context.RelacionesClienteArticulo
                .Where(r => r.ClienteID == clienteId)
                .ToList();
        }

        public void CrearRelacion(RelacionClienteArticulo relacion)
        {
            _context.RelacionesClienteArticulo.Add(relacion);
            _context.SaveChanges();
        }

        public void ActualizarRelacion(RelacionClienteArticulo relacion)
        {
            _context.RelacionesClienteArticulo.Update(relacion);
            _context.SaveChanges();
        }

        public void EliminarRelacion(int clienteId, int articuloId)
        {
            var relacion = _context.RelacionesClienteArticulo
                .FirstOrDefault(r => r.ClienteID == clienteId && r.ArticuloID == articuloId);

            if (relacion != null)
            {
                _context.RelacionesClienteArticulo.Remove(relacion);
                _context.SaveChanges();
            }
        }
    }


}
