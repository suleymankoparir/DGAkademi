using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_02.Core.Models
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
