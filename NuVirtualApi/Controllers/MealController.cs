using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Request.NutritionGoal;
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

    [HttpDelete("id")]
    public ActionResult<bool> DeleteMeal([FromRoute] int mealId)
    {
        return _mealBusiness.DeleteMeal(mealId);
    }

    [HttpGet]
    public ActionResult<List<MealViewModel>> GetAllMealsByUserIdAndDate([FromHeader] int userId, [FromHeader] DateTime date)
    {
        var request = new GetAllMealsByUserIdAndDateRequest()
        {
            Date = date,
            UserId = userId
        };

        return _mealBusiness.GetAllMealsByUserIdAndDate(request);
    }

    [HttpPut]
    public ActionResult<bool> UpdateMeal([FromBody] UpdateMealRequest request)
    {
        return _mealBusiness.UpdateMeal(request);
    }
}
