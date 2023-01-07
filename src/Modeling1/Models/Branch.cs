namespace Modeling1.Models;

public class Branch
{
    public Guid Id { get; set; } // esse ID é algo necessário para o nosso modelo de negócio? Tendo em vista que o Document é um valor único, não poderia ser a chave primária?
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty; // coluna de consulta sera essa, e ele é um valor único, que pode ser um índice ou até mesmo uma chave primária
    public Customer Customer { get; set; } = null!;
    public Guid CustomerId { get; set; } // Essa chave estrangeira não poderia ser o Document do Customer?

    public List<BranchProduct> BranchProducts { get; set; } = new();
}