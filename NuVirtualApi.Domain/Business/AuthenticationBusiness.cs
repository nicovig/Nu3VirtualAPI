using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models;
using NuVirtualApi.Domain.Models.Config;
using NuVirtualApi.Domain.Models.Request;
using NuVirtualApi.Domain.Tools;
using Microsoft.Extensions.Options;

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

        public TokenModel ConnectUser(ConnectUserRequest request)
        {
            TokenModel result = null;
            var existingTineos = _userManager.AuthenticateUser(request.Mail, request.Password);
            if (existingTineos != null)
            {
                result = new TokenModel
                {
                    Mail = existingTineos.Mail,
                    Token = TokenTool.GenerateJwt(existingTineos, _jwtSettings.Value)
                };
            }

            return result;
        }
    }
}
