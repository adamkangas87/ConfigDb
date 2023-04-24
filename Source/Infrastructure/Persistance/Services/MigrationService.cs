using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Services
{
    public class MigrationService : IMigrationService
    {
        private readonly DataContext _context;
        public MigrationService(DataContext context)
        {
            _context = context;
        }

        public async Task MigrateAsync()
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
    }
}
