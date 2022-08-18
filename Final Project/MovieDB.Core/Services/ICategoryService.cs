using MovieDB.Core.DTOs;
using MovieDB.Core.Models;

namespace MovieDB.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<List<CategoryGetAllDto>> getAllData();
        public Task<CategoryGetAllDto> GetAllWithDataById(int id);
    }
}
