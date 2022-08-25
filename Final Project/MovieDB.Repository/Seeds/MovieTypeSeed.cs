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
    internal class MovieTypeSeed : IEntityTypeConfiguration<MovieType>
    {
        public void Configure(EntityTypeBuilder<MovieType> builder)
        {
            builder.HasData(
                new MovieType
                {
                    Id = 1,
                    Name = "Movie"
                },
                new MovieType
                {
                    Id = 2,
                    Name = "Tv Series"
                }
            );
        }
    }
}
