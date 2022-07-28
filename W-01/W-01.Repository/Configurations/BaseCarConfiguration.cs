using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_01.Core.Models;

namespace W_01.Repository.Configurations
{
    internal class BaseCarConfiguration : IEntityTypeConfiguration<BaseCar>
    {
        public void Configure(EntityTypeBuilder<BaseCar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
