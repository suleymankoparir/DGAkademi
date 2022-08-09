namespace W_02.Core.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime createdTime { get; set; }
        public DateTime updatedTime { get; set; }
    }
}
