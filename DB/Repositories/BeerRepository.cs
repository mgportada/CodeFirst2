using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly ApplicationContext _context;
        public BeerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<Beer?> GetAsync(int id)
        {
            return _context.Beers.FirstOrDefaultAsync(x => x.BeerID == id);
        }

        public async Task<int> InsertAsync(Beer beer)
        {
            _context.Beers.Add(beer);
            await _context.SaveChangesAsync();
            return beer.BeerID;
        }

        public async Task UpdateAsync(Beer beer)
        {
            _context.Update(beer);
            await _context.SaveChangesAsync();
        }
    }
}
