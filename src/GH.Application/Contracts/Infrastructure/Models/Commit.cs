using System.Text.Json.Serialization;

namespace GH.Application.Contracts.Infrastructure.Models
{
    public class Commit
    {
        public string Sha { get; set; }
        [JsonPropertyName("commit")]
        public GithubCommit GithubCommit { get; set; }
        public User Author { get; set; }
    }
}
