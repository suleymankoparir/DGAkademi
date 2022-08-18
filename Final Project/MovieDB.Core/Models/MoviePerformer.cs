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
