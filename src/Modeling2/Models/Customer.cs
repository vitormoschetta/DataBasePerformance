namespace Modeling2.Models;

public class Customer
{
    public string Document { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public List<Branch> Branches { get; set; } = new();
    public List<Product> Products { get; set; } = new();
    public List<Category> Categories { get; set; } = new();
}
