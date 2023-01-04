namespace NuVirtualApi.Domain.Models.Response.Workout
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int TimeInSeconds { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
    }
}
