using System.Text.Json.Serialization;

namespace Application.Dtos
{
    public class FacebookAccessTokenResponseDto
    {
        [JsonPropertyName("access_token")]
        public string Access_Token { get; set; }

        [JsonPropertyName("token_type")]
        public string Token_Type { get; set; }
    }
}
