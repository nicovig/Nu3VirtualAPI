using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.FavoriteMeal;
using NuVirtualApi.Domain.Models.Response.FavoriteMeal;

[ApiController]
[Authorize]
[Route("[controller]")]
public class FavoriteMealController : Controller
{
    private static IFavoriteMealBusiness _favoriteMealBusiness;

    public FavoriteMealController(IFavoriteMealBusiness favoriteMealBusiness)
    {
        _favoriteMealBusiness = favoriteMealBusiness;
    }

    [HttpPost()]
    public ActionResult<bool> AddFavoriteMealToDailyMeals([FromHeader] int userId, [FromBody] AddFavoriteMealToDailyMealsRequest request)
    {
        request = new AddFavoriteMealToDailyMealsRequest()
        {
            Date = request.Date,
            FavoriteMealId = request.FavoriteMealId,
            UserId = userId
        };

        return _favoriteMealBusiness.AddFavoriteMealToDailyMeals(request);
    }

    [HttpDelete()]
    [Route("{favoriteMealId}")]
    public ActionResult<bool> DeleteFavoriteMeal([FromRoute] int favoriteMealId)
    {
        return _favoriteMealBusiness.DeleteFavoriteMeal(favoriteMealId);
    }

    [HttpGet]
    public ActionResult<List<FavoriteMealViewModel>> GetAllFavoriteMealsByUserId([FromHeader] int userId)
    {
        return _favoriteMealBusiness.GetAllFavoriteMealsByUserId(userId);
    }

    [HttpGet()]
    [Route("favoriteMeal/{favoriteMealId}")]
    public ActionResult<FavoriteMealViewModel> GetFavoriteMealById(int favoriteMealId)
    {
        return _favoriteMealBusiness.GetFavoriteMealById(favoriteMealId);
    }

    [HttpPut]
    public ActionResult<bool> UpdateFavoriteMeal([FromBody] UpdateFavoriteMealRequest request)
    {
        return _favoriteMealBusiness.UpdateFavoriteMeal(request);
    }
}
