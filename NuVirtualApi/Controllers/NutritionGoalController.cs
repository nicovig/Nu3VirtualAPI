using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.NutritionGoal;
using NuVirtualApi.Domain.Models.Response.NutritionGoal;

[ApiController]
[Route("[controller]")]
public class NutritionGoalController : Controller
{
    private static INutritionGoalBusiness _nutritionGoalBusiness;

    public NutritionGoalController(INutritionGoalBusiness nutritionGoalBusiness)
    {
        _nutritionGoalBusiness = nutritionGoalBusiness;
    }

    [HttpGet()]
    public ActionResult<List<NutritionGoalViewModel>> GetAllNutritionGoalsByUserId([FromHeader] int userId)
    {
        return _nutritionGoalBusiness.GetAllNutritionGoalsByUserId(userId);
    }

    [HttpGet()]
    [Route("withDate")]
    public ActionResult<List<NutritionGoalViewModel>> GetAllNutritionGoalsByUserIdAndDate([FromHeader] int userId, [FromHeader] DateTime date)
    {
        var request = new GetAllNutritionGoalsByUserIdAndDateRequest()
        {
            Date = date,
            UserId = userId
        };

        return _nutritionGoalBusiness.GetAllNutritionGoalsByUserIdAndDate(request);
    }

    [HttpPut]
    public ActionResult<bool> UpdateNutritionGoals([FromBody] UpdateNutritionGoalsRequest request)
    {
        return _nutritionGoalBusiness.UpdateNutritionGoals(request);
    }
}
