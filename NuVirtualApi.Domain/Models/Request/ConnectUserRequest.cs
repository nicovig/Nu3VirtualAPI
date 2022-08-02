using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request
{
    public class ConnectUserRequest
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
