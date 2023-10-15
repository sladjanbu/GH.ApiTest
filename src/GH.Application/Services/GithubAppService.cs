using GH.Application.Contracts.Infrastructure;
using GH.Application.Contracts;
using GH.Application.Models.ViewModels;

namespace GH.Application.Services
{
    public class GitHubAppService : IGitHubAppService
    {
        private readonly IGitHubService _gitHubService;

        public GitHubAppService(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<PullRequestsViewModel> GetPullRequestsAndCommits(string owner, string repoName, string label, string keywords)
        {
            //There are no parameters on github documention for label and keyword
            //Keywords to filter what? I have put initialy title
            //Labels also there is response model label but to what is logic behind this input? No explanation in document

            var rawPullRequests = await _gitHubService.FetchPullRequests(owner, repoName);

            var result = new PullRequestsViewModel();

            foreach (var pr in rawPullRequests)
            {
                if (!string.IsNullOrEmpty(keywords) && !pr.Title.Contains(keywords, StringComparison.OrdinalIgnoreCase))
                    continue;

                var rawComments = await _gitHubService.FetchCommentsForPullRequest(pr.CommentsUrl);
              
                var rawCommits = await _gitHubService.FetchCommitsForPullRequest(pr.CommitsUrl);

                var commits = rawCommits.Select(c => new CommitViewModel
                {
                    Hash = c.Sha,
                    AuthorName = c.GithubCommit.Author.Name,
                    AuthorEmail = c.GithubCommit.Author.Email,
                    AvatarUrl = c.Author?.AvatarUrl,
                    CommitDate = c.GithubCommit.Author.Date,
                    Message = c.GithubCommit.Message
                }).ToList();

                var prViewModel = new PullRequestViewModel
                {
                    Url = pr.Url,
                    Title = pr.Title,
                    Body = pr.Body,
                    Comments = rawComments.Count,
                    CreatedAt = pr.CreatedAt,
                    User = pr.User,
                    Commits = commits
                };

                if (pr.Draft)
                {
                    result.Draft.Add(prViewModel);
                }
                else if ((DateTime.Now - pr.CreatedAt).TotalDays > 30)
                {
                    result.Stale.Add(prViewModel);
                }
                else
                {
                    result.Active.Add(prViewModel);
                }
            }

            return result;
        }


    }

}
