using Microsoft.EntityFrameworkCore;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;

namespace MovieDB.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAllWithData()
        {
            return await _context.Categories.Include(x => x.MovieCategory).ToListAsync();
        }

        public async Task<Category> GetAllWithDataById(int id)
        {
            return await _context.Categories.Include(x => x.MovieCategory).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
