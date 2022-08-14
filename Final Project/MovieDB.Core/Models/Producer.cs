using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    public class Producer:BaseEntity
    {
        public List<MovieProducer> MovieProducer { get; set; }
    }
}
