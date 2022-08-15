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
    internal class DirectorSeed : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasData(
                new Director
                {
                    Id = 1,
                    Name = "Quentin Tarantino",
                    Birthday=DateTime.Parse("27.03.1969")
                },
                new Director
                {
                    Id = 2,
                    Name = "Peter Jackson",
                    Birthday = DateTime.Parse("31.10.1961")
                },
                new Director
                {
                    Id = 3,
                    Name = "Alejandro González Iñárritu",
                    Birthday = DateTime.Parse("15.08.1963")
                }
            );
        }
    }
}
