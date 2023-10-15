using System.Text.Json.Serialization;

namespace GH.Application.Contracts.Infrastructure.Models
{
    public class User
    {
        public string Login { get; set; }
        [JsonPropertyName("avatar_url")]
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
    }
}
