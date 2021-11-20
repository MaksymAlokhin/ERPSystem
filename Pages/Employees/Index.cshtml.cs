using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.Extensions.Configuration;

namespace ERPSystem.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;
        public string NameSort { get; set; }
        public string RoleSort { get; set; }
        public string BranchSort { get; set; }
        public string StateSort { get; set; }
        public string AssignmentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public EmployeeRole Role { get; set; }
        public PaginatedList<Employee> Employee { get; set; }

        public IndexModel(ERPSystem.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public async Task OnGetAsync(EmployeeRole Role, string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            this.Role = Role;
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            RoleSort = sortOrder == "role" ? "role_desc" : "role";
            BranchSort = sortOrder == "branch" ? "branch_desc" : "branch";
            StateSort = sortOrder == "state" ? "state_desc" : "state";
            AssignmentSort = sortOrder == "assignment" ? "assignment_desc" : "assignment";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Employee> employeesIQ = _context.Employees
                .Include(e => e.Branch)
                .Include(e => e.Assignments)
                .Include(e => e.Mentors)
                .Where(e => e.EmployeeRole == Role)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                employeesIQ = employeesIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employeesIQ = employeesIQ.OrderByDescending(s => s.LastName).ThenBy(s => s.FirstName);
                    break;
                case "role":
                    employeesIQ = employeesIQ.OrderBy(s => s.EmployeeRole).ThenBy(s => s.LastName).ThenBy(s => s.FirstName);
                    break;
                case "role_desc":
                    employeesIQ = employeesIQ.OrderByDescending(s => s.EmployeeRole).ThenBy(s => s.LastName).ThenBy(s => s.FirstName);
                    break;
                case "branch":
                    employeesIQ = employeesIQ.OrderBy(s => s.Branch.Name).ThenBy(s => s.LastName).ThenBy(s => s.FirstName); ;
                    break;
                case "branch_desc":
                    employeesIQ = employeesIQ.OrderByDescending(s => s.Branch.Name).ThenBy(s => s.LastName).ThenBy(s => s.FirstName);
                    break;
                case "state":
                    employeesIQ = employeesIQ.OrderBy(s => s.EmployeeState).ThenBy(s => s.LastName).ThenBy(s => s.FirstName); ;
                    break;
                case "state_desc":
                    employeesIQ = employeesIQ.OrderByDescending(s => s.EmployeeState).ThenBy(s => s.LastName).ThenBy(s => s.FirstName);
                    break;
                case "assignment":
                    employeesIQ = employeesIQ.OrderBy(s => s.Assignments.Count()).ThenBy(s => s.LastName).ThenBy(s => s.FirstName);
                    break;
                case "assignment_desc":
                    employeesIQ = employeesIQ.OrderByDescending(s => s.Assignments.Count()).ThenBy(s => s.LastName).ThenBy(s => s.FirstName);
                    break;
                default:
                    employeesIQ = employeesIQ.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 7);
            Employee = await PaginatedList<Employee>.CreateAsync(
                employeesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
