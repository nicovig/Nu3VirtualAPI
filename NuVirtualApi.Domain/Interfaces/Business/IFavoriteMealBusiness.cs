using NuVirtualApi.Domain.Models.Request.FavoriteMeal;
using NuVirtualApi.Domain.Models.Response.FavoriteMeal;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IFavoriteMealBusiness
    {
        public bool AddFavoriteMealToDailyMeals(AddFavoriteMealToDailyMealsRequest request);
        public bool DeleteFavoriteMeal(int favoriteMealId);
        List<FavoriteMealViewModel> GetAllFavoriteMealsByUserId(int userId);
    }
}
