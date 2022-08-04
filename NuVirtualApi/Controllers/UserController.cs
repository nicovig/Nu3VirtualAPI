using NuVirtualApi.Domain.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Models.Request.User;
using NuVirtualApi.Domain.Models;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static IUserBusiness _userBusiness;

    public UserController(IUserBusiness userBusiness)
    {
        _userBusiness = userBusiness;
    }

    [HttpPost]
    public ActionResult<UserModel> Create(CreateUserRequest request)
    {
        if (ModelState.IsValid)
        {
            return _userBusiness.CreateUser(request);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
}