using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Seeds
{
    internal class MovieProducerSeed : IEntityTypeConfiguration<MovieProducer>
    {
        public void Configure(EntityTypeBuilder<MovieProducer> builder)
        {
            builder.HasData(
                new MovieProducer
                {
                    MovieId = 1,
                    ProducerId = 5
                },
                new MovieProducer
                {
                    MovieId = 1,
                    ProducerId = 6
                },
                new MovieProducer
                {
                    MovieId = 2,
                    ProducerId = 3
                },
                new MovieProducer
                {
                    MovieId = 2,
                    ProducerId = 4
                },
                new MovieProducer
                {
                    MovieId = 3,
                    ProducerId = 1
                },
                new MovieProducer
                {
                    MovieId = 3,
                    ProducerId = 2
                }
            );
        }
    }
}
