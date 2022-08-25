namespace MovieDB.Core.DTOs
{
    public class MovieAddDto
    {
        public string Name { get; set; }
        public int MovieTypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; set; }
        public decimal Gross { get; set; }
    }
}
