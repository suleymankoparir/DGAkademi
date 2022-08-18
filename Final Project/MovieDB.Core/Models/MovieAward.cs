namespace MovieDB.Core.Models
{
    public class MovieAward
    {
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
