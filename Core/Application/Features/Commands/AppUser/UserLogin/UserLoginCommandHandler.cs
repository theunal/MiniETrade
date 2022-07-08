using Application.Utilities.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AppUser.UserLogin
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> signInManager;
        private readonly ITokenHandler tokenHandler;
        public UserLoginCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenHandler = tokenHandler;
        }

        public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserNameOrEmail);
            user = user is null ? await userManager.FindByEmailAsync(request.UserNameOrEmail) : user;

            var result = user is not null ? await signInManager.CheckPasswordSignInAsync(user, request.Password, false) : null;

            return result is null ?
                new() { Success = false, Message = "Kullanıcı Bulunamadı." } :
                !result.Succeeded ?
                new() { Success = false, Message = "Giriş Hatası." } :
                new UserLoginSuccessCommandResponse() { Success = true, Message = "Giriş Başarılı.", AccessToken = tokenHandler.CreateToken() };
        }
    }
}
