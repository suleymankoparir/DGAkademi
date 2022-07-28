using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_01.Core.Models;

namespace W_01.Repository.Seeds
{
    internal class AudiSeed : IEntityTypeConfiguration<Audi>
    {
        public void Configure(EntityTypeBuilder<Audi> builder)
        {
            
            builder.HasData(
                new Audi
                {
                    Id = 1,
                    Door = 5,
                    Engine = 1,
                    Wheel = 4
                }
                );
            
        }
    }
}