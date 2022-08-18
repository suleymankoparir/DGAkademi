namespace MovieDB.Core.DTOs
{
    public class ProducerGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieGetDto> Movies { get; set; }
    }
}
