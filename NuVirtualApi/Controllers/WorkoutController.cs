using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.Workout;
using NuVirtualApi.Domain.Models.Response.Workout;

[ApiController]
[Route("[controller]")]
public class WorkoutController : Controller
{
    private static IWorkoutBusiness _workoutBusiness;

    public WorkoutController(IWorkoutBusiness workoutBusiness)
    {
        _workoutBusiness = workoutBusiness;
    }

    [HttpPost]
    public ActionResult<bool> CreateWorkout([FromBody] CreateWorkoutRequest request)
    {
        return _workoutBusiness.CreateWorkout(request);
    }

    [HttpDelete("id")]
    [Route("{workoutId}")]
    public ActionResult<bool> DeleteWorkout([FromRoute] int workoutId)
    {
        return _workoutBusiness.DeleteWorkout(workoutId);
    }

    [HttpGet]
    public ActionResult<List<WorkoutViewModel>> GetAllWorkoutsByUserIdAndDate([FromHeader] int userId, [FromHeader] DateTime date)
    {
        var request = new GetAllWorkoutsByUserIdAndDateRequest()
        {
            Date = date,
            UserId = userId
        };

        return _workoutBusiness.GetAllWorkoutsByUserIdAndDate(request);
    }

    [HttpGet()]
    [Route("workout/{workoutId}")]
    public ActionResult<WorkoutViewModel> GetWorkoutByWorkoutId(int workoutId)
    {
        return _workoutBusiness.GetWorkoutByWorkoutId(workoutId);
    }

    [HttpPut]
    public ActionResult<bool> UpdateWorkout([FromBody] UpdateWorkoutRequest request)
    {
        return _workoutBusiness.UpdateWorkout(request);
    }
}
