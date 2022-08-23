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
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id=1,
                    Email="suleymankoparir@gmail.com",
                    Password= "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a",
                    UserPermissionId=1,
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    Email = "johndoe@gmail.com",
                    Password = "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a",
                    UserPermissionId = 2,
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = 3,
                    Email = "rondoe@gmail.com",
                    Password = "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a",
                    UserPermissionId = 3,
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}
