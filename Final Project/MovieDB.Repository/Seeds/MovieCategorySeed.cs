using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Seeds
{
    internal class MovieCategorySeed : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.HasData(
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 1,
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
