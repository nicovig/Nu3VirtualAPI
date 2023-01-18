using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Models.Request.Workout;
using NuVirtualApi.Domain.Models.Response.Workout;

namespace NuVirtualApi.Domain.Managers
{
    public class WorkoutManager : IWorkoutManager
    {
        private readonly DatabaseContext _databaseContext;

        public WorkoutManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool CreateWorkout(CreateWorkoutRequest request)
        {
            User workoutUser = _databaseContext.Users.Where(u => u.Id == request.UserId).FirstOrDefault();

            if (workoutUser == null)
            {
                return false;
            }

            Workout newWorkout = new Workout()
            {
                Name = request.Name,
                Date = request.Date,
                TimeInSeconds = request.TimeInSeconds,
                CaloriesBurned = request.CaloriesBurned,
                Notes = request.Notes,
                User = workoutUser
            };

            _databaseContext.Workouts.Add(newWorkout);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool DeleteWorkout(int workoutId)
        {
            Workout workout = _databaseContext.Workouts.Where(w => w.Id == workoutId).FirstOrDefault();

            if (workout == null)
            {
                return false;
            }
            _databaseContext.Workouts.Remove(workout);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<WorkoutViewModel> GetAllWorkoutsByUserIdAndDate(GetAllWorkoutsByUserIdAndDateRequest request)
        {
            List<Workout> workouts = _databaseContext.Workouts.Where(w => w.User.Id == request.UserId
                                                              && w.Date.Day == request.Date.Day
                                                              && w.Date.Month == request.Date.Month
                                                              && w.Date.Year == request.Date.Year).ToList();

            List<WorkoutViewModel> workoutViewModels = new List<WorkoutViewModel>();

            workouts.ForEach(workout =>
            {
                workoutViewModels.Add(new WorkoutViewModel()
                {
                    Id = workout.Id,
                    Name = workout.Name,
                    Date = workout.Date,
                    TimeInSeconds = workout.TimeInSeconds,
                    CaloriesBurned = workout.CaloriesBurned,
                    Notes = workout.Notes,
                    UserId = workout.User.Id
                });
            });

            return workoutViewModels;
        }

        public WorkoutViewModel GetWorkoutByWorkoutId(int workoutId)
        {
            Workout workout = _databaseContext.Workouts.Where(w => w.Id == workoutId).FirstOrDefault();

            if (workout != null)
            {
                return new WorkoutViewModel()
                {
                    Id = workout.Id,
                    Name = workout.Name,
                    Date = workout.Date,
                    TimeInSeconds = workout.TimeInSeconds,
                    CaloriesBurned = workout.CaloriesBurned,
                    Notes = workout.Notes,
                    UserId = workout.User.Id
                };
            }            

            return null;
        }

        public bool UpdateWorkout(UpdateWorkoutRequest request)
        {
            User workoutUser = _databaseContext.Users.Where(u => u.Id == request.UserId).FirstOrDefault();
            Workout workout = _databaseContext.Workouts.Where(w => w.Id == request.Id).FirstOrDefault();

            if (workoutUser == null || workout == null)
            {
                return false;
            }

            workout = new Workout()
            {
                Id = workout.Id,
                Name = request.Name,
                Date = request.Date,
                TimeInSeconds = request.TimeInSeconds,
                CaloriesBurned = request.CaloriesBurned,
                Notes = workout.Notes,
                User = workoutUser
            };

            _databaseContext.Workouts.Update(workout);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
