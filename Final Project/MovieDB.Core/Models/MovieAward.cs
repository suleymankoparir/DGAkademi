using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    public class MovieAward
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MovieId { get; set; }
        public int AwardId { get; set; }
        public int? DirectorId { get; set; }
        public int? PerformerId { get; set; }
        public Award Award { get; set; }
        public Movie Movie { get; set; }
        public Director Director { get; set; }
        public Performer Performer { get; set; }
    }
}
