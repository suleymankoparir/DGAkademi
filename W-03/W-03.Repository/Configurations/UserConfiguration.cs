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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.UserPermissionId).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(x=>x.Sales).WithOne(x=>x.User).HasForeignKey(x=>x.UserId);
            builder.HasOne(x=>x.UserPermission).WithMany(x=>x.Users).HasForeignKey(x=>x.UserPermissionId);
            builder.HasOne(x=>x.UserInformation).WithOne(x=>x.User).HasForeignKey<UserInformation>(x=>x.UserId);
        }
    }
}
