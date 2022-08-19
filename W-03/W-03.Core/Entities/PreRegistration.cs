using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_03.Core.Entities
{
    public class PreRegistration:BaseEntity
    {
        public string Email { get; set; }
        public string Ip { get; set; }
        public string Hash { get; set; }
        public DateTime EndDate { get; set; }

    }
}
