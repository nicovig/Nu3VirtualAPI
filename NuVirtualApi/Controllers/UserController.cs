using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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

    [HttpPost]
    [Route("Test")]
    public void Test([FromBody] CreateUserRequest request, [FromHeader] string password)
    {
        request.Password = password;
        //return _userBusiness.CreateUser(request);
    }

    [HttpGet]
    [Route("login")]
    public ActionResult<bool> IsUserExistByLogin([FromHeader] string login)
    {
        return _userBusiness.IsUserExistByMail(login);
    }

    [HttpGet]
    [Route("email")]
    public ActionResult<bool> IsUserExistByMail([FromHeader] string email)
    {
        return _userBusiness.IsUserExistByMail(email);
    }

    [HttpPut]
    [Authorize]
    public ActionResult<UpdateUserResponse> UpdateUser([FromBody] UpdateUserRequest request, [FromHeader] string password)
    {
        request.Password = password;
        return _userBusiness.UpdateUser(request);
    }
}
