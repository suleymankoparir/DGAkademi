﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Repository.Configurations
{
    internal class PopularityConfiguration : IEntityTypeConfiguration<Popularity>
    {
        public void Configure(EntityTypeBuilder<Popularity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Since).IsRequired();
            builder.HasOne(x => x.Movie).WithOne(x => x.Populatiry).HasForeignKey<Popularity>(x => x.MovieId);
        }
    }
}
