using GH.Application.Contracts.Infrastructure.Models;
using GH.Application.Contracts.Infrastructure;
using GH.Application.Services;
using Moq;

namespace GH.GitHubAppServiceTests
{
    public class GitHubAppServiceTests
    {
        private Mock<IGitHubService> _mockGitHubService;
        private GitHubAppService _service;

        [SetUp]
        public void SetUp()
        {
            _mockGitHubService = new Mock<IGitHubService>();
            _service = new GitHubAppService(_mockGitHubService.Object);
        }

        [Test]
        public async Task GetPullRequestsAndCommits_ReturnsExpectedData()
        {
            // Arrange
            _mockGitHubService.Setup(s => s.FetchPullRequests(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new List<PullRequest>
                {
                    new PullRequest
                    {
                        Url = "someUrl",
                        Title = "someTitle",
                        Body = "someBody",
                        CommentsUrl = "commentsUrl",
                        CreatedAt = DateTime.Now.AddDays(-10),
                        User = new User { Login = "user1", AvatarUrl = "avatarUrl1" },
                        CommitsUrl = "commitsUrl",
                        Draft = false
                    }
                });

            _mockGitHubService.Setup(s => s.FetchCommentsForPullRequest(It.IsAny<string>()))
                .ReturnsAsync(new List<Comment>
                {
                    new Comment { Id = 1 },
                    new Comment { Id = 2 }
                });

            _mockGitHubService.Setup(s => s.FetchCommitsForPullRequest(It.IsAny<string>()))
                .ReturnsAsync(new List<Commit>
                {
                    new Commit
                    {
                        Sha = "sha1",
                        GithubCommit = new GithubCommit
                        {
                            Author = new Author
                            {
                                Name = "author1",
                                Email = "email1",
                                Date = DateTime.Now.AddDays(-10)
                            },
                            Message = "message1"
                        }
                    }
                });

            // Act
            var result = await _service.GetPullRequestsAndCommits("owner", "repoName", null, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Active.Count);
            Assert.AreEqual(0, result.Draft.Count);
            Assert.AreEqual(0, result.Stale.Count);

            var pullRequest = result.Active.First();
            Assert.AreEqual("someTitle", pullRequest.Title);
            Assert.AreEqual(2, pullRequest.Comments);
            Assert.AreEqual(1, pullRequest.Commits.Count);
        }

    }
}