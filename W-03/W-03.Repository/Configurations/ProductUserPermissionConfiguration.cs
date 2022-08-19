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
    public class ProductUserPermissionConfiguration : IEntityTypeConfiguration<ProductUserPermission>
    {
        public void Configure(EntityTypeBuilder<ProductUserPermission> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.UserPermissionId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            
            builder.HasOne(x=>x.UserPermission).WithMany(x=>x.ProductUserPermissions).HasForeignKey(x=>x.UserPermissionId);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductUserPermissions).HasForeignKey(x => x.ProductId);
        }
    }
}
