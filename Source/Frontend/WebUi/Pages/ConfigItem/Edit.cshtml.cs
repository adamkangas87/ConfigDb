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

namespace WebUi.Pages.ConfigItem
{
    public class EditModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public EditModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Entities.ConfigItem ConfigItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ConfigItems == null)
            {
                return NotFound();
            }

            var configitem =  await _context.ConfigItems.FirstOrDefaultAsync(m => m.Id == id);
            if (configitem == null)
            {
                return NotFound();
            }
            ConfigItem = configitem;
           ViewData["ConfigTypeId"] = new SelectList(_context.ConfigTypes, "Id", "Name");
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

            _context.Attach(ConfigItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigItemExists(ConfigItem.Id))
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

        private bool ConfigItemExists(Guid id)
        {
          return (_context.ConfigItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
