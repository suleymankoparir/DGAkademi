using W_02.Core.Models;

namespace W_02.Core.Repositories
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        public Task<List<Person>> GetPeopleWithDepartmentAndRole();
        public Task<Person> GetPersonWithDepartmentAndRole(int id);
    }
}
