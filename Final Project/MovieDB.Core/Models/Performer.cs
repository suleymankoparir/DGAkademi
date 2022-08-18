namespace MovieDB.Core.Models
{
    public class Performer : BaseEntity
    {
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public List<MoviePerformer> MoviePerformer { get; set; }
        public List<MovieAward> MovieAward { get; set; }
    }
}
