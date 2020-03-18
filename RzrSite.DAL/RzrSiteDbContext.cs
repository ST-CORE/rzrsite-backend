using Microsoft.EntityFrameworkCore;
using RzrSite.Models;

namespace RzrSite.DAL
{
  public class RzrSiteDbContext: DbContext
  {
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder opionsBuilder)
    {
      //TODO: Add actual path for release
      opionsBuilder
        .UseSqlite(@"Data Source=C:\Sources\RZR-SITE\rzrsite-backend\Database\RzrSite.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Category>().ToTable("Categories");
    }
  }
}
