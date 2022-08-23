using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.Entities;

namespace W_03.Repository.Seeds
{
    internal class ProductUserPermissionSeed : IEntityTypeConfiguration<ProductUserPermission>
    {
        public void Configure(EntityTypeBuilder<ProductUserPermission> builder)
        {
            builder.HasData(
                new ProductUserPermission
                {
                    Id=1,
                    UserPermissionId=2,
                    ProductId=1,
                    CreatedAt = DateTime.Now
                },
                new ProductUserPermission
                {
                    Id=2,
                    UserPermissionId = 3,
                    ProductId = 1,
                    CreatedAt = DateTime.Now
                },
                new ProductUserPermission
                {
                    Id=3,
                    UserPermissionId = 1,
                    ProductId = 2,
                    CreatedAt = DateTime.Now
                },
                new ProductUserPermission
                {
                    Id=4,
                    UserPermissionId = 2,
                    ProductId = 2,
                    CreatedAt = DateTime.Now
                },
                new ProductUserPermission
                {
                    Id=5,
                    UserPermissionId = 3,
                    ProductId = 2,
                    CreatedAt = DateTime.Now
                }
                );
        }
    }
}
