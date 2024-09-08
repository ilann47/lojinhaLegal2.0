using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoVitrineECOMERCE.Models;
using ProjetoVitrineECOMERCE.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVitrineECOMERCE.Pages.Carrinho
{
    public class IndexModel : PageModel
    {
        private readonly ICarrinhoService _carrinhoService;

        public IndexModel(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public List<CarrinhoItem> CarrinhoItens { get; set; }

        public async Task OnGetAsync()
        {
            CarrinhoItens = await _carrinhoService.GetCarrinhoItensAsync();
        }

        public async Task<IActionResult> OnPostRemoverAsync(int id)
        {
            await _carrinhoService.RemoverItemDoCarrinhoAsync(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostLimparAsync()
        {
            await _carrinhoService.LimparCarrinhoAsync();
            return RedirectToPage();
        }
    }
}
