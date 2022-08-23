using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_03.Core.Views
{
    public class PreRegisteredUserRegistrationView
    {
        public string Hash { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int UserPermissionId { get; set; }
    }
}
