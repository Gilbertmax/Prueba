using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSolution.Data;

namespace YourSolucion.Repositories
{
    public class TiendaRepository : ITiendaRepository
    {
        private readonly YourDbContext _context;

        public TiendaRepository(YourDbContext context)
        {
            _context = context;
        }

        public Tienda ObtenerTiendaPorId(int tiendaId)
        {
            return _context.Tiendas.FirstOrDefault(t => t.TiendaID == tiendaId);
        }

        public List<Tienda> ObtenerTodasTiendas()
        {
            return _context.Tiendas.ToList();
        }

        public void CrearTienda(Tienda tienda)
        {
            _context.Tiendas.Add(tienda);
            _context.SaveChanges();
        }

        public void ActualizarTienda(Tienda tienda)
        {
            _context.Tiendas.Update(tienda);
            _context.SaveChanges();
        }

        public void EliminarTienda(int tiendaId)
        {
            var tienda = _context.Tiendas.Find(tiendaId);
            if (tienda != null)
            {
                _context.Tiendas.Remove(tienda);
                _context.SaveChanges();
            }
        }
    }


}
