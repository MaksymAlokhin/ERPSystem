using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class Mentor : Employee
    {
        //Navigation properties
        public ICollection<Employee> Employees { get; set; }
    }
}
