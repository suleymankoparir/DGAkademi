using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                    Id = 1,
                    UserName = "suleymankoparir",
                    Password = "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a"//password
                },
                new User
                {
                    Id = 2,
                    UserName = "user2",
                    Password = "d7d378fbcffdcfa759ba2681d51e5e695f0078e56d4a2e2c0e539dc61e1a67e7"//şifre
                }
                );
        }
    }
}
