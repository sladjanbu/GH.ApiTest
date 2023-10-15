using System.Text.Json.Serialization;

namespace GH.Application.Contracts.Infrastructure.Models
{
    public class Comment
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}
