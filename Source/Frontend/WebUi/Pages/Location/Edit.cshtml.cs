using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.Location
{
    public class EditModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public EditModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Entities.Location Location { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Locations == null)
            {
                return NotFound();
            }

            var location =  await _context.Locations.FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return NotFound();
            }
            Location = location;
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

            _context.Attach(Location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(Location.Id))
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

        private bool LocationExists(Guid id)
        {
          return (_context.Locations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
