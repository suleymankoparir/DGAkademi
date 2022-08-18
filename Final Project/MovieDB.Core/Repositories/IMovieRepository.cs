using MovieDB.Core.Models;

namespace MovieDB.Core.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        public Task<List<Movie>> GetAllWithData();
        public Task<Movie> GetAllWithDataById(int id);
    }
}
