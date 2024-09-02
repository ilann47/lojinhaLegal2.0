using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LojinhaLegal.Models.context;
using LojinhaLegal.Models.entity;

namespace lojinhaLegal.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LojinhaLegal.Models.context.DataContext _context;

        public CreateModel(LojinhaLegal.Models.context.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Produto Produto { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProdutoEntity.Add(Produto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
