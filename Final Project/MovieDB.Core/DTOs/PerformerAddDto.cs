using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.DTOs
{
    public class PerformerAddDto
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
    }
}
