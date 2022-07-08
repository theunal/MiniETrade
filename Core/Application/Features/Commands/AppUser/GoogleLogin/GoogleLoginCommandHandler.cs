using Application.Utilities.Security.JWT;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly IMediator mediator;
        private readonly UserManager<Domain.Entities.Identity.AppUser> userManager;
        private readonly ITokenHandler tokenHandler;
        public GoogleLoginCommandHandler(IMediator mediator, UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler)
        {
            this.mediator = mediator;
            this.userManager = userManager;
            this.tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "1082016734680-37eb7ge1t78g9cfh43dnr6ot41fa8s4s.apps.googleusercontent.com" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
            var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider);

            var userToCheck = await userManager.FindByLoginAsync(request.Provider, info.ProviderKey);
            var userToCheckFromUserTable = await userManager.FindByEmailAsync(request.Email);

            if (userToCheck is null && userToCheckFromUserTable is null)
            {
                var user = new Domain.Entities.Identity.AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = payload.Email,
                    UserName = payload.Email,
                    NameSurname = payload.Name
                };
                await userManager.CreateAsync(user);
                await userManager.AddLoginAsync(user, info);
            }

            return new() { Token = tokenHandler.CreateToken() };
        }
    }
}
