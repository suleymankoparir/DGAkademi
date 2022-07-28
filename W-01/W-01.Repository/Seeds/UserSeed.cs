using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_01.Core.Models;

namespace W_01.Repository.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id=1,
                    UserName = "suleymankoparir",
                    Password = "deneme"
                },
                new User
                {
                    Id=2,
                    UserName="user2",
                    Password="password"
                }
                );
        }
    }
}
