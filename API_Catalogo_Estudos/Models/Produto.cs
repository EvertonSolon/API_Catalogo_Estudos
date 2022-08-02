namespace API_Catalogo_Estudos.Models;

public class Produto
{
    public Produto()
    {
        Categoria = new Categoria();
    }

    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }  
}
