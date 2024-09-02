using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LojinhaLegal.Models.context;
using LojinhaLegal.Models.entity;

namespace lojinhaLegal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LojinhaLegal.Models.context.DataContext _context;

        public IndexModel(LojinhaLegal.Models.context.DataContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _context.ProdutoEntity.ToListAsync();
        }
    }
}
