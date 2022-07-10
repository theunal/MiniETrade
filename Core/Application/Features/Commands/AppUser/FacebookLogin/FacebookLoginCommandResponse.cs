using Application.Utilities.Security.JWT;

namespace Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandResponse
    {
        public AccessToken Token { get; set; }
    }
}
