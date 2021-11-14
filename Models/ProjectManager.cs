using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class ProjectManager : Employee
    {
        //Navigation properties
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Mentor> Mentors { get; set; }
    }
}
