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
    internal class MovieAwardConfiguration : IEntityTypeConfiguration<MovieAward>
    {
        public void Configure(EntityTypeBuilder<MovieAward> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Date).IsRequired();

            builder.HasOne(x=>x.Award).WithMany(x=>x.MovieAward).HasForeignKey(x=>x.AwardId);
            builder.HasOne(x => x.Director).WithMany(x => x.MovieAward).HasForeignKey(x => x.DirectorId);
            builder.HasOne(x => x.Performer).WithMany(x => x.MovieAward).HasForeignKey(x => x.PerformerId);
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieAward).HasForeignKey(x => x.MovieId);
        }
    }
}
