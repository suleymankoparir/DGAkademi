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
    internal class MoviePerformerConfiguration : IEntityTypeConfiguration<MoviePerformer>
    {
        public void Configure(EntityTypeBuilder<MoviePerformer> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.PerformerId });
            builder.HasOne(x => x.Performer).WithMany(x => x.MoviePerformer).HasForeignKey(x => x.PerformerId);
            builder.HasOne(x => x.Movie).WithMany(x => x.MoviePerformer).HasForeignKey(x => x.MovieId);
        }
    }
}
