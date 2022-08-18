namespace MovieDB.Core.Models
{
    public class Category : BaseEntity
    {
        public List<MovieCategory> MovieCategory { get; set; }
    }
}
