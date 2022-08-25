using MovieDB.Core.Models;

namespace MovieDB.Core.DTOs
{
    public class MovieGetDto : BaseEntity
    {
        public decimal Budget { get; set; }
        public decimal Gross { get; set; }
        public string MovieTypeId { get; set; }
    }
}
