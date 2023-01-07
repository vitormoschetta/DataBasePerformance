using Microsoft.EntityFrameworkCore;
using Modeling1.Models;

namespace Modeling1;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Branch> Branches { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<BranchProduct> BranchProducts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasKey(c => c.Id);

        modelBuilder.Entity<Branch>().HasKey(b => b.Id);
        modelBuilder.Entity<Branch>().HasOne(b => b.Customer).WithMany(c => c.Branches).HasForeignKey(b => b.CustomerId);

        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Category>().HasOne(c => c.Customer).WithMany(c => c.Categories).HasForeignKey(c => c.CustomerId);

        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<Product>().HasOne(p => p.Customer).WithMany(c => c.Products).HasForeignKey(p => p.CustomerId);

        modelBuilder.Entity<BranchProduct>().HasKey(bp => bp.Id);
        modelBuilder.Entity<BranchProduct>().HasOne(bp => bp.Branch).WithMany(b => b.BranchProducts).HasForeignKey(bp => bp.BranchId);
        modelBuilder.Entity<BranchProduct>().HasOne(bp => bp.Product).WithMany(p => p.BranchProducts).HasForeignKey(bp => bp.ProductId);

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=modeling1;Password=modeling1;Application Name=Modeling1;CommandTimeout=30");
    }
}
