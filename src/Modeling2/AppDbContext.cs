using Microsoft.EntityFrameworkCore;
using Modeling2.Models;

namespace Modeling2;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Branch> Branches { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<BranchProduct> BranchProducts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasKey(c => c.Document);

        modelBuilder.Entity<Branch>().HasKey(b => b.Document);
        modelBuilder.Entity<Branch>().HasOne(b => b.Customer).WithMany(c => c.Branches).HasForeignKey(b => b.CustomerDocument);

        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Category>().HasOne(c => c.Customer).WithMany(c => c.Categories).HasForeignKey(c => c.CustomerDocument);

        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<Product>().HasOne(p => p.Customer).WithMany(c => c.Products).HasForeignKey(p => p.CustomerDocument);

        modelBuilder.Entity<BranchProduct>().HasKey(bp => new { bp.BranchDocument, bp.ProductId });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=modeling2;Username=modeling2;Password=modeling2;Application Name=Modeling2;CommandTimeout=30");
    }
}
