using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Branch
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Branch")]
        [StringLength(50, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "State")]
        public BranchState BranchState { get; set; }
        
        //Navigation properties
        public ICollection<Employee> Employees { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
    public enum BranchState
    {
        Active,
        Inactive
    }
}
