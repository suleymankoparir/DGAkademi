using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.DTOs
{
    public class UserGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<ReviewGetDto> Reviews { get; set; }
        public string Role { get; set; }
    }
}
