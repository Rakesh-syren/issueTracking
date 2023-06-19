using System;
using System.Collections.Generic;

namespace IssueTracker_DAL.Models;

public partial class Project
{
    public int Projectid { get; set; }

    public string Projectname { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();

    public virtual ICollection<Iteration> Iterations { get; set; } = new List<Iteration>();
}
