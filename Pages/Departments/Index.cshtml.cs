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

namespace ERPSystem.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;
        public string NameSort { get; set; }
        public string DepartmentHeadSort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Department> Department { get; set; }

        public IndexModel(ERPSystem.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DepartmentHeadSort = sortOrder == "head" ? "head_desc" : "head";
            StateSort = sortOrder == "state" ? "state_desc" : "state";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;
            IQueryable<Department> departmentsIQ = _context.Departments.Include(i => i.DepartmentHead);
            if (!String.IsNullOrEmpty(searchString))
            {
                departmentsIQ = departmentsIQ.Where(s => s.Name.Contains(searchString)
                                       || s.DepartmentHead.FirstName.Contains(searchString)
                                       || s.DepartmentHead.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    departmentsIQ = departmentsIQ.OrderByDescending(s => s.Name);
                    break;
                case "head":
                    departmentsIQ = departmentsIQ.OrderBy(s => s.DepartmentHead.LastName).ThenBy(s => s.DepartmentHead.FirstName);
                    break;
                case "head_desc":
                    departmentsIQ = departmentsIQ.OrderByDescending(s => s.DepartmentHead.LastName).ThenBy(s => s.DepartmentHead.FirstName);
                    break;
                case "state":
                    departmentsIQ = departmentsIQ.OrderBy(s => s.DepartmentState).ThenBy(s => s.Name);
                    break;
                case "state_desc":
                    departmentsIQ = departmentsIQ.OrderByDescending(s => s.DepartmentState).ThenBy(s => s.Name);
                    break;
                default:
                    departmentsIQ = departmentsIQ.OrderBy(s => s.Name);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Department = await PaginatedList<Department>.CreateAsync(
                departmentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
