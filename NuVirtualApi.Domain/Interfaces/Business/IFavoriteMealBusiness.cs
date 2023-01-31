using NuVirtualApi.Domain.Models.Request.FavoriteMeal;
using NuVirtualApi.Domain.Models.Response.FavoriteMeal;

namespace NuVirtualApi.Domain.Interfaces.Business
{
    public interface IFavoriteMealBusiness
    {
        public bool DeleteFavoriteMeal(int favoriteMealId);
        List<FavoriteMealViewModel> GetAllFavoriteMealsByUserId(int userId);
        FavoriteMealViewModel GetFavoriteMealById(int favoriteMealId);
        bool UpdateFavoriteMeal(UpdateFavoriteMealRequest request);
    }
}
