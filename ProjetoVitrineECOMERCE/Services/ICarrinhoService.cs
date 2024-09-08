using ProjetoVitrineECOMERCE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVitrineECOMERCE.Services
{
    public interface ICarrinhoService
    {
        Task<List<CarrinhoItem>> GetCarrinhoItensAsync();
        Task AdicionarItemAoCarrinhoAsync(int boneId, int quantidade);
        Task RemoverItemDoCarrinhoAsync(int boneId);
        Task LimparCarrinhoAsync();
    }
}
