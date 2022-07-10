using System.Text.Json.Serialization;

namespace Application.Dtos
{
    public class FacebookAccessTokenValidation
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("is_valid")]
        public bool Is_Valid { get; set; }
        [JsonPropertyName("user_id")]
        public string User_Id { get; set; }
    }
}