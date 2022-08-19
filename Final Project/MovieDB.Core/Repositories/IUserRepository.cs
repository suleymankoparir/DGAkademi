using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<List<User>> GetAllWithData();
        public Task<User> GetAllWithDataById(int id);
    }
}