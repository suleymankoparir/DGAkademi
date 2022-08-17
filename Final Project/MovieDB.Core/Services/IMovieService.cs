using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Services
{
    public interface IMovieService:IService<Movie>
    {
        public Task<List<MovieGetDto>> getAllData();
        public Task<MovieGetDto> GetAllWithDataById(int id);
    }
}
