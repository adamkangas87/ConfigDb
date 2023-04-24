using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ConfigItem
{
    public class DetailsModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public DetailsModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

      public Domain.Entities.ConfigItem ConfigItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ConfigItems == null)
            {
                return NotFound();
            }

            var configitem = await _context.ConfigItems.FirstOrDefaultAsync(m => m.Id == id);
            if (configitem == null)
            {
                return NotFound();
            }
            else 
            {
                ConfigItem = configitem;
            }
            return Page();
        }
    }
}
