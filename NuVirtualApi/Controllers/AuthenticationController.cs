using NuVirtualApi.Domain.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using NuVirtualApi.Domain.Models.Request.Authentication;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private static IAuthenticationBusiness _authenticationBusiness;

    public AuthenticationController(IAuthenticationBusiness authenticationBusiness)
    {
        _authenticationBusiness = authenticationBusiness;
    }

    [HttpPost]
    public ActionResult Login([FromHeader] string login, [FromHeader] string password)
    {
        var token = _authenticationBusiness.ConnectUser(new ConnectUserRequest()
        {
            Login = login,
            Password = password
        }); ;
        return token != null ? Ok(token) : BadRequest("Invalid credentials");
    }
}