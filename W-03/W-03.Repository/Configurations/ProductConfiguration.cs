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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.DetailId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.PaidPrice).IsRequired();
            builder.Property(x => x.Tax).IsRequired();

            builder.Property(X => X.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(X => X.PaidPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(X => X.Tax).IsRequired().HasColumnType("decimal(18,2)");


            builder.HasOne(x => x.ProductDetail).WithOne(x => x.Product).HasForeignKey<Product>(x => x.DetailId);
            builder.HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasMany(x=>x.Sales).WithOne(x=>x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany(x=>x.ProductUserPermissions).WithOne(x=>x.Product).HasForeignKey(x=>x.UserPermissionId);
        }
    }
}
