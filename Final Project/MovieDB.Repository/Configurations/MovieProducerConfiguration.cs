using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Configurations
{
    internal class MovieProducerConfiguration : IEntityTypeConfiguration<MovieProducer>
    {
        public void Configure(EntityTypeBuilder<MovieProducer> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.ProducerId });
            builder.HasOne(x => x.Producer).WithMany(x => x.MovieProducer).HasForeignKey(x => x.ProducerId);
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieProducer).HasForeignKey(x => x.MovieId);
        }
    }
}
