using Microsoft.EntityFrameworkCore;
using task3.Domain.Entities;

namespace task3.Domain.EF
{
    public class FilmsStoreDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public FilmsStoreDbContext(DbContextOptions<FilmsStoreDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
