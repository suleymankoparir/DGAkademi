using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Services
{
    public interface IDirectorService : IService<Director>
    {
        public Task<List<DirectorGetAllDto>> getAllData();
        public Task<DirectorGetAllDto> GetAllWithDataById(int id);
    }
}
