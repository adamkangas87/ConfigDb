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
    public class IndexModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public IndexModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        public IList<Domain.Entities.ServiceItem> ServiceItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ServiceItems != null)
            {
                ServiceItem = await _context.ServiceItems
                .Include(s => s.Location)
                .Include(s => s.Provider)
                .Include(s => s.ServiceLevel)
                .Include(s => s.Type).ToListAsync();
            }
        }
    }
}
