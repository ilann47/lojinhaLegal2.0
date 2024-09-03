using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LojinhaLegalV3.Data;

namespace LojinhaLegalV3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LojinhaLegalV3.Data.AppDbContext _context;

        public IndexModel(LojinhaLegalV3.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _context.Produtos.ToListAsync();
        }
    }
}
