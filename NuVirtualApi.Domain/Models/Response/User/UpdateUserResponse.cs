namespace NuVirtualApi.Domain.Models.Response.User
{
    public class UpdateUserResponse
    {
        public UserModel User { get; set; }
        public string Token { get; set; }
    }
}
