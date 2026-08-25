using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ERPSystem.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;
        private readonly IAuthorizationService _authorizationService;
        public string NameSort { get; set; }
        public string DepartmentHeadSort { get; set; }
        public string StateSort { get; set; }
        public string CompanySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Department> Department { get; set; }

        public IndexModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context, IConfiguration configuration,
            IAuthorizationService authorizationService)
        {
            _context = context;
            Configuration = configuration;
            _authorizationService = authorizationService;
        }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DepartmentHeadSort = sortOrder == "head" ? "head_desc" : "head";
            StateSort = sortOrder == "state" ? "state_desc" : "state";
            CompanySort = sortOrder == "company" ? "company_desc" : "company";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;
            IQueryable<Department> departmentsIQ = _context.Departments
                .Include(i => i.DepartmentHead).Include(i => i.Company).AsNoTracking();
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
                case "company":
                    departmentsIQ = departmentsIQ.OrderBy(s => s.Company.Name).ThenBy(s => s.Name);
                    break;
                case "company_desc":
                    departmentsIQ = departmentsIQ.OrderByDescending(s => s.Company.Name).ThenBy(s => s.Name);
                    break;
                default:
                    departmentsIQ = departmentsIQ.OrderBy(s => s.Name);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Department = await PaginatedList<Department>.CreateAsync(
                departmentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
        //Method to debug states
        public async Task<IActionResult> OnGetActivateAsync(string sortOrder,
            string currentFilter, int? pageIndex)
        {
            if (!(await _authorizationService.AuthorizeAsync(User, "AdminOnly")).Succeeded)
            {
                return Forbid();
            }

            foreach (var department in _context.Departments)
            {
                if (department.CompanyId != null)
                {
                    _context.Entry(department)
                        .Reference(p => p.Company)
                        .Load();
                    if (department.Company.CompanyState == CompanyState.Active)
                    {
                        _context.Entry(department)
                        .Reference(p => p.DepartmentHead)
                        .Load();
                        if (department.DepartmentHead != null)
                        {
                            if (department.DepartmentHead.EmployeeState == EmployeeState.Active)
                                department.DepartmentState = DepartmentState.Active;
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
    }
}
