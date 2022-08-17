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
    internal class AwardSeed : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.HasData(
                new Award
                {
                    Id = 1,
                    Name = "Oscar Best Picture",
                    Type ="Movie"
                },
                new Award
                {
                    Id = 2,
                    Name = "Oscar Best Director",
                    Type="Director"
                },
                new Award
                {
                    Id = 3,
                    Name = "Oscar Best Actor",
                    Type="Male"
                },
                new Award
                {
                    Id = 4,
                    Name = "Oscar Best Actress",
                    Type="Female"
                },
                new Award
                {
                    Id=5,
                    Name ="Oscar Best Cinematography",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 6,
                    Name = "Oscar Best Production Desgin",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 7,
                    Name = "Oscar Best Adapted Screenplay",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 8,
                    Name = "Oscar Best Sound",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 9,
                    Name = "Oscar Best Animated Short Film",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 10,
                    Name = "Oscar Best Live Action Short Film",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 11,
                    Name = "Oscar Best Film Editing",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 12,
                    Name = "Oscar Best Original Score",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 13,
                    Name = "Oscar Best Original Song",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 14,
                    Name = "Oscar Best Supporting Actor",
                    Type = "Male"
                },
                new Award
                {
                    Id = 15,
                    Name = "Oscar Best Supporting Actress",
                    Type = "Female"
                },
                new Award
                {
                    Id = 16,
                    Name = "Oscar Best Visual Effects",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 17,
                    Name = "Oscar Best Original Screenplay",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 18,
                    Name = "Oscar Best Documentary Short Film",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 19,
                    Name = "Oscar Best Documentary Feature Film",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 20,
                    Name = "Oscar Best International Feature Film",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 21,
                    Name = "Oscar Best Custome Design",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 22,
                    Name = "Oscar Best Makeup and Hairstyling",
                    Type = "Movie"
                },
                new Award
                {
                    Id = 23,
                    Name = "Oscar Best Animated Feature Film",
                    Type = "Movie"
                }
            );
        }
    }
}
