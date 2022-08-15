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
    internal class MovieAwardSeed : IEntityTypeConfiguration<MovieAward>
    {
        public void Configure(EntityTypeBuilder<MovieAward> builder)
        {
            builder.HasData(
                new MovieAward
                {
                    Id=1,
                    MovieId = 1,
                    AwardId = 1,
                },
                new MovieAward
                {
                    Id=2,
                    MovieId = 1,
                    AwardId = 7,
                },
                new MovieAward
                {
                    Id = 3,
                    MovieId = 1,
                    AwardId = 13,
                },
                new MovieAward
                {
                    Id = 4,
                    MovieId = 1,
                    AwardId = 16,
                },
                new MovieAward
                {
                    Id = 5,
                    MovieId = 1,
                    AwardId = 22,
                },
                new MovieAward
                {
                    Id = 6,
                    MovieId = 2,
                    AwardId = 1,
                },
                new MovieAward
                {
                    Id = 7,
                    MovieId = 2,
                    AwardId = 17,
                },
                new MovieAward
                {
                    Id = 8,
                    MovieId = 2,
                    AwardId = 17,
                },
                new MovieAward
                {
                    Id = 9,
                    MovieId = 3,
                    AwardId = 1,
                },
                new MovieAward
                {
                    Id = 10,
                    MovieId = 3,
                    AwardId = 16,
                }
            );
        }
    }
}
