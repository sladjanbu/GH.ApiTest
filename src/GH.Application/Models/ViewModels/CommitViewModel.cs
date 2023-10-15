namespace GH.Application.Models.ViewModels
{
    public class CommitViewModel
    {
        public string Hash { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CommitDate { get; set; }
        public string Message { get; set; }
    }
}
