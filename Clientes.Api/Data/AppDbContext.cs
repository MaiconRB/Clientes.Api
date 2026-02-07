using Microsoft.EntityFrameworkCore;

namespace Clientes.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Cliente> Clientes { get; set; }
    }
}
