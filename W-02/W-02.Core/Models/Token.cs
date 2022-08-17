using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_02.Core.Models
{
    public class Token
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
