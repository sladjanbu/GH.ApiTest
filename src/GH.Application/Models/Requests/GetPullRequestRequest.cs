using System.ComponentModel.DataAnnotations;


namespace GH.Application.Models.Requests
{
    public class GetPullRequestRequest
    {
        [Required]
        public string Owner { get; set; }

        [Required]
        public string RepoName { get; set; }

        //[Required]
        public string? Label { get; set; }

        //[Required]
        public string? Keywords { get; set; }
    }
}
