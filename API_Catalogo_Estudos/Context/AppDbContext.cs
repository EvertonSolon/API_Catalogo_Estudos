using API_Catalogo_Estudos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Catalogo_Estudos.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    { }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
}
