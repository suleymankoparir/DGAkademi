using MovieDB.Core.Models;
using MovieDB.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Repositories
{
    public interface IMovieRepository: IGenericRepository<Movie>
    {
        public Task<List<Movie>> GetAllWithData();
        public Task<Movie> GetAllWithDataById(int id);
    }
}
