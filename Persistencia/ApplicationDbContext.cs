using Microsoft.EntityFrameworkCore;

namespace Zoologico.API.Persistencia;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Define tus entidades aquí
    public DbSet<YourEntity> YourEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura tus modelos aquí si es necesario
    }
}
