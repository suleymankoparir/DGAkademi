namespace MovieDB.Core.Models
{
    public class Director : BaseEntity
    {
        public DateTime Birthday { get; set; }
        public List<MovieDirector> MovieDirector { get; set; }
        public List<MovieAward> MovieAward { get; set; }
    }
}
