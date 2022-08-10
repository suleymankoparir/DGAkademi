using ClassStudent.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassStudent.Data.Seeds
{
    public class ClassSeed : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasData(
                new Class
                {
                    Id = 1,
                    Name ="1A"
                },
                new Class
                {
                    Id=2,
                    Name ="1B"
                }
            );
        }
    }
}
