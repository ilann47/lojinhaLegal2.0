using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoVitrineECOMERCE.Data;
using ProjetoVitrineECOMERCE.Models;
using ProjetoVitrineECOMERCE.Services; // Importar o serviço de carrinho
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVitrineECOMERCE.Pages.Bones
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarrinhoService _carrinhoService; // Adicionar o serviço de carrinho

        public IndexModel(ApplicationDbContext context, ICarrinhoService carrinhoService) // Injetar o serviço
        {
            _context = context;
            _carrinhoService = carrinhoService;
        }

        public IList<Bone> Bones { get; set; }

        // Método para carregar a lista de bonés
        public async Task OnGetAsync()
        {
            Bones = await _context.Bones.ToListAsync();
        }

        // Novo método para adicionar ao carrinho
        public async Task<IActionResult> OnPostAdicionarAoCarrinhoAsync(int id, int quantidade)
        {
            if (quantidade < 1)
            {
                quantidade = 1; // Garantir que a quantidade mínima seja 1
            }

            // Chamar o serviço de carrinho para adicionar o item
            await _carrinhoService.AdicionarItemAoCarrinhoAsync(id, quantidade);

            // Redirecionar de volta para a página de listagem
            return RedirectToPage();
        }
    }
}
