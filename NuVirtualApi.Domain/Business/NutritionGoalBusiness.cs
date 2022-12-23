﻿using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Interfaces.Managers;
using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Response.Meal;
using NuVirtualApi.Domain.Models.Response.NutritionGoal;

namespace NuVirtualApi.Domain.Business
{
    public class NutritionGoalBusiness : INutritionGoalBusiness
    {
        public INutritionGoalManager _nutritionGoalManager;
        public IMealManager _mealManager;

        public NutritionGoalBusiness(IMealManager mealManager, INutritionGoalManager nutritionGoalManager)
        {
            _mealManager = mealManager;
            _nutritionGoalManager = nutritionGoalManager;
        }

        public bool CreateDefaultNutritionGoals(CreateDefaultNutritionGoalsRequest request)
        {
            return _nutritionGoalManager.CreateDefaultNutritionGoals(request);
        }

        public List<NutritionGoalViewModel> GetAllNutritionGoalsByUserIdAndDate(GetAllNutritionGoalsByUserIdAndDateRequest request)
        {
            List<MealViewModel> mealsByDate = _mealManager.GetAllMealsByUserIdAndDate(new GetAllMealsByUserIdAndDateRequest()
            {
                UserId = request.UserId,
                Date = request.Date,
            });
            return _nutritionGoalManager.GetAllNutritionGoalsByUserIdAndDate(request, mealsByDate);
        }

        public bool UpdateNutritionGoal(UpdateNutritionGoalRequest request)
        {
            return _nutritionGoalManager.UpdateNutritionGoal(request);
        }
    }
}
