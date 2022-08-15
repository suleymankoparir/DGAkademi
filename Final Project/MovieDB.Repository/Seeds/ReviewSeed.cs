﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Repository.Seeds
{
    internal class ReviewSeed : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review
                {
                    Id=1,
                    UserId=1,
                    MovieId=1,
                    Score=90,
                    Comment="Best movie ever"
                },
                new Review
                {
                    Id = 2,
                    UserId = 2,
                    MovieId = 1,
                    Score = 100,
                    Comment = "Fantastic movie"
                },
                new Review
                {
                    Id = 3,
                    UserId = 1,
                    MovieId = 2,
                    Score = 70,
                    Comment = "Good movie"
                },
                new Review
                {
                    Id = 4,
                    UserId = 2,
                    MovieId = 3,
                    Score = 40,
                    Comment = "Bad movie"
                }
            );
        }
    }
}