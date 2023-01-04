using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.Monitoring;
using NuVirtualApi.Domain.Models.Response.Monitoring;

namespace NuVirtualApi.Domain.Managers
{
    public class MonitoringManager : IMonitoringManager
    {
        private readonly DatabaseContext _databaseContext;

        public MonitoringManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public MonitoringViewModel GetMonitoringByUserIdAndDate(GetMonitoringByUserIdAndDateRequest request)
        {
            List<Meal> meals = _databaseContext.Meals.Where(m => m.User.Id == request.UserId
                                              && m.Date.Day == request.Date.Day
                                              && m.Date.Month == request.Date.Month
                                              && m.Date.Year == request.Date.Year).ToList();

            List<Workout> workouts = _databaseContext.Workouts.Where(m => m.User.Id == request.UserId
                                  && m.Date.Day == request.Date.Day
                                  && m.Date.Month == request.Date.Month
                                  && m.Date.Year == request.Date.Year).ToList();

            int caloriesBurned = 0;
            int caloriesConsumed = 0;
            int carbohydrate = 0;
            int lipid = 0;
            int protein = 0;

            meals.ForEach(m =>
            {
                caloriesConsumed += m.Calorie;
                carbohydrate += m.Carbohydrate;
                lipid += m.Lipid;
                protein += m.Lipid;
            });

            workouts.ForEach(w =>
            {
                caloriesBurned += w.CaloriesBurned;
            });

            return new MonitoringViewModel()
            {
                CaloriesBurned = caloriesBurned,
                CaloriesConsumed = caloriesConsumed,
                Carbohydrate = carbohydrate,
                Lipid = lipid,
                Protein = protein
            };
        }
    }
}