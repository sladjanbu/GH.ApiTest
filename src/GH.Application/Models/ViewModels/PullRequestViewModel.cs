using GH.Application.Contracts.Infrastructure.Models;

namespace GH.Application.Models.ViewModels
{
    public class PullRequestsViewModel
    {
        public List<PullRequestViewModel> Active { get; set; } = new List<PullRequestViewModel>();
        public List<PullRequestViewModel> Draft { get; set; } = new List<PullRequestViewModel>();
        public List<PullRequestViewModel> Stale { get; set; } = new List<PullRequestViewModel>();
    }

    public class PullRequestViewModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public List<CommitViewModel> Commits { get; set; }
    }
}
