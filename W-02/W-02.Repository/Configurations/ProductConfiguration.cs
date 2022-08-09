using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.Models;

namespace W_02.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(X => X.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(x => x.createdTime).IsRequired();
        }
    }
}
