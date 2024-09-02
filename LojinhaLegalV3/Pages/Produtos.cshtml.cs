using LojinhaLegalV3.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojinhaLegalV3.Pages
{
    public class ProdutosModel : PageModel
    {
        private readonly AppDbContext _context;

        public ProdutosModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Produto> Produtos { get; private set; }

        public async Task OnGetAsync()
        {
            Produtos = await _context.Produtos.ToListAsync();
        }
    }
}
