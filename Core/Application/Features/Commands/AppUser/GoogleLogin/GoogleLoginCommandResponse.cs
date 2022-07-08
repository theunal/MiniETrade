using Application.Utilities.Security.JWT;

namespace Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandResponse
    {
        public AccessToken Token { get; set; }
    }
}
