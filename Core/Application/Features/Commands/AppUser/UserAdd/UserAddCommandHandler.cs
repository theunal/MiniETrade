using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AppUser.UserAdd
{
    public class UserAddCommandHandler : IRequestHandler<UserAddCommandRequest, UserAddCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> userManager;

        public UserAddCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserAddCommandResponse> Handle(UserAddCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.Name,
                UserName = request.UserName,
                Email = request.Email
            };
            var result = await userManager.CreateAsync(user, request.Password);

            return result.Succeeded ?
                new() { Success = true, Message = "Kullanıcı Oluşturuldu." } :
                new() { Success = false, Message = "Kullanıcı oluşturulurken hata oldu." };
        }
    }
}
