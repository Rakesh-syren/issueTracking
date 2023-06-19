using System;
using System.Collections.Generic;

namespace IssueTracker_DAL.Models;

public partial class Issue
{
    public int IssueId { get; set; }

    public int ProjectId { get; set; }

    public string IssueName { get; set; } = null!;

    public string IssueType { get; set; } = null!;

    public string ModuleName { get; set; } = null!;

    public string? Description { get; set; }

    public string Summary { get; set; } = null!;

    public decimal Identfiedemp { get; set; }

    public DateTime Dateidentified { get; set; }

    public string Priority { get; set; } = null!;

    public DateTime Targetdate { get; set; }

    public DateTime? Actualdate { get; set; }

    public decimal AssignTo { get; set; }

    public string? Progressreport { get; set; }

    public string? Ressummary { get; set; }

    public string? StepsToReproduce { get; set; }

    public string TestingType { get; set; } = null!;

    public int IterationNumber { get; set; }

    public string Status { get; set; } = null!;

    public int? LinkToPast { get; set; }

    public string? Images { get; set; }

    public virtual Employee AssignToNavigation { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Employee IdentfiedempNavigation { get; set; } = null!;

    public virtual Iteration? LinkToPastNavigation { get; set; }

    public virtual Project Project { get; set; } = null!;
}
