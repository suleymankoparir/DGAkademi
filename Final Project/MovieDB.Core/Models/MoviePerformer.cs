using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    public class MoviePerformer
    {
        public int MovieId { get; set; }
        public int PerformerId { get; set; }
        public Movie Movie { get; set; }
        public Performer Performer { get; set; }
    }
}
