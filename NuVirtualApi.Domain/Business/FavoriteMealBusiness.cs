using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Models.Request.FavoriteMeal;
using NuVirtualApi.Domain.Models.Response.FavoriteMeal;

namespace NuVirtualApi.Domain.Business
{
    public class FavoriteMealBusiness : IFavoriteMealBusiness
    {
        public IFavoriteMealManager _favoriteMealManager;

        public FavoriteMealBusiness(IFavoriteMealManager favoriteMealManager)
        {
            _favoriteMealManager = favoriteMealManager;
        }

        public bool AddFavoriteMealToDailyMeals(AddFavoriteMealToDailyMealsRequest request)
        {
            return _favoriteMealManager.AddFavoriteMealToDailyMeals(request);
        }

        public bool DeleteFavoriteMeal(int favoriteMealId)
        {
            return _favoriteMealManager.DeleteFavoriteMeal(favoriteMealId);
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
