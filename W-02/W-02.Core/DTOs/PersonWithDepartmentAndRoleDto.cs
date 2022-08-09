using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_02.Core.DTOs
{
    public class PersonWithDepartmentAndRoleDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string? DepartmantName { get; set; }
        public string? RoleName { get; set; }
    }
}
