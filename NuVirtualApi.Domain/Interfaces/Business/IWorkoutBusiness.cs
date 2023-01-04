using NuVirtualApi.Domain.Models.Request.Workout;
using NuVirtualApi.Domain.Models.Response.Workout;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IWorkoutBusiness
    {
        bool CreateWorkout(CreateWorkoutRequest request);
        bool DeleteWorkout(int workoutId);
        List<WorkoutViewModel> GetAllWorkoutsByUserIdAndDate(GetAllWorkoutsByUserIdAndDateRequest request);
        bool UpdateWorkout(UpdateWorkoutRequest request);
    }
}
