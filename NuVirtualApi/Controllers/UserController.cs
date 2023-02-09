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

    [HttpPatch]
    [Route("password")]
    public ActionResult<bool> ChangePassword([FromHeader] string userId, [FromHeader] string oldPassword, [FromHeader] string newPassword)
    {
        return _userBusiness.ChangePassword(int.Parse(userId), oldPassword, newPassword);
    }

    [HttpPost]
    public ActionResult<CreateUserResponse> CreateUser([FromBody] CreateUserRequest request, [FromHeader] string password)
    {
        request.Password = password;
        return _userBusiness.CreateUser(request);
    }

    [HttpPut]
    public ActionResult<bool> UpdateUser([FromBody] UpdateUserRequest request)
    {
        return _userBusiness.UpdateUser(request);
    }
}
