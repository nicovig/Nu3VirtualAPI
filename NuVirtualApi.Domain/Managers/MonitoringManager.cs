using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Database.Enums;
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

            List<NutritionGoal> sortedAndActiveNutritionGoalsDb = _databaseContext.NutritionGoals.Where(n => (n.User.Id == request.UserId) && n.IsActive).OrderBy(o => o.Order).ToList();

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
                protein += m.Protein;
            });

            workouts.ForEach(w =>
            {
                caloriesBurned += w.CaloriesBurned;
            });

            MonitoringViewModel returnValue = new MonitoringViewModel();
            returnValue.NutritionGoalsMonitoring = new List<NutritionGoalMonitoringViewModel>();

            sortedAndActiveNutritionGoalsDb.ForEach(s =>
            {
                switch (s.Type)
                {
                    case MacronutrientTypeEnum.Carbohydratre:
                        returnValue.NutritionGoalsMonitoring.Add(new NutritionGoalMonitoringViewModel()
                        {
                            Type = MonitoringInformationTypeEnum.Carbohydrate,
                            Value = carbohydrate
                        });
                        break;
                    case MacronutrientTypeEnum.Lipid:
                        returnValue.NutritionGoalsMonitoring.Add(new NutritionGoalMonitoringViewModel()
                        {
                            Type = MonitoringInformationTypeEnum.Lipid,
                            Value = lipid
                        });
                        break;
                    case MacronutrientTypeEnum.Protein:
                        returnValue.NutritionGoalsMonitoring.Add(new NutritionGoalMonitoringViewModel()
                        {
                            Type = MonitoringInformationTypeEnum.Protein,
                            Value = protein
                        });
                        break;
                    case MacronutrientTypeEnum.Calorie:
                        returnValue.NutritionGoalsMonitoring.AddRange(new List<NutritionGoalMonitoringViewModel>()
                        {
                            new NutritionGoalMonitoringViewModel()
                        {
                            Type = MonitoringInformationTypeEnum.CaloriesConsumed,
                            Value = caloriesConsumed
                        },
                            new NutritionGoalMonitoringViewModel()
                        {
                            Type = MonitoringInformationTypeEnum.CaloriesBurned,
                            Value = caloriesBurned
                        }
                        });
                        break;
                }
            });

            return returnValue;
        }
    }
}