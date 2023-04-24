using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ServiceType
{
    public class DetailsModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public DetailsModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

      public Domain.Entities.ServiceType ServiceType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ServiceTypes == null)
            {
                return NotFound();
            }

            var servicetype = await _context.ServiceTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (servicetype == null)
            {
                return NotFound();
            }
            else 
            {
                ServiceType = servicetype;
            }
            return Page();
        }
    }
}
