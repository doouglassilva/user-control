using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Entities;

namespace Usuario.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=DESKTOP-7OCGRGJ;database=db_usuarios;Trusted_connection=true;Encrypt=false;TrustServerCertificate=true");
            }
        }

    }
}
