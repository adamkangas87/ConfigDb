using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ServiceLevel
{
    public class DeleteModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public DeleteModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public    Domain.Entities.ServiceLevel ServiceLevel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ServiceLevels == null)
            {
                return NotFound();
            }

            var servicelevel = await _context.ServiceLevels.FirstOrDefaultAsync(m => m.Id == id);

            if (servicelevel == null)
            {
                return NotFound();
            }
            else 
            {
                ServiceLevel = servicelevel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.ServiceLevels == null)
            {
                return NotFound();
            }
            var servicelevel = await _context.ServiceLevels.FindAsync(id);

            if (servicelevel != null)
            {
                ServiceLevel = servicelevel;
                _context.ServiceLevels.Remove(ServiceLevel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
