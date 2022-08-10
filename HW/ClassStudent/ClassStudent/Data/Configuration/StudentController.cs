using ClassStudent.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassStudent.Data.Configuration
{
    public class StudentController : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.FullName).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(256).IsRequired();
            builder.HasOne(x => x.Class).WithMany(x => x.Students).HasForeignKey(x => x.ClassId);
        }
    }
}
