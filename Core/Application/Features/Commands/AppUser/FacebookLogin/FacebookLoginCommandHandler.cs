using Application.Dtos;
using Application.Utilities.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> userManager;
        private readonly ITokenHandler tokenHandler;
        private readonly HttpClient httpClient;
        public FacebookLoginCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler, IHttpClientFactory httpClientFactory)
        {
            this.userManager = userManager;
            this.tokenHandler = tokenHandler;
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var accessToken = await httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id=769221657554381&client_secret=7f31652ec381e780d37dee7f38f76278&grant_type=client_credentials");

            var response = JsonSerializer.Deserialize<FacebookAccessTokenResponseDto>(accessToken);

            var tokenValidate = await httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={request.AuthToken}&access_token={response.Access_Token}");

            var tokenValidateResponse = JsonSerializer.Deserialize<FacebookAccessTokenValidation>(tokenValidate);

            var info = new UserLoginInfo(request.Provider, tokenValidateResponse.Data.User_Id, request.Provider);
            var userToCheck = await userManager.FindByLoginAsync(request.Provider, info.ProviderKey);
            var userToCheckFromUserTable = await userManager.FindByEmailAsync(request.Email);

            if (tokenValidateResponse.Data.Is_Valid && userToCheck is null && userToCheckFromUserTable is null)
            {
                var user = new Domain.Entities.Identity.AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = request.Email,
                    UserName = request.Email,
                    NameSurname = request.Name
                };
                await userManager.CreateAsync(user);
                await userManager.AddLoginAsync(user, info);
            }

            return new() { Token = tokenHandler.CreateToken() };
        }
    }
}
