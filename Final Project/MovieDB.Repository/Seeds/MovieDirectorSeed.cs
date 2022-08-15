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
    internal class MovieDirectorSeed : IEntityTypeConfiguration<MovieDirector>
    {
        public void Configure(EntityTypeBuilder<MovieDirector> builder)
        {
            builder.HasData(
                new MovieDirector
                {
                    DirectorId=1,
                    MovieId=2
                },
                new MovieDirector
                {
                    DirectorId = 2,
                    MovieId = 1
                },
                new MovieDirector
                {
                    DirectorId = 3,
                    MovieId = 3
                }
            );
        }
    }
}
