using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDB.Core.Models;

namespace MovieDB.Repository.Seeds
{
    internal class ProducerSeed : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasData(
                new Producer
                {
                    Id = 1,
                    Name = "Regency Enterprises"
                },
                new Producer
                {
                    Id = 2,
                    Name = "Dune Entertainment"
                },
                new Producer
                {
                    Id = 3,
                    Name = "Columbia Pictures"
                },
                new Producer
                {
                    Id = 4,
                    Name = "The Weinstein Company"
                },
                new Producer
                {
                    Id = 5,
                    Name = "New Line Cinema"
                },
                new Producer
                {
                    Id = 6,
                    Name = "Wingnut Films"
                }
            );
        }
    }
}
