using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Authorization
{
    public static class ApplicationClaimTypes
    {
        public static List<String> AppClaimTypes = new List<String>() {
            "Admin", "Employee", "General Manager", "Department Head", "Project Manager"
        };
    }
}
