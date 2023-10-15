
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GH.Application.Contracts.Infrastructure.Models
{
    public class PullRequest
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        [JsonPropertyName("commits_url")]
        public string CommitsUrl { get; set; }
        public bool Draft { get; set; }

    }
}
