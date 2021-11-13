using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Assignment")]
        [StringLength(50, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double FTE { get; set; }

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
        public AssignmentState AssignmentState { get; set; }

        //Navigation properties
        public Report Report { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
    public enum AssignmentState
    {
        Active,
        Inactive
    }
}
