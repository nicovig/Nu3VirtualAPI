using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.Workout
{
    public class GetAllWorkoutsByUserIdAndDateRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
