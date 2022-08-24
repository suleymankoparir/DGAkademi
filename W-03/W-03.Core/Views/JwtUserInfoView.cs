using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.DTOs;
using W_03.Core.Entities;

namespace W_03.Core.Views
{
    public class JwtUserInfoView:BaseEntity
    {
        public string JwtToken { get; set; }
        public string Email { get; set; }
        public UserPermission UserPermission { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
