using lojinhaLegal.Repository;
using LojinhaLegal.Models.context;
using LojinhaLegal.Models.entity;
using Microsoft.EntityFrameworkCore;

namespace LojinhaLegal.Models.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public Produto? ObterProdutoPorId(int id)
        {
            return _context.ProdutoEntity.Find(id);
        }

        public IEnumerable<Produto> ObterTodosProdutos()
        {
            return _context.ProdutoEntity.ToList();
        }

        public Produto AdicionarProduto(Produto produto)
        {
            _context.ProdutoEntity.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public Produto AtualizarProduto(Produto produto)
        {
            _context.ProdutoEntity.Update(produto);
            _context.SaveChanges();
            return produto;
        }

        public bool RemoverProduto(int id)
        {
            var produto = _context.ProdutoEntity.Find(id);
            if (produto == null)
            {
                return false;
            }

            _context.ProdutoEntity.Remove(produto);
            _context.SaveChanges();
            return true;
        }
    }
}
