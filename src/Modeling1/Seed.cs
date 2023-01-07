using Modeling1.Models;

namespace Modeling1;

public static class Seed
{
    public static async Task SeedData(this AppDbContext context)
    {
        await SeedCustomers(context);
        await SeedCategories(context);
        await SeedProducts(context);
        await SeedBranches(context);
        await SeedBranchProducts(context);
    }

    public static async Task CleanData(this AppDbContext context)
    {
        context.BranchProducts.RemoveRange(context.BranchProducts);
        context.Products.RemoveRange(context.Products);
        context.Categories.RemoveRange(context.Categories);
        context.Branches.RemoveRange(context.Branches);
        context.Customers.RemoveRange(context.Customers);

        await context.SaveChangesAsync();
    }


    private static async Task SeedCustomers(AppDbContext context)
    {
        var customer = new Customer
        {
            Name = "Customer 1",
            Document = "0123456789"
        };

        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
    }


    private static async Task SeedCategories(AppDbContext context)
    {
        var customer = context.Customers.First();

        var category = new Category
        {
            Name = "Category 1",
            CodeCustomer = "1",
            CodeCatalog = "100",
            CustomerId = customer.Id
        };

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }


    private static async Task SeedProducts(AppDbContext context)
    {
        var customer = context.Customers.First();
        var category = context.Categories.First();

        for (int i = 1; i <= 10000; i++)
        {
            var product = new Product
            {
                Code = i.ToString(),
                Name = $"Product {i}",
                Description = $"Description {i}",
                Price = i * 0.1m,
                CustomerId = category.CustomerId,
                CategoryId = category.Id
            };

            await context.Products.AddAsync(product);
        }

        await context.SaveChangesAsync();
    }


    private static async Task SeedBranches(AppDbContext context)
    {
        var customer = context.Customers.First();

        for (int i = 1; i <= 10; i++)
        {
            var branch = new Branch
            {
                Name = $"Branch {i}",
                Document = $"{customer.Document}{i}",
                CustomerId = customer.Id
            };

            await context.Branches.AddAsync(branch);
        }

        await context.SaveChangesAsync();
    }


    private static async Task SeedBranchProducts(AppDbContext context)
    {
        var branches = context.Branches.ToList();
        var products = context.Products.ToList();

        foreach (var branch in branches)
        {
            foreach (var product in products)
            {
                var branchProduct = new BranchProduct
                {
                    BranchId = branch.Id,
                    ProductId = product.Id,
                    WasSentToCatalog = false
                };

                await context.BranchProducts.AddAsync(branchProduct);
            }
        }

        await context.SaveChangesAsync();
    }
}