using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Models.Request.Workout;
using NuVirtualApi.Domain.Models.Response.Workout;

namespace NuVirtualApi.Domain.Business
{
    public class WorkoutBusiness : IWorkoutBusiness
    {
        public IWorkoutManager _workoutManager;

        public WorkoutBusiness(IWorkoutManager workoutManager)
        {
            _workoutManager = workoutManager;
        }

        public bool CreateWorkout(CreateWorkoutRequest request)
        {
            return _workoutManager.CreateWorkout(request);
        }

        public bool DeleteWorkout(int workoutId)
        {
            return _workoutManager.DeleteWorkout(workoutId);
        }

        public List<WorkoutViewModel> GetAllWorkoutsByUserIdAndDate(GetAllWorkoutsByUserIdAndDateRequest request)
        {
            return _workoutManager.GetAllWorkoutsByUserIdAndDate(request);
        }

        public bool UpdateWorkout(UpdateWorkoutRequest request)
        {
            return _workoutManager.UpdateWorkout(request);
        }
    }
}
