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

namespace WebUi.Pages.ConfigType
{
    public class EditModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public EditModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Entities.ConfigType ConfigType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ConfigTypes == null)
            {
                return NotFound();
            }

            var configtype =  await _context.ConfigTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (configtype == null)
            {
                return NotFound();
            }
            ConfigType = configtype;
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

            _context.Attach(ConfigType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigTypeExists(ConfigType.Id))
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

        private bool ConfigTypeExists(Guid id)
        {
          return (_context.ConfigTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
