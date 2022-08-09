using API_Catalogo_Estudos.Context;
using API_Catalogo_Estudos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Catalogo_Estudos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos?.ToList();

            if (!produtos.Any())
                return NotFound("Produtos não encontrados!");

            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos?.FirstOrDefault(x => x.Id == id);

            if(produto == null)
                return NotFound("Produto não encontrado!");

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto == null)
                return BadRequest();

            //Está trabalhando no modo desconectado. 
            //Esta ação está apenas na memória.
            _context.Produtos?.Add(produto);

            //O comando abaixo, faz persistir no BD.
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id}, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos?.FirstOrDefault(p => p.Id == id);
            //var produto = _context.Produtos.Find(id); 

            if (produto is null)
            {
                return NotFound("Produto não localizado...");
            }
            _context.Produtos?.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }

    }
}
