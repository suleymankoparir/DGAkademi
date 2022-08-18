namespace MovieDB.Core.Models
{
    public class Popularity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime Since { get; set; }
    }
}
