using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using W_02.Core.DTOs;
using W_02.Core.Models;
using W_02.Core.Services;

namespace W_02.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager,Purchasing")]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product> _service;
        private readonly IMapper _mapper;

        public ProductController(IService<Product> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetAll().ToListAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return Ok(productsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productDto)
        {
            var product=_mapper.Map<Product>(productDto);
            product.createdTime = DateTime.Now;
            await _service.AddAsync(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product=await _service.GetByIdAsync(id);
            if(product == null)
                return NotFound();
            await _service.RemoveAsync(product);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            var product = await _service.GetByIdAsync(productDto.Id);
            if (product == null)
                return NotFound();
            if(productDto.Name!=null)
                product.Name = productDto.Name;
            if (productDto.Stock != null)
                product.Stock = (int)productDto.Stock;
            if(productDto.Price != null)
                product.Price = (decimal)productDto.Price;
            product.updatedTime= DateTime.Now;
            await _service.UpdateAsync(product);
            return NoContent();

        }
    }
}
