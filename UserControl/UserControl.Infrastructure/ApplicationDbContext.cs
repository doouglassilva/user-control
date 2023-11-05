using Microsoft.EntityFrameworkCore;
using UserControl.Domain.Entities;

namespace UserControl.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais, como relacionamentos, podem ser definidas aqui.
        }
    }
}
