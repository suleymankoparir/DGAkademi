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
    internal class SaleSeed : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasData(
                new Sale
                {
                    Id=1,
                    UserId=1,
                    ProductId=2,
                    CreatedAt = DateTime.Now
                },
                new Sale
                {
                    Id = 2,
                    UserId = 2,
                    ProductId = 1,
                    CreatedAt = DateTime.Now
                },
                new Sale
                {
                    Id = 3,
                    UserId = 3,
                    ProductId = 2,
                    CreatedAt = DateTime.Now
                }
                );
        }
    }
}
