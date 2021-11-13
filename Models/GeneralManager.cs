using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Models
{
    public class GeneralManager : Employee
    {
        //Navigation properties
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
