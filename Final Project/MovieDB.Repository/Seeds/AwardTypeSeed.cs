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
                    Name ="Movie"
                },
                new AwardType
                {
                    Id = 2,
                    Name = "Male"
                },
                new AwardType
                {
                    Id = 3,
                    Name = "Female"
                },
                new AwardType
                {
                    Id = 4,
                    Name = "Director"
                }
            );
        }
    }
}
