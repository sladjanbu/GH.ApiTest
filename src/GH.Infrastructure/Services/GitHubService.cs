using GH.Application.Contracts.Infrastructure;
using GH.Application.Contracts.Infrastructure.Models;
using System.Net.Http.Json;
using System.Xml.Linq;

namespace GH.Infrastructure.Services
{
    internal class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.github.com/";

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("MyApp", "1.0"));
        }

        public async Task<IList<PullRequest>> FetchPullRequests(string owner, string repoName)
        {
            var url = $"{BaseUrl}repos/{owner}/{repoName}/pulls?state=open";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PullRequest>>();
        }

        public async Task<IList<Commit>> FetchCommitsForPullRequest(string commitsUrl)
        {
            var response = await _httpClient.GetAsync(commitsUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Commit>>();
        }

        public async Task<IList<Comment>> FetchCommentsForPullRequest(string commentsUrl)
        {
            var response = await _httpClient.GetAsync(commentsUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Comment>>();
        }
    }


}
