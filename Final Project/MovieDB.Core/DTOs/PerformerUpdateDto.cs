using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.DTOs
{
    public class PerformerUpdateDto:BaseEntity
    {
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
    }
}
