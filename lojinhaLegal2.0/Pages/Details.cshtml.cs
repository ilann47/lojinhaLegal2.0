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
    public class DetailsModel : PageModel
    {
        private readonly LojinhaLegal.Models.context.DataContext _context;

        public DetailsModel(LojinhaLegal.Models.context.DataContext context)
        {
            _context = context;
        }

        public Produto Produto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.ProdutoEntity.FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                Produto = produto;
            }
            return Page();
        }
    }
}
