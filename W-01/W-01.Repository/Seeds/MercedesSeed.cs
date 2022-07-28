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
    internal class MercedesSeed : IEntityTypeConfiguration<Mercedes>
    {
        public void Configure(EntityTypeBuilder<Mercedes> builder)
        {
            builder.HasData(
                new Mercedes
                {
                    Id = 3,
                    Door = 2,
                    Engine = 2,
                    Wheel = 8
                }
                );
        }
    }
}
