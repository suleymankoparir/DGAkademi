﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.Entities;

namespace W_03.Repository.Configurations
{
    public class PtoductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasOne(x=>x.Product).WithOne(x=>x.ProductDetail).HasForeignKey<ProductDetail>(x=>x.Id);
        }
    }
}
