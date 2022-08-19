using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.DTOs
{
    public class AwardTypeGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AwardGetDto> Awards { get; set; }
    }
}
