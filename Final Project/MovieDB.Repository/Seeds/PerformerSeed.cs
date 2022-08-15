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
    internal class PerformerSeed : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder.HasData(
                new Performer
                {
                    Id = 1,
                    Name = "Leonardo Dicaprio",
                    Birthday = DateTime.Parse("11.11.1974")
                },
                new Performer
                {
                    Id = 2,
                    Name = "Elijah Wood",
                    Birthday = DateTime.Parse("28.01.1981")
                },
                new Performer
                {
                    Id = 3,
                    Name = "Karl Urban",
                    Birthday = DateTime.Parse("07.06.1972")
                },
                new Performer
                {
                    Id = 4,
                    Name = "Christoph Waltz",
                    Birthday = DateTime.Parse("4.10.1956")
                },
                new Performer
                {
                    Id = 5,
                    Name = "Jamie Foxx",
                    Birthday = DateTime.Parse("13.12.1967")
                }
            );
        }
    }
}
