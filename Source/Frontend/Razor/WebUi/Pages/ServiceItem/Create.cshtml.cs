using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Persistance.Contexts;
using Application.Features.ServiceItem.Models;

namespace WebUi.Pages.ServiceItem
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Country");
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Name");
            ViewData["ServiceLevelId"] = new SelectList(_context.ServiceLevels, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.ServiceTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CreateServiceItemModel ServiceItem { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ServiceItems == null || ServiceItem == null)
            {
                return Page();
            }

            _context.ServiceItems.Add(new Domain.Entities.ServiceItem { Name = ServiceItem.Name, ProviderId = ServiceItem.ProviderId, LocationId = ServiceItem.LocationId, ServiceLevelId = ServiceItem.ServiceLevelId, TypeId = ServiceItem.TypeId });
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
