using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.DTOs;
using W_03.Core.Entities;

namespace W_03.Core.Views
{
    public class JwtUserListView
    {
        public string JwtToken { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
