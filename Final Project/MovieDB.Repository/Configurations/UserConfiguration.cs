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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(64);
            builder.HasMany(x => x.Reviews).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
