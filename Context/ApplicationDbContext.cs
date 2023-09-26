using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Entities;

namespace RestauranteAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        // Mapeo para reconocer en la base de datos
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<DetallePedido> DetallePedidos { get; set; }

        // Se conecta al motor de la base de datos
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
