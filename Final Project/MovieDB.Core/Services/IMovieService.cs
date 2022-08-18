using MovieDB.Core.DTOs;
using MovieDB.Core.Models;

namespace MovieDB.Core.Services
{
    public interface IMovieService : IService<Movie>
    {
        public Task<List<MovieGetAllDto>> getAllData();
        public Task<MovieGetAllDto> GetAllWithDataById(int id);
    }
}
