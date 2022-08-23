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
    internal class UserInformationSeed : IEntityTypeConfiguration<UserInformation>
    {
        public void Configure(EntityTypeBuilder<UserInformation> builder)
        {
            builder.HasData(
                new UserInformation
                {
                    Id=1,
                    UserId=1,
                    Name="Süleyman",
                    Surname="Koparır",
                    FullAddress="İstanbul Bahçelievler",
                    City="İstanbul",
                    Country="Türkiye",
                    CreatedAt = DateTime.Now
                },
                new UserInformation
                {
                    Id = 2,
                    UserId = 2,
                    Name = "John",
                    Surname = "Doe",
                    FullAddress = "İstanbul Bahçelievler",
                    City = "İstanbul",
                    Country = "Türkiye",
                    CreatedAt = DateTime.Now
                },
                new UserInformation
                {
                    Id = 3,
                    UserId = 3,
                    Name = "Ron",
                    Surname = "Doe",
                    FullAddress = "İstanbul Bahçelievler",
                    City = "İstanbul",
                    Country = "Türkiye",
                    CreatedAt = DateTime.Now
                }
                );
        }
    }
}
