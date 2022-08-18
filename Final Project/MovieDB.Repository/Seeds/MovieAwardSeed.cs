using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Seeds
{
    internal class MovieAwardSeed : IEntityTypeConfiguration<MovieAward>
    {
        public void Configure(EntityTypeBuilder<MovieAward> builder)
        {
            builder.HasData(
                new MovieAward
                {
                    MovieId = 1,
                    AwardId = 1,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 1,
                    AwardId = 2,
                    Date = DateTime.UtcNow,
                    DirectorId = 2
                },
                new MovieAward
                {
                    MovieId = 1,
                    AwardId = 7,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 1,
                    AwardId = 13,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 1,
                    AwardId = 16,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 1,
                    AwardId = 22,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 2,
                    AwardId = 1,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 2,
                    AwardId = 17,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 3,
                    AwardId = 1,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 3,
                    AwardId = 16,
                    Date = DateTime.UtcNow
                },
                new MovieAward
                {
                    MovieId = 3,
                    AwardId = 3,
                    PerformerId = 1,
                    Date = DateTime.UtcNow
                }
            );
        }
    }
}
