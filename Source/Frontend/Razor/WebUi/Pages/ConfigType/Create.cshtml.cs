using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance.Contexts;
using Application.Features.ConfigType.Models;

namespace WebUi.Pages.ConfigType
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
        ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CreateConfigTypeModel ConfigType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ConfigTypes == null || ConfigType == null)
            {
                return Page();
            }

            _context.ConfigTypes.Add(new Domain.Entities.ConfigType { Name = ConfigType.Name, ProviderId = ConfigType.ProviderId });
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
