using System;
using System.Collections.Generic;

namespace IssueTracker_DAL.Models;

public partial class Iteration
{
    public int Iterationid { get; set; }

    public int? Projectid { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();

    public virtual Project? Project { get; set; }
}
