using Microsoft.EntityFrameworkCore;
using ProjetoVitrineECOMERCE.Data;
using ProjetoVitrineECOMERCE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVitrineECOMERCE.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _sessaoCarrinhoId;

        public CarrinhoService(ApplicationDbContext context)
        {
            _context = context;
            _sessaoCarrinhoId = "CarrinhoDeCompras";  // Identificador da sessão do carrinho.
        }

        public async Task<List<CarrinhoItem>> GetCarrinhoItensAsync()
        {
            return await _context.Set<CarrinhoItem>()
                                 .Include(c => c.Bone)
                                 .ToListAsync();
        }

        public async Task AdicionarItemAoCarrinhoAsync(int boneId, int quantidade)
        {
            var bone = await _context.Bones.FindAsync(boneId);
            if (bone == null)
                return;

            var carrinhoItem = await _context.Set<CarrinhoItem>()
                                             .FirstOrDefaultAsync(ci => ci.BoneId == boneId);

            if (carrinhoItem == null)
            {
                carrinhoItem = new CarrinhoItem
                {
                    BoneId = boneId,
                    Bone = bone,
                    Quantidade = quantidade
                };
                _context.Set<CarrinhoItem>().Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.Quantidade += quantidade;
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoverItemDoCarrinhoAsync(int boneId)
        {
            var carrinhoItem = await _context.Set<CarrinhoItem>()
                                             .FirstOrDefaultAsync(ci => ci.BoneId == boneId);

            if (carrinhoItem != null)
            {
                _context.Set<CarrinhoItem>().Remove(carrinhoItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task LimparCarrinhoAsync()
        {
            var itensCarrinho = await _context.Set<CarrinhoItem>().ToListAsync();
            _context.Set<CarrinhoItem>().RemoveRange(itensCarrinho);
            await _context.SaveChangesAsync();
        }
    }
}
