using GH.Application.Contracts;
using GH.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubAppService _gitHubAppService;

        public GitHubController(IGitHubAppService gitHubAppService)
        {
            _gitHubAppService = gitHubAppService;
        }

        [HttpGet("pull-requests")]
        public async Task<IActionResult> GetPullRequestsAndCommits([FromQuery]GetPullRequestRequest request)
        {
            var pullRequests = await _gitHubAppService.GetPullRequestsAndCommits(request.Owner, request.RepoName, request.Label, request.Keywords);
            return Ok(pullRequests);
        }
    }
}
