using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Repositories
{
    public interface IPerformerRepository : IGenericRepository<Performer>
    {
        public Task<List<Performer>> GetAllWithData();
        public Task<Performer> GetAllWithDataById(int id);
    }
}
