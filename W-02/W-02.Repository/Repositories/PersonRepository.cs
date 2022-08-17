using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.Models;
using W_02.Core.Repositories;

namespace W_02.Repository.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Person>> GetPeopleWithDepartmentAndRole()
        {
            return await _context.People.Include(x => x.Department).Include(x=>x.Role).AsNoTracking().ToListAsync();
        }

        public async Task<Person> GetPersonWithDepartmentAndRole(int id)
        {
            return await _context.People.Include(x => x.Department).Include(x => x.Role).Where(x=>x.Id==id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
