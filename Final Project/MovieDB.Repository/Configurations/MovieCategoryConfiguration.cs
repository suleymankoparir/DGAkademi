using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Configurations
{
    internal class MovieCategoryConfiguration : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.CategoryId });
            builder.HasOne(x => x.Category).WithMany(x => x.MovieCategory).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieCategory).HasForeignKey(x => x.MovieId);
        }
    }
}
