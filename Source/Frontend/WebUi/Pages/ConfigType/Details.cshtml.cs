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
    public class DetailsModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public DetailsModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

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
    }
}
