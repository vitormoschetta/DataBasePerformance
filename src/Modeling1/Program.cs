
using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Modeling1;

var arguments = Environment.GetCommandLineArgs();

try
{
    using var context = new AppDbContext();

    await context.Database.MigrateAsync();

    if (arguments.Length > 1 && arguments[1] == "seed")
    {
        await context.CleanData();
        await context.SeedData();
        Console.WriteLine("Data seeded");
    }

    await ExecuteQuery(context);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


async Task ExecuteQuery(AppDbContext context)
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();

    var query = context.Products
        .Include(x => x.Category)
        .Include(x => x.BranchProducts)
        .Where(x => 
            x.Customer.Document == "0123456789" &&
            x.BranchProducts.Any(y => y.WasSentToCatalog == false))
        .AsNoTracking();

    var products = await query.ToListAsync();

    stopWatch.Stop();

    var message = new StringBuilder();
    message.AppendLine($"Total products: {products.Count}");
    message.AppendLine($"Total branches: {products.Sum(x => x.BranchProducts.Count)}");
    message.AppendLine($"Query executed in: ");
    message.AppendLine($"{stopWatch.Elapsed.TotalMilliseconds} ms");
    message.AppendLine($"{stopWatch.Elapsed.TotalSeconds} s");    

    Console.WriteLine(message.ToString());

    Console.WriteLine("Executar novamente? (S/N)");
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.S)
    {
        Console.WriteLine();
        await ExecuteQuery(context);
    }    
}
