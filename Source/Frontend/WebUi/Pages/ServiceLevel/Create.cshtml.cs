﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ServiceLevel
{
    public class CreateModel : PageModel
    {
        private readonly Persistance.Contexts.DataContext _context;

        public CreateModel(Persistance.Contexts.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.ServiceLevel ServiceLevel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ServiceLevels == null || ServiceLevel == null)
            {
                return Page();
            }

            _context.ServiceLevels.Add(ServiceLevel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
