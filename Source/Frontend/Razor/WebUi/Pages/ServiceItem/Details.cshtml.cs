using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ServiceItem
{
    public class DetailsModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public DetailsModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

      public Domain.Entities.ServiceItem ServiceItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ServiceItems == null)
            {
                return NotFound();
            }

            var serviceitem = await _context.ServiceItems.FirstOrDefaultAsync(m => m.Id == id);
            if (serviceitem == null)
            {
                return NotFound();
            }
            else 
            {
                ServiceItem = serviceitem;
            }
            return Page();
        }
    }
}
