using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Request.User;
using NuVirtualApi.Domain.Models.Response.User;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private static IUserBusiness _userBusiness;

    public UserController(IUserBusiness userBusiness)
    {
        _userBusiness = userBusiness;
    }

    [HttpPost]
    public ActionResult<CreateUserResponse> CreateUser([FromBody] CreateUserRequest request, [FromHeader] string password)
    {
        return _userBusiness.CreateUser(request);
    }

    [HttpPut]
    public ActionResult<bool> UpdateUser([FromBody] UpdateUserRequest request)
    {
        return _userBusiness.UpdateUser(request);
    }
}
