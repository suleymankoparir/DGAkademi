using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Seeds
{
    internal class PopulatirySeed : IEntityTypeConfiguration<Popularity>
    {
        public void Configure(EntityTypeBuilder<Popularity> builder)
        {
            builder.HasData(
                new Popularity
                {
                    Id = 1,
                    MovieId = 3,
                    Since = DateTime.UtcNow
                }
            );
        }
    }
}
