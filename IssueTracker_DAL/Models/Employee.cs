using System;
using System.Collections.Generic;

namespace IssueTracker_DAL.Models;

public partial class Employee
{
    public decimal EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public int Projectid { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Issue> IssueAssignToNavigations { get; set; } = new List<Issue>();

    public virtual ICollection<Issue> IssueIdentfiedempNavigations { get; set; } = new List<Issue>();

    public virtual Project Project { get; set; } = null!;
}
