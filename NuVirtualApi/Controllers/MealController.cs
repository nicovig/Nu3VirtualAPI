using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Response.Meal;

[ApiController]
[Route("[controller]")]
public class MealController : Controller
{
    private static IMealBusiness _mealBusiness;

    public MealController(IMealBusiness mealBusiness)
    {
        _mealBusiness = mealBusiness;
    }

    [HttpPost]
    public ActionResult<bool> CreateMeal([FromBody] CreateMealRequest request)
    {
        return _mealBusiness.CreateMeal(request);
    }

    [HttpDelete()]
    [Route("{mealId}")]
    public ActionResult<bool> DeleteMeal([FromRoute] int mealId)
    {
        return _mealBusiness.DeleteMeal(mealId);
    }

    [HttpGet()]
    [Route("favorites")]
    public ActionResult<List<MealViewModel>> GetFavoritesMeals()
    {
        return _mealBusiness.GetFavoritesMeals();
    }

    [HttpGet()]
    public ActionResult<List<MealViewModel>> GetAllMealsByUserIdAndDate([FromHeader] int userId, [FromHeader] DateTime date)
    {
        var request = new GetAllMealsByUserIdAndDateRequest()
        {
            Date = date,
            UserId = userId
        };

        return _mealBusiness.GetAllMealsByUserIdAndDate(request);
    }

    [HttpGet()]
    [Route("meal/{mealId}")]
    public ActionResult<MealViewModel> GetMealByMealId([FromRoute] int mealId)
    {
        return _mealBusiness.GetMealByMealId(mealId);
    }

    [HttpPut]
    public ActionResult<bool> UpdateMeal([FromBody] UpdateMealRequest request)
    {
        return _mealBusiness.UpdateMeal(request);
    }
}
