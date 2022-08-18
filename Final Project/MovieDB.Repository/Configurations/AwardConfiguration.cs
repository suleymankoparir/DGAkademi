using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Configurations
{
    internal class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.HasOne(x=>x.AwardType).WithMany(x=>x.Awards).HasForeignKey(x=>x.AwardTypeId);
            builder.HasMany(x => x.MovieAward).WithOne(x => x.Award).HasForeignKey(x => x.AwardId);
        }
    }
}
