using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.User
{
    public class UpdateUserRequest
    {
        [Required]
        public UserModel User { get; set; }
    }
}
