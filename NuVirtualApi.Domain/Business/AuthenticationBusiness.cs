using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Config;
using NuVirtualApi.Domain.Tools;
using Microsoft.Extensions.Options;
using NuVirtualApi.Domain.Models.Request.Authentication;

namespace NuVirtualApi.Domain.Business
{
    public class AuthenticationBusiness : IAuthenticationBusiness
    {
        public IUserManager _userManager;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthenticationBusiness(IUserManager userManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public TokenModel? ConnectUser(ConnectUserRequest request)
        {
            var existingUser = _userManager.AuthenticateUser(request.Login, request.Password);
            if (existingUser != null)
            {
                return new TokenModel
                {
                    User = existingUser,
                    Token = TokenTool.GenerateJwt(existingUser, _jwtSettings.Value)
                };
            }
            return null;
        }
    }
}
