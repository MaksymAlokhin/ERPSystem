using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "State")]
        public CompanyState CompanyState { get; set; }

        //Navigation Properties
        [Display(Name = "General Manager")]
        public Employee GeneralManager { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
    public enum CompanyState
    {
        Draft,
        Active,
        Inactive
    }
}
