using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Repository.Seeds
{
    internal class MoviePerformerSeed : IEntityTypeConfiguration<MoviePerformer>
    {
        public void Configure(EntityTypeBuilder<MoviePerformer> builder)
        {
            builder.HasData(
                new MoviePerformer
                {
                    MovieId = 1,
                    PerformerId = 2
                },
                new MoviePerformer
                {
                    MovieId = 1,
                    PerformerId = 3
                },
                new MoviePerformer
                {
                    MovieId = 2,
                    PerformerId = 4
                },
                new MoviePerformer
                {
                    MovieId = 2,
                    PerformerId = 5
                },
                new MoviePerformer
                {
                    MovieId = 3,
                    PerformerId = 1
                }
            );
        }
    }
}
