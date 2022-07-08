using MediatR;

namespace Application.Features.Commands.AppUser.UserAdd
{
    public class UserAddCommandRequest : IRequest<UserAddCommandResponse>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
