using W_01.Models;

namespace W_01.Context
{
    public static class UserContext
    {
        public static List<User> Users = new()
        {
            new User
            {
                UserName = "suleymankoparir",
                Password = "deneme123",
                Role = "member"
            },
            new User
            {
                UserName = "admin",
                Password = "123",
                Role = "admin"
            }
        };
    }
}