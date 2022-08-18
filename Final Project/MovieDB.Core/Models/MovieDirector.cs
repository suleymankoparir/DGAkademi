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
