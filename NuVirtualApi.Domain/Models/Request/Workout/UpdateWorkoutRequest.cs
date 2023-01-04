using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.Workout
{
    public class UpdateWorkoutRequest
    {
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public int TimeInSeconds { get; set; }
		public int CaloriesBurned { get; set; }
		[Required]
		public int UserId { get; set; }
	}
}
