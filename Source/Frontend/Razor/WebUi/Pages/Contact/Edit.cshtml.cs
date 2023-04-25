using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Application.Features.Contact.Models;

namespace WebUi.Pages.Contact
{
    public class EditModel : PageModel
    {
        private readonly DataContext _context;

        public EditModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditContactModel Contact { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact =  await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            Contact.Id = contact.Id;
            Contact.Name = contact.Name;
            Contact.Email = contact.Email;
            Contact.Number = contact.Number;
            Contact.Name = contact.Name;
            Contact.ProviderId = contact.ProviderId;
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == Contact.Id);
            contact.Name = Contact.Name;
            contact.Email = Contact.Email;
            contact.Number = Contact.Number;
            contact.Name = Contact.Name;
            contact.ProviderId = Contact.ProviderId;
            _context.Attach(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Contact.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactExists(Guid id)
        {
          return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
