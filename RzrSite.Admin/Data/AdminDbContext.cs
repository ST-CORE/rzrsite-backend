using Microsoft.EntityFrameworkCore;
using RzrSite.Admin.Models.User;

namespace RzrSite.Admin.Data
{
  public class AdminDbContext: DbContext
  {
    public DbSet<UserModel> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite(@"Data Source=../Database/RzrSite.Admin.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserModel>().ToTable("Users");
    }
  }
}
