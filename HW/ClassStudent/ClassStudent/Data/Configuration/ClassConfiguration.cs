using ClassStudent.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassStudent.Data.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x=>x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(32).IsRequired();
            builder.HasMany(x => x.Students).WithOne(x => x.Class).HasForeignKey(x=>x.ClassId);
        }
    }
}
