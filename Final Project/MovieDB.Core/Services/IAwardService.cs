using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Services
{
    public interface IAwardService:IService<Award>
    {
        public Task<List<AwardGetAllDto>> getAllData();
        public Task<AwardGetAllDto> GetAllWithDataById(int id);
    }
}
