using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Services
{
    public interface IUserService : IService<User>
    {
        public Task<List<UserGetAllDto>> getAllData();
        public Task<UserGetAllDto> GetAllWithDataById(int id);
    }
}
