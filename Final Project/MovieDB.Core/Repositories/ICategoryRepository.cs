using MovieDB.Core.Models;

namespace MovieDB.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<List<Category>> GetAllWithData();
        public Task<Category> GetAllWithDataById(int id);
    }
}
