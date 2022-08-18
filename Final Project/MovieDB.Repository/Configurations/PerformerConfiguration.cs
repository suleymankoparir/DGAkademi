using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Configurations
{
    internal class PerformerConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Birthday).IsRequired();
            builder.HasMany(x => x.MovieAward).WithOne(x => x.Performer).HasForeignKey(x => x.PerformerId);
            builder.HasMany(x => x.MoviePerformer).WithOne(x => x.Performer).HasForeignKey(x => x.PerformerId);
        }
    }
}
