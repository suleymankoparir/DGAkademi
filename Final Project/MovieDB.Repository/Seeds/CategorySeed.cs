using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action"
                },
                new Category
                {
                    Id = 2,
                    Name = "Comedy"
                },
                new Category
                {
                    Id = 3,
                    Name = "Drama"
                },
                new Category
                {
                    Id = 4,
                    Name = "Fantasy"
                },
                new Category
                {
                    Id = 5,
                    Name = "Horror"
                },
                new Category
                {
                    Id = 6,
                    Name = "Mistery"
                },
                new Category
                {
                    Id = 7,
                    Name = "Romance"
                },
                new Category
                {
                    Id = 8,
                    Name = "Thriller"
                },
                new Category
                {
                    Id = 9,
                    Name = "Western"
                }
           );
        }
    }
}
