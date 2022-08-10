using ClassStudent.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassStudent.Data.Seeds
{
    public class StudentSeed : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student
                {
                    Id = 1,
                    FullName ="Süleyman Koparır",
                    Address ="Bahçelievler İstanbul",
                    ClassId = 1        
                },
                new Student
                {
                    Id = 2,
                    FullName = "John Doe",
                    Address = "Bakırköy İstanbul",
                    ClassId = 2
                }
            );
        }
    }
}
