using GH.Application.Contracts.Infrastructure.Models;
using GH.Application.Models.ViewModels;

namespace GH.Application.Contracts
{
    public interface IGitHubAppService
    {
        Task<PullRequestsViewModel> GetPullRequestsAndCommits(string owner, string repoName, string label, string keywords);
    }
}
