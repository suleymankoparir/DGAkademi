using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.Models;

namespace W_02.Repository.Seeds
{
    internal class PersonSeed : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person
                {
                    Id = 1,
                    FullName = "Süleyman Koparır",
                    UserName = "suleymankoparir",
                    Password = "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a",//password
                    DepartmantId=1,
                    RoleId=1
                },
                new Person
                {
                    Id = 2,
                    FullName = "John Doe",
                    UserName = "johndoe",
                    Password = "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a",//password
                    DepartmantId = 2,
                    RoleId = 2
                },
                new Person
                {
                    Id = 3,
                    FullName = "Mark Doe",
                    UserName = "markdoe",
                    Password = "d7d378fbcffdcfa759ba2681d51e5e695f0078e56d4a2e2c0e539dc61e1a67e7",//şifre
                    DepartmantId = 3,
                    RoleId=2
                },
                new Person
                {
                    Id = 4,
                    FullName = "Ron Doe",
                    UserName = "rondoe",
                    Password = "d7d378fbcffdcfa759ba2681d51e5e695f0078e56d4a2e2c0e539dc61e1a67e7",//şifre
                    DepartmantId = 4,
                    RoleId = 2
                }
            );
        }
    }
}
