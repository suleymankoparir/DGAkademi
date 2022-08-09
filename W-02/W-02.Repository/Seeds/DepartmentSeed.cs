using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.Models;

namespace W_02.Repository.Seeds
{
    internal class DepartmentSeed : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = 1,
                    Name = "Management"
                },
                new Department
                {
                    Id = 2,
                    Name = "Information Technology"
                },
                new Department
                {
                    Id = 3,
                    Name = "Human Resources"
                },
                new Department
                {
                    Id = 4,
                    Name = "Purchasing"
                }
            );
        }
    }
}
