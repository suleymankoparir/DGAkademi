using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Repository.Seeds
{
    internal class AwardTypeSeed : IEntityTypeConfiguration<AwardType>
    {
        public void Configure(EntityTypeBuilder<AwardType> builder)
        {
            builder.HasData(
                new AwardType
                {
                    Id=1,
                    Name ="Movie",
                    MovieTypeId = 1,
                },
                new AwardType
                {
                    Id=2,
                    Name ="Tv Series",
                    MovieTypeId=2,
                },
                new AwardType
                {
                    Id = 3,
                    Name = "Male",
                    MovieTypeId = 1
                },
                new AwardType
                {
                    Id = 4,
                    Name = "Female",
                    MovieTypeId = 1
                },
                new AwardType
                {
                    Id = 5,
                    Name = "Director",
                    MovieTypeId = 1
                }
            );
        }
    }
}
