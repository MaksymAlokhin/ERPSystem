using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class DepartmentHead : Employee
    {
        //Navigation properties
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Mentor> Mentors { get; set; }
    }
}
