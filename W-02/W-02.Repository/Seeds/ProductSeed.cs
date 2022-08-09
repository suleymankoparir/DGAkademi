using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.Models;

namespace W_02.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id= 1,
                    Name="Computer",
                    Stock=30,
                    Price=3000,
                    createdTime=DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    Name = "Mouse",
                    Stock = 300,
                    Price = 150,
                    createdTime = DateTime.UtcNow
                },
                new Product
                {
                    Id = 3,
                    Name = "HDD",
                    Stock = 100,
                    Price = 300,
                    createdTime = DateTime.UtcNow
                }
            );
        }
    }
}
