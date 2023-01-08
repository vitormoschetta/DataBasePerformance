namespace Modeling2.Models;

// Essa é uma tabela de relacionamento entre filial e produto.
// Ela é necessária para armazenar para quais filiais um produto um determinado produto foi enviado para o catálogo.
// Ou seja, um produto desse cliente precisa ser enviado para o catálogo de todas as filiais do cliente, que pertence a outro domínio do negócio.
public class BranchProduct
{
    public Branch Branch { get; set; } = null!;
    public string BranchDocument { get; set; } = string.Empty;

    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }

    public bool WasSentToCatalog { get; set; } // Armazena o status de envio do produto para o catálogo da filial
}
