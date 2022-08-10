namespace ClassStudent.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }

    }
}
