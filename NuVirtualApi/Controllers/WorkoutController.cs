﻿using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<bool> DeleteWorkout([FromRoute] int mealId)
    {
        return _workoutBusiness.DeleteWorkout(mealId);
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

    [HttpPut]
    public ActionResult<bool> UpdateWorkout([FromBody] UpdateWorkoutRequest request)
    {
        return _workoutBusiness.UpdateWorkout(request);
    }
}
