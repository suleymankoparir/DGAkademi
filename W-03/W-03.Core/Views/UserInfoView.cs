using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.Entities;

namespace W_03.Core.Views
{
    public class UserInfoView
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int UserPermissionId { get; set; }
        public string PermissionName { get; set; }
        public List<SaleView> Sales { get; set; }
    }
}
