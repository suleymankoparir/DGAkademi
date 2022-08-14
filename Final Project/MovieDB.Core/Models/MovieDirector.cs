using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    public class MovieDirector
    {
        public int DirectorId { get; set; }
        public int MovieId { get; set; }
        public Director Director { get; set; }
        public Movie Movie { get; set; }
    }
}
