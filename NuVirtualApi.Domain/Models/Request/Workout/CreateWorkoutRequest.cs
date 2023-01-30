using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.Workout
{
    public class CreateWorkoutRequest
    {
		[Required]
		public string Name { get; set; }

		public DateTime Date { get; set; }

		public int TimeInSeconds { get; set; }

		public int CaloriesBurned { get; set; }

		public string Notes { get; set; }

		public int UserId { get; set; }
	}
}
