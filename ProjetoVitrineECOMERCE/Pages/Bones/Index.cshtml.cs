using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoVitrineECOMERCE.Data;
using ProjetoVitrineECOMERCE.Models;
using ProjetoVitrineECOMERCE.Services; // Importar o servi�o de carrinho
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVitrineECOMERCE.Pages.Bones
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarrinhoService _carrinhoService; // Adicionar o servi�o de carrinho

        public IndexModel(ApplicationDbContext context, ICarrinhoService carrinhoService) // Injetar o servi�o
        {
            _context = context;
            _carrinhoService = carrinhoService;
        }

        public IList<Bone> Bones { get; set; }

        // M�todo para carregar a lista de bon�s
        public async Task OnGetAsync()
        {
            Bones = await _context.Bones.ToListAsync();
        }

        // Novo m�todo para adicionar ao carrinho
        public async Task<IActionResult> OnPostAdicionarAoCarrinhoAsync(int id, int quantidade)
        {
            if (quantidade < 1)
            {
                quantidade = 1; // Garantir que a quantidade m�nima seja 1
            }

            // Chamar o servi�o de carrinho para adicionar o item
            await _carrinhoService.AdicionarItemAoCarrinhoAsync(id, quantidade);

            // Redirecionar de volta para a p�gina de listagem
            return RedirectToPage();
        }
    }
}
