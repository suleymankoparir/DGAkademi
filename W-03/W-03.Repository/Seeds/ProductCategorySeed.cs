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
    internal class ProductCategorySeed : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(
                new ProductCategory
                {
                    Id=1,
                    Name="Electronic",
                    CreatedAt=DateTime.Now,
                },
                new ProductCategory
                {
                    Id = 2,
                    Name = "Furniture",
                    CreatedAt = DateTime.Now
                }
                );
        }
    }
}
