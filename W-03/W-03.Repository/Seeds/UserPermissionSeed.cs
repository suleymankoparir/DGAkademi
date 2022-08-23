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
    internal class UserPermissionSeed : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasData(
                new UserPermission
                {
                    Id=1,
                    Name="Gold",
                    CreatedAt = DateTime.Now
                },
                new UserPermission
                {
                    Id = 2,
                    Name = "Platin",
                    CreatedAt = DateTime.Now
                },
                new UserPermission
                {
                    Id = 3,
                    Name = "Chromium",
                    CreatedAt = DateTime.Now
                }
                );
        }
    }
}
