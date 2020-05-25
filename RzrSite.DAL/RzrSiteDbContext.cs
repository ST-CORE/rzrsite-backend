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
    public DbSet<Advantage> Advantages { get; set; }

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

      modelBuilder.Entity<Advantage>().HasOne(ad => (DbFile)ad.Icon).WithMany();

      modelBuilder.Entity<Product>().HasMany(p => (IList<Feature>)p.Features).WithOne();
      modelBuilder.Entity<Product>().HasMany(p => (IList<Image>)p.Images).WithOne();
      modelBuilder.Entity<Product>().HasOne(p => (Image)p.PrimaryImage).WithOne();

      modelBuilder.Entity<Feature>().HasOne(p => (FeatureType)p.Type).WithMany();

      modelBuilder.Entity<Image>().HasOne(p => (DbFile)p.Full).WithMany();
      modelBuilder.Entity<Image>().HasOne(p => (DbFile)p.Thumb).WithMany();

      modelBuilder.Entity<Category>().ToTable("Categories");
      modelBuilder.Entity<ProductLine>().ToTable("ProductLines");
      modelBuilder.Entity<Product>().ToTable("Products");
      modelBuilder.Entity<Advantage>().ToTable("Advantages");
      modelBuilder.Entity<Document>().ToTable("Documents");
      modelBuilder.Entity<Image>().ToTable("Image");
      modelBuilder.Entity<DbFile>().ToTable("DbFile");
    }
  }
}
