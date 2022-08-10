using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using W_02.Core.Models;

namespace W_02.Repository.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            
            builder.Property(x => x.UserName).HasMaxLength(32).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(64).IsRequired();
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.Password).HasMaxLength(64).IsRequired();
            builder.HasOne(x => x.Department).WithMany(x =>x.People).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.Role).WithMany(x => x.People).HasForeignKey(x => x.RoleId);
        }
    }
}
