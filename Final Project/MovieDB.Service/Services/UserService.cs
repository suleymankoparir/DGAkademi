using AutoMapper;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;
using MovieDB.Core.Services;
using MovieDB.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IService<Award> _awardService;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository, IService<Award> awardService, IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _awardService = awardService;
            _mapper = mapper;
        }

        public async Task<List<UserGetAllDto>> getAllData()
        {
            var users = await _userRepository.GetAllWithData();
            var mapped = _mapper.Map<List<UserGetAllDto>>(users);
            for (int i = 0; i < users.Count; i++)
            {
                mapped[i].Reviews = new List<ReviewGetDto>();
                foreach (Review item in users[i].Reviews)
                {
                    mapped[i].Reviews.Add(_mapper.Map<ReviewGetDto>(item));
                }
            }
            return mapped;
        }

        public async Task<UserGetAllDto> GetAllWithDataById(int id)
        {
            var user = await _userRepository.GetAllWithDataById(id);
            var mapped = _mapper.Map<UserGetAllDto>(user);
            mapped.Reviews = new List<ReviewGetDto>();
            foreach (Review item in user.Reviews)
            {
                mapped.Reviews.Add(_mapper.Map<ReviewGetDto>(item));
            }
            return mapped;
        }
    }
}
