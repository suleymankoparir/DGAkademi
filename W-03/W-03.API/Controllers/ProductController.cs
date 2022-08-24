using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using W_03.Core.Entities;
using W_03.Core.Services;
using W_03.Core.Views;

namespace W_03.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product> _service;
        private readonly IService<User> _serviceUser;
        private readonly IService<ProductCategory> _serviceProductCategory;
        private readonly IService<ProductDetail> _serviceProductDetail;
        private readonly IService<UserPermission> _serviceUserPermission;
        private readonly IService<ProductUserPermission> _serviceProductUserPermission;
        private readonly IMapper _mapper;

        public ProductController(IService<Product> service, IService<User> serviceUser, IService<ProductCategory> serviceProductCategory, IService<ProductDetail> serviceProductDetail, IMapper mapper, IService<UserPermission> serviceUserPermission, IService<ProductUserPermission> serviceProductUserPermission)
        {
            _service = service;
            _serviceUser = serviceUser;
            _serviceProductCategory = serviceProductCategory;
            _serviceProductDetail = serviceProductDetail;
            _mapper = mapper;
            _serviceUserPermission = serviceUserPermission;
            _serviceProductUserPermission = serviceProductUserPermission;
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddView view)
        {
            var categoryId = await _serviceProductCategory.Where(x => x.Id == view.CategoryId&&x.DeletedAt==DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (categoryId == null) return NotFound("Category not found");

            foreach (var item in view.Permissions)
            {
                var permission = await _serviceUserPermission.Where(x => x.Id == item.Id && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
                if (permission == null) return NotFound("Permission not found");
            }

            var mappedProduct = _mapper.Map<Product>(view);
            mappedProduct.CreatedAt = DateTime.UtcNow;

            var mappedDetail = _mapper.Map<ProductDetail>(view);
            mappedDetail.CreatedAt = DateTime.UtcNow;

            var productDetail = await _serviceProductDetail.AddAsync(mappedDetail);
            mappedProduct.DetailId = productDetail.Id;

            var product = await _service.AddAsync(mappedProduct);

            foreach (var item in view.Permissions)
            {
                await _serviceProductUserPermission.AddAsync(
                    new ProductUserPermission
                    {
                        UserPermissionId = item.Id,
                        ProductId = product.Id,
                        CreatedAt = DateTime.UtcNow
                    }
                    );
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _service.Include(x => x.ProductCategory).Include(x => x.ProductDetail).Include(x => x.ProductUserPermissions).Include(x => x.Sales).ToListAsync();
            products.ForEach(x => x.ProductCategory.Products = null);
            products.ForEach(x => x.ProductDetail.Product = null);
            products.ForEach(x => x.ProductUserPermissions.ForEach(x => x.Product = null));
            products.ForEach(x => x.Sales.ForEach(x => x.Product = null));
            return Ok(products);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var currentId = GetCurrentUserId();
            if (currentId == null) return BadRequest("Error in auth");
            if (currentId != userId) return BadRequest("Forbidden access, user can only operate with her own id");
            var user = await _serviceUser.Where(x => x.Id == currentId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (user == null) return NotFound("User not found");

            var productPermissionList=await _serviceProductUserPermission.Where(x=>x.UserPermissionId==user.UserPermissionId).AsNoTracking().ToListAsync();
            var products=new List<Product>();
            foreach (var item in productPermissionList)
            {
                var tempProduct = await _service.Where(x => x.Id == item.ProductId).Include(x => x.ProductCategory).Include(x => x.ProductDetail).Include(x => x.ProductUserPermissions).Include(x => x.Sales).AsNoTracking().FirstOrDefaultAsync();
                tempProduct.ProductCategory.Products = null;
                tempProduct.Sales.ForEach(x => x.Product = null);
                tempProduct.ProductDetail.Product = null;
                tempProduct.ProductUserPermissions.ForEach(x => x.Product = null);
                products.Add(tempProduct);
            }
            return Ok(products);
        }
        private int? GetCurrentUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                string? idStr = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.SerialNumber)?.Value;
                if (idStr == null) return null;
                return Convert.ToInt32(idStr);
            }
            return null;
        }
    }
}
