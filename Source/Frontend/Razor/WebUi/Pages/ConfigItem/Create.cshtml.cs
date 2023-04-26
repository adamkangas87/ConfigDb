using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Persistance.Contexts;
using Application.Features.ConfigItem.Models;

namespace WebUi.Pages.ConfigItem
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TypeId"] = new SelectList(_context.ConfigTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CreateConfigItemModel ConfigItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ConfigItems == null || ConfigItem == null)
            {
                return Page();
            }

            _context.ConfigItems.Add(new Domain.Entities.ConfigItem { Name = ConfigItem.Name, TypeId = ConfigItem.TypeId});
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
