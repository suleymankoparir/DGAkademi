using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Services
{
    public interface IAwardTypeService : IService<AwardType>
    {
        public Task<List<AwardTypeGetAllDto>> getAllData();
        public Task<AwardTypeGetAllDto> GetAllWithDataById(int id);
    }
}