using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Repositories
{
    public interface IAwardTypeRepository : IGenericRepository<AwardType>
    {
        public Task<List<AwardType>> GetAllWithData();
        public Task<AwardType> GetAllWithDataById(int id);
    }
}
