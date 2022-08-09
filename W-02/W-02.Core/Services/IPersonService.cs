using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.DTOs;
using W_02.Core.Models;

namespace W_02.Core.Services
{
    public interface IPersonService: IService<Person>
    {
        public Task<List<PersonWithDepartmentAndRoleDto>> GetPeopleWithDepartmentAndRole();
        public Task<PersonWithDepartmentAndRoleDto> GetPersonWithDepartmentAndRole(int id);
    }
}
