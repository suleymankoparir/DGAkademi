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
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id=1,
                    DetailId=1,
                    Price=500,
                    PaidPrice=200,
                    Tax=50,
                    CategoryId=1,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    DetailId = 2,
                    Price = 600,
                    PaidPrice = 100,
                    Tax = 150,
                    CategoryId=2,
                    CreatedAt = DateTime.Now

                }
                );
        }
    }
}
