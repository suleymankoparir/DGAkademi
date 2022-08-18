using MovieDB.Core.DTOs;
using MovieDB.Core.Models;

namespace MovieDB.Core.Services
{
    public interface IProducerService : IService<Producer>
    {
        public Task<List<ProducerGetAllDto>> getAllData();
        public Task<ProducerGetAllDto> GetAllWithDataById(int id);
    }
}
