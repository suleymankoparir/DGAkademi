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
    internal class AwardTypeConfiguration : IEntityTypeConfiguration<AwardType>
    {
        public void Configure(EntityTypeBuilder<AwardType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.HasMany(x => x.Awards).WithOne(x => x.AwardType).HasForeignKey(x => x.AwardTypeId);
        }
    }
}
