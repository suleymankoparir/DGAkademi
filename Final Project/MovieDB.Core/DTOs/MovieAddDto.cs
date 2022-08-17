using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.DTOs
{
    public class MovieAddDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; set; }
        public decimal Gross { get; set; }
    }
}
