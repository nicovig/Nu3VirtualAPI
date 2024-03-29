﻿using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Models.Request.FavoriteMeal;
using NuVirtualApi.Domain.Models.Response.FavoriteMeal;

namespace NuVirtualApi.Domain.Business
{
    public class FavoriteMealBusiness : IFavoriteMealBusiness
    {
        public IFavoriteMealManager _favoriteMealManager;
        public IMealManager _mealManager;

        public FavoriteMealBusiness(IFavoriteMealManager favoriteMealManager, IMealManager mealManager)
        {
            _favoriteMealManager = favoriteMealManager;
            _mealManager = mealManager;
        }

        public bool AddFavoriteMealToDailyMeals(AddFavoriteMealToDailyMealsRequest request)
        {
            return _favoriteMealManager.AddFavoriteMealToDailyMeals(request);
        }

        public bool DeleteFavoriteMeal(int favoriteMealId)
        {
            bool isMealsUpdated = _mealManager.UpdateIsFavoriteByFavoriteMealId(favoriteMealId);

            if (!isMealsUpdated) {
                return false;
            }

            return _favoriteMealManager.DeleteFavoriteMeal(favoriteMealId);
        }

        public List<FavoriteMealViewModel> GetAllFavoriteMealsByUserId(int userId)
        {
            return _favoriteMealManager.GetAllFavoriteMealsByUserId(userId);
        }
    }
}
