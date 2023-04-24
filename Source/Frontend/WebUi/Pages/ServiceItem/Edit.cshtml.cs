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

namespace WebUi.Pages.ServiceItem
{
    public class EditModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public EditModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Entities.ServiceItem ServiceItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ServiceItems == null)
            {
                return NotFound();
            }

            var serviceitem =  await _context.ServiceItems.FirstOrDefaultAsync(m => m.Id == id);
            if (serviceitem == null)
            {
                return NotFound();
            }
            ServiceItem = serviceitem;
           ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Country");
           ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Name");
           ViewData["ServiceLevelId"] = new SelectList(_context.ServiceLevels, "Id", "Name");
           ViewData["TypeId"] = new SelectList(_context.ServiceTypes, "Id", "Name");
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

            _context.Attach(ServiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceItemExists(ServiceItem.Id))
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

        private bool ServiceItemExists(Guid id)
        {
          return (_context.ServiceItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
