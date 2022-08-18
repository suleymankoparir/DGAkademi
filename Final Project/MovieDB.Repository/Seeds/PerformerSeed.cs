using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Seeds
{
    internal class PerformerSeed : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder.HasData(
                new Performer
                {
                    Id = 1,
                    Name = "Leonardo Dicaprio",
                    Birthday = DateTime.Parse("11.11.1974"),
                    Gender = "Male"
                },
                new Performer
                {
                    Id = 2,
                    Name = "Elijah Wood",
                    Birthday = DateTime.Parse("28.01.1981"),
                    Gender = "Male"
                },
                new Performer
                {
                    Id = 3,
                    Name = "Karl Urban",
                    Birthday = DateTime.Parse("07.06.1972"),
                    Gender = "Male"
                },
                new Performer
                {
                    Id = 4,
                    Name = "Christoph Waltz",
                    Birthday = DateTime.Parse("4.10.1956"),
                    Gender = "Male"
                },
                new Performer
                {
                    Id = 5,
                    Name = "Jamie Foxx",
                    Birthday = DateTime.Parse("13.12.1967"),
                    Gender = "Male"
                }
            );
        }
    }
}
