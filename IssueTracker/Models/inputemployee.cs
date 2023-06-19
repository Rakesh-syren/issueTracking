using IssueTracker_DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models
{
    public class inputemployee
    {
        [Required]
        public decimal EmpId { get; set; }

        [Required]
        public string EmpName { get; set; } = null!;

        public int Projectid { get; set; }

  
    }
}
