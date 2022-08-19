using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.Entities;

namespace W_03.Repository.Configurations
{
    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x=>x.User).WithMany(x=>x.Sales).HasForeignKey(x=>x.UserId);
            builder.HasOne(x => x.Product).WithMany(x => x.Sales).HasForeignKey(x => x.ProductId);
        }
    }
}
