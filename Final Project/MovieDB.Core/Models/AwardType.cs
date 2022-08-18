using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    public class AwardType:BaseEntity
    {
        public List<Award> Awards { get; set; }
    }
}
