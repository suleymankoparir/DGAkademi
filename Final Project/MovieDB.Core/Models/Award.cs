using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    public class Award:BaseEntity
    {
        public string Type { get; set; }
        public List<MovieAward> MovieAward { get; set; }
    }
}
