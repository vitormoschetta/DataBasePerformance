namespace Modeling1.Models;

public class Product
{
    // Esse ID é necessário, pois estaremos recebendo produtos de vários clientes, portanto o código do produto não será único.
    // Mas, não seria mais performatico se fosse um inteiro?
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty; // poderia ser um inteiro? depende do negócio, do tipo de valores que vamos receber...
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;

    // aqui temos uma relação de 1 para 1, ou seja, um produto só pode ter uma categoria. 
    // Nestes casos podemos utilizar novas colunas na tabela de produtos para armazenar os dados da categoria.
    // O De/Para é feito apenas em memória, e não no banco de dados. Isso seria mais performático?
    public Category Category { get; set; } = null!;
    public Guid CategoryId { get; set; }

    public Customer Customer { get; set; } = null!;
    public Guid CustomerId { get; set; } // O produto pertence a um cliente, portanto precisamos de um ID de cliente.

    public List<BranchProduct> BranchProducts { get; set; } = new(); // O mesmo produto pode estar em várias filiais e ser contrado o status de envio. Por isso temos uma tabela de relacionamento.
}
