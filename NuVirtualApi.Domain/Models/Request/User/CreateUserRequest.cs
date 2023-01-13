using NuVirtualApi.Database.Enums;

namespace NuVirtualApi.Domain.Models.Request.User
{
    public class CreateUserRequest
    {
        public string Pseudo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int Height { get; set; } //cm
        public double Weight { get; set; } //kg
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
