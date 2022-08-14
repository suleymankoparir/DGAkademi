using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    public class MovieProducer
    {
        public int MovieId { get; set; }
        public int ProducerId { get; set; }
        public Movie Movie { get; set;}
        public Producer Producer { get; set;}
    }
}
