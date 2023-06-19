using System;
using System.Collections.Generic;

namespace IssueTracker_DAL.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string? Comment1 { get; set; }

    public int? IssueId { get; set; }

    public decimal? EmpId { get; set; }

    public DateTime? CommentedOn { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual Issue? Issue { get; set; }
}
