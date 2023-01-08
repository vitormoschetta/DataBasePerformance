
using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Modeling1;

var arguments = Environment.GetCommandLineArgs();

using var context = new AppDbContext() ?? throw new ArgumentNullException(nameof(AppDbContext));

var stopWatch = new Stopwatch();

try
{
    await context.Database.MigrateAsync();

    if (arguments.Length > 1 && arguments[1] == "--seed")
    {
        Console.WriteLine("Seeding data...");
        await context.CleanData();
        stopWatch.Start();
        await context.SeedData();
        stopWatch.Stop();
        Console.WriteLine($"Data seeded in {stopWatch.Elapsed.TotalSeconds} s");
        Console.WriteLine();
        stopWatch.Reset();
    }

    await ExecuteQuery();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


async Task ExecuteQuery()
{
    Console.WriteLine("Executing query...");

    stopWatch.Start();
    var gcBefore = GC.CollectionCount(0);

    var query = context?.Products
        .Include(x => x.Category)
        .Where(x =>
            x.Customer.Document == "0123456789" &&
            x.BranchProducts.Any(y => y.WasSentToCatalog == false) &&
            x.Category.CodeCatalog != null)
        .AsNoTracking()
        ?? throw new ArgumentNullException("query");

    var products = await query.ToListAsync();

    stopWatch.Stop();

    await PrintResult(
        stopWatch,
        gcBefore,
        totalProducts: products.Count,
        totalBranches: products.Sum(x => x.BranchProducts.Count));

    stopWatch.Reset();

    await Continue();
}


Task PrintResult(Stopwatch stopWatch, long gcBefore, int totalProducts, int totalBranches)
{
    var message = new StringBuilder();
    message.AppendLine($"Total products: {totalProducts}");
    message.AppendLine($"Total branches: {totalBranches}");
    message.AppendLine($"Query executed in: {stopWatch.Elapsed.TotalMilliseconds} ms ({stopWatch.Elapsed.TotalSeconds} s)");
    message.AppendLine($"Memory used: {GC.GetTotalMemory(false) / 1024 / 1024} MB");
    message.AppendLine($"Garbage collections: {GC.CollectionCount(0) - gcBefore}");

    Console.WriteLine(message.ToString());

    return Task.CompletedTask;
}

Task Continue()
{
    Console.WriteLine("Execute query again? (S/N)");
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.S)
    {
        Console.WriteLine();
        return ExecuteQuery();
    }

    return Task.CompletedTask;
}