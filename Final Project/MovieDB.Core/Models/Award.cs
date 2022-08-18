namespace MovieDB.Core.Models
{
    public class Award : BaseEntity
    {
        public int AwardTypeId { get; set; }
        public AwardType AwardType { get; set; }
        public List<MovieAward> MovieAward { get; set; }
    }
}
