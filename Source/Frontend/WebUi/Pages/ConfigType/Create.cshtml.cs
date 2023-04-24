using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ConfigType
{
    public class CreateModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public CreateModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Domain.Entities.ConfigType ConfigType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ConfigTypes == null || ConfigType == null)
            {
                return Page();
            }

            _context.ConfigTypes.Add(ConfigType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
