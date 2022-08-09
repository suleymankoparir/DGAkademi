namespace W_02.Core.Models
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
