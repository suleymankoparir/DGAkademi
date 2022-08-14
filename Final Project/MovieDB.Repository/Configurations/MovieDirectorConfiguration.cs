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
    internal class MovieDirectorConfiguration : IEntityTypeConfiguration<MovieDirector>
    {
        public void Configure(EntityTypeBuilder<MovieDirector> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.DirectorId });
            builder.HasOne(x=>x.Director).WithMany(x=>x.MovieDirector).HasForeignKey(x=>x.DirectorId);
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieDirector).HasForeignKey(x => x.MovieId);
        }
    }
}
