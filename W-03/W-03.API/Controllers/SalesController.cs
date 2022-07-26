﻿using Microsoft.AspNetCore.Http;
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
    public class SalesController : ControllerBase
    {
        private readonly IService<Sale> _service;
        private readonly IService<User> _serviceUser;
        private readonly IService<Product> _serviceProduct;
        private readonly IService<ProductUserPermission> _serviceProductPermission;

        public SalesController(IService<Sale> service, IService<User> serviceUser, IService<Product> serviceProduct, IService<ProductUserPermission> serviceProductPermission)
        {
            _service = service;
            _serviceUser = serviceUser;
            _serviceProduct = serviceProduct;
            _serviceProductPermission = serviceProductPermission;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaleAddView view)
        {
            var currentId = GetCurrentUserId();
            if (currentId == null) return BadRequest("Error in auth");
            if (currentId != view.UserId) return BadRequest("Forbidden access, user can only operate with her own id");
            var user = await _serviceUser.Where(x => x.Id == currentId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (user == null) return NotFound("User not found");

            var product=await _serviceProduct.Where(x => x.Id == view.ProductId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (product == null) return NotFound("Product not found");

            var productPermission=await _serviceProductPermission.Where(x => x.ProductId==product.Id&&x.UserPermissionId==user.UserPermissionId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if(productPermission == null) return BadRequest("This user does not have permission for this product");

            await _service.AddAsync(new Sale {ProductId=product.Id,UserId=user.Id,CreatedAt=DateTime.UtcNow });
            return Ok();
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
