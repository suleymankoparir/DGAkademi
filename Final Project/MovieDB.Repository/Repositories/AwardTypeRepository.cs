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
    public class AwardTypeRepository : GenericRepository<AwardType>, IAwardTypeRepository
    {
        public AwardTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<AwardType>> GetAllWithData()
        {
            return await _context.AwardsType.Include(x => x.Awards).ToListAsync();
        }

        public async Task<AwardType> GetAllWithDataById(int id)
        {
            return await _context.AwardsType.Include(x => x.Awards).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
