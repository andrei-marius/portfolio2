namespace WebServer.Models
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "user";
    }
}