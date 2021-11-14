using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z-. ]*$")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z-. ]*$")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "State")]
        public EmployeeState EmployeeState { get; set; }
        
        //Navigation properties
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
    public enum EmployeeState
    {
        Active,
        Inactive
    }
}
