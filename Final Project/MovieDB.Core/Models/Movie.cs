namespace MovieDB.Core.Models
{
    public class Movie : BaseEntity
    {
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; set; }
        public decimal Gross { get; set; }
        public List<MovieCategory> MovieCategory { get; set; }
        public List<MovieProducer> MovieProducer { get; set; }
        public List<MoviePerformer> MoviePerformer { get; set; }
        public List<MovieDirector> MovieDirector { get; set; }
        public List<MovieAward> MovieAward { get; set; }
        public List<Review> Reviews { get; set; }
        public Popularity Populatiry { get; set; }
    }
}
