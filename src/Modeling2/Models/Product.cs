namespace Modeling2.Models;

public class Product
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }

    public Customer Customer { get; set; } = null!;
    public string CustomerDocument { get; set; } = string.Empty; // O código do produto pertence a um cliente, portanto precisamos de um documento de cliente.

    public List<BranchProduct> BranchProducts { get; set; } = new(); // O mesmo produto pode estar em várias filiais e ser contrado o status de envio. Por isso temos uma tabela de relacionamento.
}
