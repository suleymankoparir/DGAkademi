﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Seeds
{
    internal class MovieSeed : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Lord of the Rings: Return of the King",
                    ReleaseDate = DateTime.Parse("19.12.2003"),
                    Budget = 94000000,
                    Gross = 1100000000,
                    MovieTypeId =1
                },
                new Movie
                {
                    Id = 2,
                    Name = "Django Unchained",
                    ReleaseDate = DateTime.Parse("18.01.2013"),
                    Budget = 100000000,
                    Gross = 425000000,
                    MovieTypeId = 1
                },
                new Movie
                {
                    Id = 3,
                    Name = "The Revenant",
                    ReleaseDate = DateTime.Parse("22.01.2016"),
                    Budget = 135000000,
                    Gross = 533000000,
                    MovieTypeId = 1
                },
                new Movie { 
                    Id = 4, 
                    Name ="Breaking Bad",
                    ReleaseDate= DateTime.Parse("20.01.2008"),
                    Budget=3000000,
                    Gross=10000000,
                    MovieTypeId=2
                }
            );
        }
    }
}
