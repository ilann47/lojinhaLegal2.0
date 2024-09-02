using LojinhaLegal.Models.entity;

namespace lojinhaLegal.Repository
{
    public interface IProdutoRepository
    {
        Produto? ObterProdutoPorId(int id);
        IEnumerable<Produto> ObterTodosProdutos();
        Produto AdicionarProduto(Produto produto);
        Produto AtualizarProduto(Produto produto);
        bool RemoverProduto(int id);
    }
}
