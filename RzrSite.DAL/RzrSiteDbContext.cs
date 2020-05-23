using Microsoft.EntityFrameworkCore;
using RzrSite.Models.Entities;
using System.Collections.Generic;

namespace RzrSite.DAL
{
  public class RzrSiteDbContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductLine> ProductLines { get; set; }
    public DbSet<DbFile> Files { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
      optionsBuilder
        .UseSqlite(@"Data Source=../Database/RzrSite.db");
#else
      optionsBuilder
        .UseSqlite(@"Data Source=RzrSite.db");  
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Category>().HasMany(c => (IList<ProductLine>)c.ProductLines).WithOne();

      modelBuilder.Entity<ProductLine>().HasMany(pl => (IList<Advantage>)pl.Advantages).WithOne();
      modelBuilder.Entity<ProductLine>().HasMany(pl => (IList<Product>)pl.Products).WithOne();
      modelBuilder.Entity<ProductLine>().HasMany(pl => (IList<Document>)pl.Documents).WithOne();

      modelBuilder.Entity<Category>().ToTable("Categories");
      modelBuilder.Entity<ProductLine>().ToTable("ProductLines");
      modelBuilder.Entity<Product>().ToTable("Products");
      modelBuilder.Entity<Advantage>().ToTable("Advantages");
      modelBuilder.Entity<Document>().ToTable("Documents");
      modelBuilder.Entity<DbFile>().ToTable("DbFile");
    }
  }
}
