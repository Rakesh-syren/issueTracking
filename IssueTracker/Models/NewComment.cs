namespace IssueTracker.Models
{
    public class NewComment
    {
        public int CommentId { get; set; }

        public string? Comment1 { get; set; }

        public int? IssueId { get; set; }

        public decimal? EmpId { get; set; }

        public DateTime? CommentedOn { get; set; }
    }
}
