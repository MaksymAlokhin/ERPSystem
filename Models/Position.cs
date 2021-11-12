using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Position
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Position")]
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
        public PositionState PositionState { get; set; }

        //Navigation properties
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
    public enum PositionState
    {
        Active,
        Inactive
    }
}
