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
    internal class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x=>x.Users).WithOne(x=>x.UserPermission).HasForeignKey(x=>x.UserPermissionId);
            builder.HasMany(x => x.ProductUserPermissions).WithOne(x => x.UserPermission).HasForeignKey(x => x.UserPermissionId);
        }
    }
}
