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
                    Name = "Oscar Best Picture"
                },
                new Award
                {
                    Id = 2,
                    Name = "Oscar Best Director"
                },
                new Award
                {
                    Id = 3,
                    Name = "Oscar Best Actor"
                },
                new Award
                {
                    Id = 4,
                    Name = "Oscar Best Actress"
                },
                new Award
                {
                    Id=5,
                    Name ="Oscar Best Cinematography"
                },
                new Award
                {
                    Id = 6,
                    Name = "Oscar Best Production Desgin"
                },
                new Award
                {
                    Id = 7,
                    Name = "Oscar Best Adapted Screenplay"
                },
                new Award
                {
                    Id = 8,
                    Name = "Oscar Best Sound"
                },
                new Award
                {
                    Id = 9,
                    Name = "Oscar Best Animated Short Film"
                },
                new Award
                {
                    Id = 10,
                    Name = "Oscar Best Live Action Short Film"
                },
                new Award
                {
                    Id = 11,
                    Name = "Oscar Best Film Editing"
                },
                new Award
                {
                    Id = 12,
                    Name = "Oscar Best Original Score"
                },
                new Award
                {
                    Id = 13,
                    Name = "Oscar Best Original Song"
                },
                new Award
                {
                    Id = 14,
                    Name = "Oscar Best Supporting Actor"
                },
                new Award
                {
                    Id = 15,
                    Name = "Oscar Best Supporting Actress"
                },
                new Award
                {
                    Id = 16,
                    Name = "Oscar Best Visual Effects"
                },
                new Award
                {
                    Id = 17,
                    Name = "Oscar Best Original Screenplay"
                },
                new Award
                {
                    Id = 18,
                    Name = "Oscar Best Documentary Short Film"
                },
                new Award
                {
                    Id = 19,
                    Name = "Oscar Best Documentary Feature Film"
                },
                new Award
                {
                    Id = 20,
                    Name = "Oscar Best International Feature Film"
                },
                new Award
                {
                    Id = 21,
                    Name = "Oscar Best Custome Design"
                },
                new Award
                {
                    Id = 22,
                    Name = "Oscar Best Makeup and Hairstyling"
                },
                new Award
                {
                    Id = 23,
                    Name = "Oscar Best Animated Feature Film"
                }
            );
        }
    }
}
