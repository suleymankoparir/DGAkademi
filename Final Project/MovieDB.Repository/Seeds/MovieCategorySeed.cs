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
    internal class MovieCategorySeed : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.HasData(
                new MovieCategory
                {
                    MovieId =1,
                    CategoryId =1,
                },
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 4,
                },
                new MovieCategory
                {
                    MovieId = 2,
                    CategoryId = 1,
                },
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 9,
                },
                new MovieCategory
                {
                    MovieId = 3,
                    CategoryId = 1,
                },
                new MovieCategory
                {
                    MovieId = 3,
                    CategoryId = 9,
                },
                new MovieCategory
                {
                    MovieId = 3,
                    CategoryId = 3,
                }
            );
        }
    }
}
