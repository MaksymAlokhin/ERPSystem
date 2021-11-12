using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department")]
        [StringLength(50, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "State")]
        public DepartmentState DepartmentState { get; set; }

        //Navigation Properties
        [Display(Name = "Department Head")]
        public DepartmentHead DepartmentHead { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
    public enum DepartmentState
    {
        Draft,
        Active,
        Inactive
    }
}
