using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Utilities.Security.JWT
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration configuration;
        DateTime accessTokenExpiration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public AccessToken CreateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOptions:SecurityKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            accessTokenExpiration = DateTime.Now.AddMinutes(Convert.ToDouble(configuration["TokenOptions:AccessTokenExpiration"]));


            var jwt = new JwtSecurityToken(
                issuer: configuration["TokenOptions:Issuer"],
                audience: configuration["TokenOptions:Audience"],
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
                );

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = accessTokenExpiration
            };
        }
    }
}
