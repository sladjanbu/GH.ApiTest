using GH.Application.Contracts.Infrastructure.Models;

namespace GH.Application.Contracts.Infrastructure
{
    public interface IGitHubService
    {
        Task<IList<PullRequest>> FetchPullRequests(string owner, string repoName);
        Task<IList<Commit>> FetchCommitsForPullRequest(string commitsUrl);
        Task<IList<Comment>> FetchCommentsForPullRequest(string commentsUrl);
    }
}
