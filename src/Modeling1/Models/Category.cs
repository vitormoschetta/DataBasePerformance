namespace Modeling1.Models;

// Essa será uma tabela de De/Para. 
// Configuramos o código de categoria do cliente e um código de categoria do catálogo da empresa para que possamos fazer a conversão de uma para a outra antes de enviar para o catálogo.
public class Category
{
    // Aqui o ID é necessário, pois é uma tabela de De/Para que vai receber dados de diversos clientes, e o CodeCustomer e CodeBusiness não são únicos.
    // Mas, não seria mais performatico se fosse um inteiro?
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CodeCustomer { get; set; } = string.Empty;
    public string CodeCatalog { get; set; } = string.Empty;

    public Customer Customer { get; set; } = null!;
    public Guid CustomerId { get; set; } // A configuração de De/Para é feita por cliente, portanto precisamos de um ID de cliente.

    public List<Product> Products { get; set; } = new();
}
