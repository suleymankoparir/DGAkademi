using Microsoft.EntityFrameworkCore;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;

namespace MovieDB.Repository.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Movie>> GetAllWithData()
        {
            return await _context.Movies
                .Include(x => x.MovieCategory)
                .Include(x => x.MovieAward)
                .Include(x => x.MovieDirector)
                .Include(x => x.MovieProducer)
                .Include(x => x.MoviePerformer)
                .Include(x => x.Reviews)
                .Include(x => x.MovieType)
                .ToListAsync();
        }

        public async Task<Movie> GetAllWithDataById(int id)
        {
            return await _context.Movies.Where(x => x.Id == id)
                .Include(x => x.MovieCategory)
                .Include(x => x.MovieAward)
                .Include(x => x.MovieDirector)
                .Include(x => x.MovieProducer)
                .Include(x => x.MoviePerformer)
                .Include(x => x.MovieType)
                .Include(x => x.Reviews).FirstOrDefaultAsync();
        }
    }
}
