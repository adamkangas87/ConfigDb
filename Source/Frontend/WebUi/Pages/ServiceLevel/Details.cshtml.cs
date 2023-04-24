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
    public class DetailsModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public DetailsModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

      public Domain.Entities.ServiceLevel ServiceLevel { get; set; } = default!; 

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
    }
}
