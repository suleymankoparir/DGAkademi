using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Repositories
{
    public interface IDirectorRepository : IGenericRepository<Director>
    {
        public Task<List<Director>> GetAllWithData();
        public Task<Director> GetAllWithDataById(int id);
    }
}
