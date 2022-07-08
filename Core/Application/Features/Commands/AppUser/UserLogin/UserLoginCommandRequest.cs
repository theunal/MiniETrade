using MediatR;

namespace Application.Features.Commands.AppUser.UserLogin
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
