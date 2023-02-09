using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Database.Enums;
using NuVirtualApi.Domain.Interfaces.Managers;
using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Response.Meal;
using NuVirtualApi.Domain.Models.Response.NutritionGoal;
namespace NuVirtualApi.Domain.Managers
{
    public class NutritionGoalManager : INutritionGoalManager
    {
        private readonly DatabaseContext _databaseContext;

        public NutritionGoalManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool CreateDefaultNutritionGoals(CreateDefaultNutritionGoalsRequest request)
        {
            User userDb = _databaseContext.Users.Where(u => u.Id == request.UserId).FirstOrDefault();

            if (userDb == null) return false;

            List<NutritionGoal> newNutritionGoals = new List<NutritionGoal>()
            {
                new NutritionGoal()
                {
                    Name = "Glucides",
                    Order = 1,
                    Type = MacronutrientTypeEnum.Carbohydratre,
                    TotalValue = request.Gender == GenderEnum.Male ? 300 : 220,
                    User = userDb
                },
                new NutritionGoal()
                {
                    Name = "Lipides",
                    Order = 2,
                    Type = MacronutrientTypeEnum.Lipid,
                    TotalValue = request.Gender == GenderEnum.Male ? 100 : 60,
                    User = userDb
                },
                new NutritionGoal()
                {
                    Name = "Protéines",
                    Order = 3,
                    Type = MacronutrientTypeEnum.Protein,
                    TotalValue = request.Gender == GenderEnum.Male ? 130 : 80,
                    User = userDb
                },
                new NutritionGoal()
                {
                    Name = "Calories",
                    Order = 4,
                    Type = MacronutrientTypeEnum.Calorie,
                    TotalValue = request.Gender == GenderEnum.Male ? 2000 : 1700,
                    User = userDb
                },
            };

            _databaseContext.NutritionGoals.AddRange(newNutritionGoals);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<NutritionGoalViewModel> GetAllNutritionGoalsByUserId(int userId)
        {
            var nutritionGoalsDb = _databaseContext.NutritionGoals.Where(n => n.User.Id == userId).ToList();

            List<NutritionGoalViewModel> result = new List<NutritionGoalViewModel>();

            nutritionGoalsDb.ForEach(n =>
            {
                result.Add(new NutritionGoalViewModel() 
                {
                    Id = n.Id,
                    Name = n.Name,
                    Type = n.Type,
                    Order = n.Order,
                    TotalValue = n.TotalValue
                });
            });

            return result;
        }

        public List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request, List<MealViewModel> mealsByDate)
        {
            var nutritionGoalsDb = _databaseContext.NutritionGoals.Where(n => n.User.Id == request.UserId).ToList();

            int allCarbohydratesByDay = 0;
            int allLipidsByDay = 0;
            int allProteinsByDay = 0;
            int allCaloriesByDay = 0;

            mealsByDate.ForEach(m =>
            {
                allCarbohydratesByDay += m.Carbohydrate;
                allLipidsByDay += m.Lipid;
                allProteinsByDay += m.Protein;
                allCaloriesByDay += m.Calorie;
            });

            List <NutritionGoalViewModel> result = new List<NutritionGoalViewModel>();

            nutritionGoalsDb.ForEach(n =>
            {
                int achievedValue = 0;
                double achievedRatio = 0;

                switch (n.Type)
                {
                    case MacronutrientTypeEnum.Carbohydratre:
                        achievedValue = allCarbohydratesByDay;
                        achievedRatio = (double)allCarbohydratesByDay / n.TotalValue;
                        break;
                    case MacronutrientTypeEnum.Lipid:
                        achievedValue = allLipidsByDay;
                        achievedRatio = (double)allLipidsByDay / n.TotalValue;
                        break;
                    case MacronutrientTypeEnum.Protein:
                        achievedValue = allProteinsByDay;
                        achievedRatio = (double)allProteinsByDay / n.TotalValue;
                        break;
                    case MacronutrientTypeEnum.Calorie:
                        achievedValue = allCaloriesByDay;
                        achievedRatio = (double)allCaloriesByDay / n.TotalValue;
                        break;
                }

                result.Add(new NutritionGoalViewModel()
                {
                    Id = n.Id,
                    Order = n.Order,
                    Name = n.Name,
                    Type = n.Type,
                    Date = request.Date,                    
                    AchievedValue = achievedValue,
                    AchievedRatio = achievedRatio,
                    TotalValue = n.TotalValue
                });
            });

            return result;
        }

        public bool UpdateNutritionGoal(UpdateNutritionGoalsRequest request)
        {
            int changedNutritionGoals = 0;
            
            request.NutritionGoals.ForEach(nutritionGoal =>
            {
                var nutritionGoalDb = _databaseContext.NutritionGoals.Where(n => n.Id == nutritionGoal.Id).FirstOrDefault();

                nutritionGoalDb.Order = nutritionGoal.Order;
                nutritionGoalDb.TotalValue = nutritionGoal.TotalValue;

                _databaseContext.ChangeTracker.Clear();
                _databaseContext.NutritionGoals.Update(nutritionGoalDb);
                changedNutritionGoals += _databaseContext.SaveChanges();
            });

            return changedNutritionGoals == request.NutritionGoals.Count ? true : false;
        }
    }
}
