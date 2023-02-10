using NuVirtualApi.Domain.Interfaces.Business;
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
            int mealId = _favoriteMealManager.DeleteFavoriteMeal(favoriteMealId);

            if (mealId == null || mealId == 0) {
                return false;
            }

            return _mealManager.UpdateIsFavoriteByMealId(mealId);
        }

        public List<FavoriteMealViewModel> GetAllFavoriteMealsByUserId(int userId)
        {
            return _favoriteMealManager.GetAllFavoriteMealsByUserId(userId);
        }

        public FavoriteMealViewModel GetFavoriteMealById(int favoriteMealId)
        {
            return _favoriteMealManager.GetFavoriteMealById(favoriteMealId);
        }

        public bool UpdateFavoriteMeal(UpdateFavoriteMealRequest request)
        {
            return _favoriteMealManager.UpdateFavoriteMeal(request);
        }
    }
}
