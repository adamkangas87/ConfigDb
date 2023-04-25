using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistance.Contexts;
using Application.Features.Contact.Models;

namespace WebUi.Pages.Location
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
            return Page();
        }

        [BindProperty]
        public CreateLocationModel Location { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Locations == null || Location == null)
            {
                return Page();
            }

            _context.Locations.Add(new Domain.Entities.Location { Name = Location.Name,State = Location.State, Country = Location.Country});
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
