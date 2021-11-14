using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Display(Name = "Project")]
        [StringLength(50, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Name { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "State")]
        public ProjectState ProjectState { get; set; }

        //Navigation Properties
        [Display(Name = "Project Manager")]
        public ProjectManager ProjectManager { get; set; }
        public ICollection<Position> Positions { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
    public enum ProjectState
    {
        Draft,
        Active,
        Inactive
    }
}
