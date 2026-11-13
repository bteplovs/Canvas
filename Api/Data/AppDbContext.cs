using canvasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace canvasApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
