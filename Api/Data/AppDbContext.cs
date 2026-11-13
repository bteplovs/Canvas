

namespace Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Canvas> Canvases { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}
