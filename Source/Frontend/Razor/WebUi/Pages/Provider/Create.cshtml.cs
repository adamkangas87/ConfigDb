using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance.Contexts;
using Application.Features.Provider.Models;

namespace WebUi.Pages.Provider
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CreateProviderModel Provider { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Providers == null || Provider == null)
            {
                return Page();
            }

            _context.Providers.Add(new Domain.Entities.Provider { Name = Provider.Name});
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
