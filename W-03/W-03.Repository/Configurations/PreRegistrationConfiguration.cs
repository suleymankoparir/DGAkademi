using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.Entities;

namespace W_03.Repository.Configurations
{
    public class PreRegistrationConfiguration : IEntityTypeConfiguration<PreRegistration>
    {
        public void Configure(EntityTypeBuilder<PreRegistration> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired();


            builder.Property(x=>x.Email).IsRequired();
            builder.HasIndex(x=>x.Email).IsUnique();
            builder.Property(x=>x.Ip).IsRequired();
            builder.Property(x => x.Hash).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
