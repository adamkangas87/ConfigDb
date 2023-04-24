
using Application.Interfaces;
using Persistance.Contexts;

namespace Persistance.Services
{
    public class SeedService : ISeedService
    {
        private readonly DataContextSeed _seed;
        public SeedService(DataContextSeed seed)
        {
            _seed = seed;
        }

        public async Task SeedAsync()
        {
            await _seed.SeedAsync();
        }
    }
}
