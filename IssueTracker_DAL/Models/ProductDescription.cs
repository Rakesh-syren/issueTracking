using System;
using System.Collections.Generic;

namespace IssueTracker_DAL.Models;

public partial class ProductDescription
{
    public int ProductDescriptionId { get; set; }

    public string Description { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; } = new List<ProductModelProductDescription>();
}
