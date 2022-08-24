using Microsoft.EntityFrameworkCore;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllWithData()
        {
            return await _context.Users.Include(x => x.Reviews).Include(x => x.Role).ToListAsync();
        }

        public async  Task<User> GetAllWithDataById(int id)
        {
            return await _context.Users.Include(x => x.Reviews).Include(x=>x.Role).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
