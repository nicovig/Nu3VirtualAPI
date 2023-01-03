using NuVirtualApi.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.User
{
    public class UpdateUserRequest
    {
        [Required]
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
