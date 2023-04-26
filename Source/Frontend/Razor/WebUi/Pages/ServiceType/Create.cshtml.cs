using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistance.Contexts;
using Application.Features.ServiceType.Models;

namespace WebUi.Pages.ServiceType
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
            return Page();
        }

        [BindProperty]
        public CreateServiceTypeModel ServiceType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ServiceTypes == null || ServiceType == null)
            {
                return Page();
            }

            _context.ServiceTypes.Add(new Domain.Entities.ServiceType { Name = ServiceType.Name});
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
