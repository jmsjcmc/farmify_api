namespace Api.DTO
{
    public class UserDTO
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IFormFile Avatar { get; set; }
    }

    public class Userlogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
