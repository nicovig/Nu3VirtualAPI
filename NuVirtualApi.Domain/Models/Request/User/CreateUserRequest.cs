using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.User
{
    public class CreateUserRequest
    {
        [Required]
        public UserModel User { get; set; }
    }
}
