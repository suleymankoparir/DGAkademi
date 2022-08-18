using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Repositories
{
    public interface IAwardRepository : IGenericRepository<Award>
    {
        public Task<List<Award>> GetAllWithData();
        public Task<Award> GetAllWithDataById(int id);
    }
}
