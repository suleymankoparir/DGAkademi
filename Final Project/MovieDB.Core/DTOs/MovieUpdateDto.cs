namespace MovieDB.Core.DTOs
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; set; }
        public decimal Gross { get; set; }
    }
}
