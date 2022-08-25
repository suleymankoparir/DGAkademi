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
    internal class MovieTypeConfiguration : IEntityTypeConfiguration<MovieType>
    {
        public void Configure(EntityTypeBuilder<MovieType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x=>x.Movies).WithOne(x=>x.MovieType).HasForeignKey(x=>x.MovieTypeId);
            builder.HasMany(x => x.AwardTypes).WithOne(x => x.MovieType).HasForeignKey(x => x.MovieTypeId);
        }
    }
}
