namespace MovieDB.Core.DTOs
{
    public class MovieAwardDto
    {
        public DateTime Date { get; set; }
        public int MovieId { get; set; }
        public int AwardId { get; set; }
        public int? DirectorId { get; set; }
        public int? PerformerId { get; set; }
    }
}
