using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

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
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 2,
                    Name = "Oscar Best Director",
                    AwardTypeId = 4
                },
                new Award
                {
                    Id = 3,
                    Name = "Oscar Best Actor",
                    AwardTypeId = 2
                },
                new Award
                {
                    Id = 4,
                    Name = "Oscar Best Actress",
                    AwardTypeId = 3
                },
                new Award
                {
                    Id = 5,
                    Name = "Oscar Best Cinematography",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 6,
                    Name = "Oscar Best Production Desgin",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 7,
                    Name = "Oscar Best Adapted Screenplay",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 8,
                    Name = "Oscar Best Sound",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 9,
                    Name = "Oscar Best Animated Short Film",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 10,
                    Name = "Oscar Best Live Action Short Film",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 11,
                    Name = "Oscar Best Film Editing",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 12,
                    Name = "Oscar Best Original Score",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 13,
                    Name = "Oscar Best Original Song",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 14,
                    Name = "Oscar Best Supporting Actor",
                    AwardTypeId = 2
                },
                new Award
                {
                    Id = 15,
                    Name = "Oscar Best Supporting Actress",
                    AwardTypeId = 3
                },
                new Award
                {
                    Id = 16,
                    Name = "Oscar Best Visual Effects",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 17,
                    Name = "Oscar Best Original Screenplay",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 18,
                    Name = "Oscar Best Documentary Short Film",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 19,
                    Name = "Oscar Best Documentary Feature Film",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 20,
                    Name = "Oscar Best International Feature Film",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 21,
                    Name = "Oscar Best Custome Design",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 22,
                    Name = "Oscar Best Makeup and Hairstyling",
                    AwardTypeId = 1
                },
                new Award
                {
                    Id = 23,
                    Name = "Oscar Best Animated Feature Film",
                    AwardTypeId = 1
                }
            );
        }
    }
}
