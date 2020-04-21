using Microsoft.EntityFrameworkCore;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;

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
      modelBuilder.Entity<Category>().HasMany(c => (IList<Series>)c.Series).WithOne();

      modelBuilder.Entity<Category>().ToTable("Categories");
      modelBuilder.Entity<Series>().ToTable("Series");
    }
  }
}
