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
    internal class BmwSeed : IEntityTypeConfiguration<Bmw>
    {
        public void Configure(EntityTypeBuilder<Bmw> builder)
        { 
            builder.HasData(
                new Bmw
                {
                    Id = 2,
                    Door = 2,
                    Engine = 2,
                    Wheel = 6
                }
                );
            
        }
    }
}