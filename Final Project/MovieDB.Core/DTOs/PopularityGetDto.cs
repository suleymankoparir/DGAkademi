using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.DTOs
{
    public class PopularityGetDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public DateTime Since { get; set; }
    }
}
