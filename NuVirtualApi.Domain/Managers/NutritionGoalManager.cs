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
                    IsActive = true,
                    User = userDb
                },
                new NutritionGoal()
                {
                    Name = "Lipides",
                    Order = 2,
                    Type = MacronutrientTypeEnum.Lipid,
                    TotalValue = request.Gender == GenderEnum.Male ? 100 : 60,
                    IsActive = true,
                    User = userDb
                },
                new NutritionGoal()
                {
                    Name = "Protéines",
                    Order = 3,
                    Type = MacronutrientTypeEnum.Protein,
                    TotalValue = request.Gender == GenderEnum.Male ? 130 : 80,
                    IsActive = true,
                    User = userDb
                },
                new NutritionGoal()
                {
                    Name = "Calories",
                    Order = 4,
                    Type = MacronutrientTypeEnum.Calorie,
                    TotalValue = request.Gender == GenderEnum.Male ? 2000 : 1700,
                    IsActive = true,
                    User = userDb
                },
            };

            _databaseContext.NutritionGoals.AddRange(newNutritionGoals);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<NutritionGoalViewModel> GetAllNutritionGoalsByUserId(int userId)
        {
            List<NutritionGoal> sortedNutritionGoalsDb = _databaseContext.NutritionGoals.Where(n => n.User.Id == userId).OrderBy(o => o.Order).ToList();

            List<NutritionGoalViewModel> result = new List<NutritionGoalViewModel>();

            sortedNutritionGoalsDb.ForEach(n =>
            {
                result.Add(new NutritionGoalViewModel() 
                {
                    Id = n.Id,
                    Name = n.Name,
                    Type = n.Type,
                    Order = n.Order,
                    IsActive = n.IsActive,
                    TotalValue = n.TotalValue
                });
            });

            return result;
        }

        public List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request, List<MealViewModel> mealsByDate)
        {
            List<NutritionGoal> sortedAndActiveNutritionGoalsDb = _databaseContext.NutritionGoals.Where(n => (n.User.Id == request.UserId) && n.IsActive).OrderBy(o => o.Order).ToList();

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

            sortedAndActiveNutritionGoalsDb.ForEach(n =>
            {
                int achievedValue = 0;
                double achievedRatio = 0;

                switch (n.Type)
                {
                    case MacronutrientTypeEnum.Carbohydratre:
                        achievedValue = allCarbohydratesByDay;
                        if (n.TotalValue > 0)
                        {
                            achievedRatio = (double)allCarbohydratesByDay / n.TotalValue;
                        }
                        else achievedRatio = 0;
                        break;
                    case MacronutrientTypeEnum.Lipid:
                        achievedValue = allLipidsByDay;
                        if (n.TotalValue > 0)
                        {
                            achievedRatio = (double)allLipidsByDay / n.TotalValue;
                        }
                        else achievedRatio = 0;
                        break;
                    case MacronutrientTypeEnum.Protein:
                        achievedValue = allProteinsByDay;
                        if (n.TotalValue > 0)
                        {
                            achievedRatio = (double)allProteinsByDay / n.TotalValue;
                        }
                        else achievedRatio = 0;
                        break;
                    case MacronutrientTypeEnum.Calorie:
                        achievedValue = allCaloriesByDay;
                        if (n.TotalValue > 0)
                        {
                            achievedRatio = (double)allCaloriesByDay / n.TotalValue;
                        }
                        else achievedRatio = 0;
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
                    TotalValue = n.TotalValue,
                    IsActive = n.IsActive
                });
            });

            return result;
        }

        public bool UpdateNutritionGoals(UpdateNutritionGoalsRequest request)
        {
            int changedNutritionGoals = 0;

            for (int i = 0; i < request.NutritionGoals.Count; i++)
            {
                var nutritionGoalUpdated = request.NutritionGoals[i];
                var nutritionGoalDb = _databaseContext.NutritionGoals.Where(n => n.Id == nutritionGoalUpdated.Id).FirstOrDefault();

                if (nutritionGoalDb != null)
                {
                    nutritionGoalDb.IsActive = nutritionGoalUpdated.IsActive;
                    nutritionGoalDb.TotalValue = nutritionGoalUpdated.TotalValue;
                    nutritionGoalDb.Order = i + 1;

                    _databaseContext.ChangeTracker.Clear();
                    _databaseContext.NutritionGoals.Update(nutritionGoalDb);
                    changedNutritionGoals += _databaseContext.SaveChanges();
                }
            }

            return changedNutritionGoals == request.NutritionGoals.Count ? true : false;
        }
    }
}
