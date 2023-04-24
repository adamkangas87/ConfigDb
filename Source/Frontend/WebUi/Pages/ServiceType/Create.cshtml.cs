using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Persistance.Contexts;

namespace WebUi.Pages.ServiceType
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
        public Domain.Entities.ServiceType ServiceType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ServiceTypes == null || ServiceType == null)
            {
                return Page();
            }

            _context.ServiceTypes.Add(ServiceType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
