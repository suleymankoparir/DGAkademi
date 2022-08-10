using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.DTOs;
using W_02.Core.Models;
using W_02.Core.Repositories;
using W_02.Core.Services;
using W_02.Core.UnitOfWorks;

namespace W_02.Service.Services
{
    public class PersonService : Service<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PersonService(IGenericRepository<Person> repository, IUnitOfWork unitOfWork, IPersonRepository personRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PersonWithDepartmentAndRoleDto>> GetPeopleWithDepartmentAndRole()
        {
            var people= await _personRepository.GetPeopleWithDepartmentAndRole();
            var peopleDto=_mapper.Map<List<PersonWithDepartmentAndRoleDto>>(people);
            for(int i = 0; i < peopleDto.Count; i++)
            {
                peopleDto[i].DepartmentName = people[i].Department.Name;
                peopleDto[i].RoleName=people[i].Role.Name;
            }
            return peopleDto;
        }

        public async Task<PersonWithDepartmentAndRoleDto> GetPersonWithDepartmentAndRole(int id)
        {
            var person=await _personRepository.GetPersonWithDepartmentAndRole(id);
            if(person==null)
                return null;
            var personDto = _mapper.Map<PersonWithDepartmentAndRoleDto>(person);
            personDto.DepartmentName = person.Department.Name;
            personDto.RoleName=person.Role.Name;
            return personDto;
        }
    }
}
