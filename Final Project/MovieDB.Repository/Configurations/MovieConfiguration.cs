using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Repository.Configurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.Budget).IsRequired().HasPrecision(18, 3);
            builder.Property(x => x.Gross).IsRequired().HasPrecision(18, 3);

            builder.HasMany(x => x.MovieCategory).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            builder.HasMany(x => x.MovieAward).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            builder.HasMany(x => x.MoviePerformer).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            builder.HasMany(x => x.MovieDirector).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            builder.HasMany(x => x.MovieProducer).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            builder.HasMany(x => x.Reviews).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.Populatiry).WithOne(x => x.Movie).HasForeignKey<Popularity>(x => x.MovieId);
        }
    }
}
