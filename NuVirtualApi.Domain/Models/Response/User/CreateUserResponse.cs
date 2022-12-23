namespace NuVirtualApi.Domain.Models.Response.User
{
    public class CreateUserResponse
    {
        public UserModel User { get; set; }
        public string Token { get; set; }
    }
}
