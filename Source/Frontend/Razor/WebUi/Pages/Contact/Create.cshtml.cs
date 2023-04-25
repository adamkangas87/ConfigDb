using Application.Features.Contact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance.Contexts;

namespace WebUi.Pages.Contact
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
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CreateContactModel Contact { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Contacts == null || Contact == null)
            {
                return Page();
            }

            var data = new Domain.Entities.Contact { Name = Contact.Name, Email = Contact.Email, Number = Contact.Number, ProviderId = Contact.ProviderId };

            _context.Contacts.Add(data);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
