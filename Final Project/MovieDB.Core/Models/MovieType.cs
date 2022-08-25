using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    public class MovieType:BaseEntity
    {
        public List<Movie> Movies { get; set;}
        public List<AwardType> AwardTypes { get; set;}
    }
}
