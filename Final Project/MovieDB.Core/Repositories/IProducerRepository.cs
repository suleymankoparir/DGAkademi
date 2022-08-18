using MovieDB.Core.Models;

namespace MovieDB.Core.Repositories
{
    public interface IProducerRepository : IGenericRepository<Producer>
    {
        public Task<List<Producer>> GetAllWithData();
        public Task<Producer> GetAllWithDataById(int id);
    }
}