using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Report
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Hours { get; set; } = 0.0;

        [Required]
        [Display(Name = "State")]
        public ReportState ReportState { get; set; }

        //Navigation properties
        public int? AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
    public enum ReportState
    {
        Draft,
        Submitted,
        Approved
    }
}
