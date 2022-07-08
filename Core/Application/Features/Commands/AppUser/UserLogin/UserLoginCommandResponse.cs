using Application.Utilities.Security.JWT;

namespace Application.Features.Commands.AppUser.UserLogin
{
    public class UserLoginCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class UserLoginSuccessCommandResponse : UserLoginCommandResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}
