using Microsoft.EntityFrameworkCore;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;

namespace MovieDB.Repository.Repositories
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Producer>> GetAllWithData()
        {
            return await _context.Producers.Include(x => x.MovieProducer).ToListAsync();
        }

        public async Task<Producer> GetAllWithDataById(int id)
        {
            return await _context.Producers.Include(x => x.MovieProducer).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
