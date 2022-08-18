using Microsoft.EntityFrameworkCore;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Repository.Repositories
{
    public class PerformerRepository : GenericRepository<Performer>, IPerformerRepository
    {
        public PerformerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Performer>> GetAllWithData()
        {
            return await _context.Performers.Include(x => x.MoviePerformer).ToListAsync();
        }

        public async Task<Performer> GetAllWithDataById(int id)
        {
            return await _context.Performers.Include(x => x.MoviePerformer).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
