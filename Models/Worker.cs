using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Worker : Employee
    {
        //Navigation properties
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Mentor> Mentors { get; set; }
    }
}
