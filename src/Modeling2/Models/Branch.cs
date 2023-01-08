namespace Modeling2.Models;

public class Branch
{
    public string Document { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Customer Customer { get; set; } = null!;
    public string CustomerDocument { get; set; } = string.Empty;

    public List<BranchProduct> BranchProducts { get; set; } = new();
}