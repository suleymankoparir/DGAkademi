using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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