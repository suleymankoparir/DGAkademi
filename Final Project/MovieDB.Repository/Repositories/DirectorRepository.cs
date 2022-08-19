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
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Director>> GetAllWithData()
        {
            return await _context.Directors.Include(x => x.MovieDirector).ToListAsync();
        }

        public async Task<Director> GetAllWithDataById(int id)
        {
            return await _context.Directors.Include(x => x.MovieDirector).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
