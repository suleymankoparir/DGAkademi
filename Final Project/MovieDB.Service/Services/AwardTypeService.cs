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
    public class AwardTypeService : Service<AwardType>, IAwardTypeService
    {
        private readonly IAwardTypeRepository _awardTypeRepository;
        private readonly IService<Award> _awardService;
        private readonly IMapper _mapper;
        public AwardTypeService(IGenericRepository<AwardType> repository, IUnitOfWork unitOfWork, IAwardTypeRepository awardTypeRepository, IService<Award> awardService, IMapper mapper) : base(repository, unitOfWork)
        {
            _awardTypeRepository = awardTypeRepository;
            _awardService = awardService;
            _mapper = mapper;
        }

        public async Task<List<AwardTypeGetAllDto>> getAllData()
        {
            var awardTypes = await _awardTypeRepository.GetAllWithData();
            var mapped = _mapper.Map<List<AwardTypeGetAllDto>>(awardTypes);
            for (int i = 0; i < awardTypes.Count; i++)
            {
                mapped[i].Awards = new List<AwardGetDto>();
                foreach (Award award in awardTypes[i].Awards)
                {
                    var map = _mapper.Map<AwardGetDto>(award);
                    mapped[i].Awards.Add(map);
                }
            }
            return mapped;
        }

        public async Task<AwardTypeGetAllDto> GetAllWithDataById(int id)
        {
            var awardType = await _awardTypeRepository.GetAllWithDataById(id);
            var mapped = _mapper.Map<AwardTypeGetAllDto>(awardType);
            mapped.Awards = new List<AwardGetDto>();
            foreach (Award award in awardType.Awards)
            {
                var map = _mapper.Map<AwardGetDto>(award);
                mapped.Awards.Add(map);
            }
            return mapped;
        }
    }
}
