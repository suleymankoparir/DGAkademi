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
    public class AwardRepository : GenericRepository<Award>, IAwardRepository
    {
        public AwardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Award>> GetAllWithData()
        {
            return await _context.Awards.Include(x => x.MovieAward).ToListAsync();
        }

        public async Task<Award> GetAllWithDataById(int id)
        {
            return await _context.Awards.Include(x => x.MovieAward).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
