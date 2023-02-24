using NuVirtualApi.Domain.Models.Request.FavoriteMeal;
using NuVirtualApi.Domain.Models.Response.FavoriteMeal;

namespace NuVirtualApi.Domain.Interfaces.Manager
{
    public interface IFavoriteMealManager
    {
        public bool AddFavoriteMealToDailyMeals(AddFavoriteMealToDailyMealsRequest request);
        public bool CreateFavoriteMeal(int mealId, int userId);
        public bool DeleteFavoriteMeal(int favoriteMealId);
        List<FavoriteMealViewModel> GetAllFavoriteMealsByUserId(int userId);
        FavoriteMealViewModel GetFavoriteMealById(int favoriteMealId);
        bool UpdateFavoriteMeal(UpdateFavoriteMealRequest request);
        bool UpdateFavoriteMealByMealId(int mealId, int userId);
    }
}
