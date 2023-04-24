﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.Provider
{
    public class IndexModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public IndexModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        public IList<Domain.Entities.Provider> Provider { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Providers != null)
            {
                Provider = await _context.Providers
                .Include(p => p.Location).ToListAsync();
            }
        }
    }
}
