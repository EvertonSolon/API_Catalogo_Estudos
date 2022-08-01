namespace API_Catalogo_Estudos.Models;

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

}
