namespace MovieDB.Core.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Review> Reviews { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? TokenEndDate { get; set; }
    }
}
