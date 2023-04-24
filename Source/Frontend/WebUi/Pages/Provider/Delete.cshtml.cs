using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.Provider
{
    public class DeleteModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public DeleteModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Domain.Entities.Provider Provider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);

            if (provider == null)
            {
                return NotFound();
            }
            else 
            {
                Provider = provider;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }
            var provider = await _context.Providers.FindAsync(id);

            if (provider != null)
            {
                Provider = provider;
                _context.Providers.Remove(Provider);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
