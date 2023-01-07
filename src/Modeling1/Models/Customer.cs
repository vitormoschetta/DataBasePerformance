namespace Modeling1.Models;

public class Customer
{
    public Guid Id { get; set; } // esse ID é algo necessário para o nosso modelo de negócio? Temos um Document que é um valor único, não poderia ser a chave primária?
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty; // coluna de consulta sera essa, e ele é um valor único, que pode ser um índice ou até mesmo uma chave primária
    public List<Branch> Branches { get; set; } = new();
    public List<Product> Products { get; set; } = new();
    public List<Category> Categories { get; set; } = new();
}
