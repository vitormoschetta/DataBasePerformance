namespace Modeling1.Models;

// Essa é uma tabela de relacionamento entre filial e produto.
// Ela é necessária para armazenar para quais filiais um produto um determinado produto foi enviado para o catálogo.
// Ou seja, um produto desse cliente precisa ser enviado para o catálogo de todas as filiais do cliente, que pertence a outro domínio do negócio.
public class BranchProduct
{
    // Esse ID é realmente necessário? 
    // Já que é uma tabela de relacionamento entre filial e produto, não poderiamos usar o ID da filial e o ID do produto como chave composta?
    public Guid Id { get; set; }

    public Branch Branch { get; set; } = null!;
    public Guid BranchId { get; set; }

    public Product Product { get; set; } = null!;
    public Guid ProductId { get; set; }

    public bool WasSentToCatalog { get; set; } // Armazena o status de envio do produto para o catálogo da filial
}
