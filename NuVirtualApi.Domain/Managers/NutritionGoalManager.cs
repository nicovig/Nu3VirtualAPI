using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Database.Enums;
using NuVirtualApi.Domain.Interfaces.Managers;
using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Response.NutritionGoal;
using System;
using System.Collections.Generic;
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

        public List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request, List<Meal> mealsByDate)
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
                        achievedRatio = allCarbohydratesByDay / n.TotalValue;
                        break;
                    case MacronutrientTypeEnum.Lipid:
                        achievedValue = allLipidsByDay;
                        achievedRatio = allLipidsByDay / n.TotalValue;
                        break;
                    case MacronutrientTypeEnum.Protein:
                        achievedValue = allProteinsByDay;
                        achievedRatio = allProteinsByDay / n.TotalValue;
                        break;
                    case MacronutrientTypeEnum.Calorie:
                        achievedValue = allCaloriesByDay;
                        achievedRatio = allCaloriesByDay / n.TotalValue;
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

        public bool UpdateNutritionGoal(UpdateNutritionGoalRequest request)
        {
            var nutritionGoalDb = _databaseContext.NutritionGoals.Where(n => n.Id == request.Id).FirstOrDefault();

            if (nutritionGoalDb == null) return false;

            nutritionGoalDb.Order = request.Order;
            nutritionGoalDb.TotalValue = request.TotalValue;

            _databaseContext.NutritionGoals.Update(nutritionGoalDb);

            _databaseContext.SaveChanges();

            return true;
        }
    }
}
