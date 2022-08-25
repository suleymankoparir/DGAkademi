namespace MovieDB.Core.DTOs
{
    public class MovieGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; set; }
        public decimal Gross { get; set; }
        public string MovieTypeName { get; set; }
        public List<CategoryGetDto> Categories { get; set; }
        public List<ProducerGetDto> Producers { get; set; }
        public List<PerformerGetDto> Performsers { get; set; }
        public List<AwardGetDto> Awards { get; set; }
        public List<DirectorGetDto> Directors { get; set; }
    }
}
