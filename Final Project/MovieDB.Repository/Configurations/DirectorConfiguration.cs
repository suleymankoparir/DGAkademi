using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Configurations
{
    internal class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Birthday).IsRequired();
            builder.HasMany(x => x.MovieDirector).WithOne(x => x.Director).HasForeignKey(x => x.DirectorId);
            builder.HasMany(x => x.MovieAward).WithOne(x => x.Director).HasForeignKey(x => x.DirectorId);
        }
    }
}
