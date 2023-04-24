
namespace Persistance.Contexts
{
    public class DataContextSeed
    {
        private readonly DataContext _context;
        public DataContextSeed(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {

        }
    }
}
