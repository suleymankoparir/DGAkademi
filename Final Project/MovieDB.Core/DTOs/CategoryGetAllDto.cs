namespace MovieDB.Core.DTOs
{
    public class CategoryGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieGetDto> Movies { get; set; }
    }
}
