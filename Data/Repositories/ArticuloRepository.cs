using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSolution.Data;

namespace YourSolucion.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly YourDbContext _context;

        public ArticuloRepository(YourDbContext context)
        {
            _context = context;
        }

        public Articulo ObtenerArticuloPorId(int articuloId)
        {
            return _context.Articulos.FirstOrDefault(a => a.ArticuloID == articuloId);
        }

        public List<Articulo> ObtenerTodosArticulos()
        {
            return _context.Articulos.ToList();
        }

        public void CrearArticulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            _context.SaveChanges();
        }

        public void ActualizarArticulo(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            _context.SaveChanges();
        }

        public void EliminarArticulo(int articuloId)
        {
            var articulo = _context.Articulos.Find(articuloId);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                _context.SaveChanges();
            }
        }
    }

}
