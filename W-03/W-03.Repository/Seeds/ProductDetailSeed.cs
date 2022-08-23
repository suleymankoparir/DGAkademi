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
    internal class ProductDetailSeed : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasData(
                new ProductDetail
                {
                    Id=1,
                    Name="Acer Laptop",
                    Description="Gaming laptop",
                    CreatedAt = DateTime.Now
                },
                new ProductDetail
                {
                    Id = 2,
                    Name = "Table",
                    Description = "150x80 table",
                    CreatedAt = DateTime.Now
                }
                );
        }
    }
}
