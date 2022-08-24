using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Seeds
{
    internal class ReviewSeed : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review
                {
                    Id = 1,
                    UserId = 1,
                    MovieId = 1,
                    Score = 90,
                    Comment = "Best movie ever",
                    Date = DateTime.UtcNow
                },
                new Review
                {
                    Id = 2,
                    UserId = 2,
                    MovieId = 1,
                    Score = 100,
                    Comment = "Fantastic movie",
                    Date = DateTime.UtcNow
                },
                new Review
                {
                    Id = 3,
                    UserId = 1,
                    MovieId = 2,
                    Score = 70,
                    Comment = "Good movie",
                    Date = DateTime.UtcNow
                },
                new Review
                {
                    Id = 4,
                    UserId = 2,
                    MovieId = 3,
                    Score = 40,
                    Comment = "Bad movie",
                    Date = DateTime.UtcNow
                }
            );
        }
    }
}
