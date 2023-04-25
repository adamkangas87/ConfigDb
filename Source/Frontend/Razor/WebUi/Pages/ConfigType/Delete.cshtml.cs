using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ConfigType
{
    public class DeleteModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public DeleteModel(Persistance.Contexts.DataContext context)
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

            var configtype = await _context.ConfigTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (configtype == null)
            {
                return NotFound();
            }
            else 
            {
                ConfigType = configtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.ConfigTypes == null)
            {
                return NotFound();
            }
            var configtype = await _context.ConfigTypes.FindAsync(id);

            if (configtype != null)
            {
                ConfigType = configtype;
                _context.ConfigTypes.Remove(ConfigType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
