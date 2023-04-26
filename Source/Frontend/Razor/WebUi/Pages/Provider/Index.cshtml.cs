using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
                Provider = await _context.Providers.ToListAsync();
            }
        }
    }
}
