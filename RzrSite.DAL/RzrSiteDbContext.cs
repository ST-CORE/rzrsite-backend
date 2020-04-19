using Microsoft.EntityFrameworkCore;
using RzrSite.Models.Entities;

namespace RzrSite.DAL
{
  public class RzrSiteDbContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //TODO: Add actual path for release
#if DEBUG
      optionsBuilder
        .UseSqlite(@"Data Source=../Database/RzrSite.db");
#else
      optionsBuilder
        .UseSqlite(@"Data Source=./out/RzrSite.db");
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Category>().ToTable("Categories");
    }
  }
}
