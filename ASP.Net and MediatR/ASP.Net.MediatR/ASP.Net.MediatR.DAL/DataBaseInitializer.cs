using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ASP.Net.MediatR.DAL
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
    public class DataBaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataBaseInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);
        }
    }
}
