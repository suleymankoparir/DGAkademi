using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.Models;

namespace W_02.Repository.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(32).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.People).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
        }
    }
}
