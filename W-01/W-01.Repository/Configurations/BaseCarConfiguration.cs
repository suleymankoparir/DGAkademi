using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using W_01.Core.Models;

namespace W_01.Repository.Configurations
{
    internal class BaseCarConfiguration : IEntityTypeConfiguration<BaseCar>
    {
        public void Configure(EntityTypeBuilder<BaseCar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
