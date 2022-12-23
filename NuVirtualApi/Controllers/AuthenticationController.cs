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
    public ActionResult Login(ConnectUserRequest request)
    {
        if (ModelState.IsValid)
        {
            var token = _authenticationBusiness.ConnectUser(request);
            return token != null ? Ok(token) : BadRequest("Invalid credentials");
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
}