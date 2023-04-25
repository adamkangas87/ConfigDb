using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ServiceItem
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
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Country");
        ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Name");
        ViewData["ServiceLevelId"] = new SelectList(_context.ServiceLevels, "Id", "Name");
        ViewData["TypeId"] = new SelectList(_context.ServiceTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Domain.Entities.ServiceItem ServiceItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ServiceItems == null || ServiceItem == null)
            {
                return Page();
            }

            _context.ServiceItems.Add(ServiceItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
