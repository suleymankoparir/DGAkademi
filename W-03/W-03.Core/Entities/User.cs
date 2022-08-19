using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_03.Core.Entities
{
    public class User:BaseEntity
    {
        public int UserPermissionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Sale> Sales { get; set; }
        public UserPermission UserPermission { get; set; }
        public UserInformation UserInformation { get; set; }

    }
}
