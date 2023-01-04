using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.Monitoring
{
    public class GetMonitoringByUserIdAndDateRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
