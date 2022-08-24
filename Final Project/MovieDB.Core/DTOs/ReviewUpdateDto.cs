using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.DTOs
{
    public class ReviewUpdateDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }

        public int Score { get; set; }
        public string Comment { get; set; }
    }
}
