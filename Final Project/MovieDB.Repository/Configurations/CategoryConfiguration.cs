﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.HasMany(x => x.MovieCategory).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
