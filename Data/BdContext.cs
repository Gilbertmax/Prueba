using Microsoft.EntityFrameworkCore;
using YourSolution.Entities;

namespace YourSolution.Data
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<RelacionArticuloTienda> RelacionesArticuloTienda { get; set; }
        public DbSet<RelacionClienteArticulo> RelacionesClienteArticulo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelacionArticuloTienda>()
                .HasKey(rt => new { rt.ArticuloID, rt.TiendaID });

            modelBuilder.Entity<RelacionClienteArticulo>()
                .HasKey(rc => new { rc.ClienteID, rc.ArticuloID });


            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { ClienteID = 1, Nombre = "Juan", Apellidos = "Perez", Direccion = "Calle A, Ciudad" }
            );

            modelBuilder.Entity<Tienda>().HasData(
                new Tienda { TiendaID = 1, Sucursal = "Sucursal 1", Direccion = "Calle B, Ciudad" }
            );

            modelBuilder.Entity<Articulo>().HasData(
                new Articulo { ArticuloID = 1, Codigo = "A001", Descripcion = "Articulo 1", Precio = 19.99, Stock = 100 }
            );

        }
    }
}
