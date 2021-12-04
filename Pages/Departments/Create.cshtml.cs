using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedProjects { get; set; }
        public SelectList ProjectsSelectList { get; set; }
        public SelectList CompaniesSelectList { get; set; }
        public List<SelectListItem> DepartmentHeadList { get; set; }
        public int? DepartmentHeadId;

        public CreateModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string sortOrder,
            string currentFilter, int? pageIndex)
        {

            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            DepartmentHeadList = new List<SelectListItem>();
            foreach (Employee dh in _context.Employees
                .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead)
                .OrderBy(dh => dh.LastName).ThenBy(dh => dh.FirstName))
            {
                DepartmentHeadList.Add(new SelectListItem { Value = $"{dh.Id}", Text = $"{dh.FullName}" });
            }

            var ProjectsQuery = _context.Projects.OrderBy(p => p.Name).AsNoTracking();
            ProjectsSelectList = new SelectList(ProjectsQuery, "Id", "Name"); //list, id, value

            SelectedProjects = new List<int>();

            var CompaniesQuery = _context.Companies.OrderBy(c => c.Name).AsNoTracking();
            CompaniesSelectList = new SelectList(CompaniesQuery, "Id", "Name"); //list, id, value

            Department = new Department();
            Department.DepartmentState = DepartmentState.Inactive;

            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? DepartmentHeadId, int[] SelectedProjects)
        {
            List<int> DepartmentsWithModifiedState = new List<int>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NewDepartment = new Department();

            if (await TryUpdateModelAsync<Department>(NewDepartment, "Department",
                    d => d.Name, d => d.DepartmentState, d => d.CompanyId))
            {
                if (DepartmentHeadId != null)
                {
                    Employee dh = await _context.Employees
                        .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead 
                        && e.Id == DepartmentHeadId)
                        .FirstOrDefaultAsync();
                    if (dh.DepartmentId != null)
                    {
                        var oldDepartment = await _context.Departments.FindAsync(dh.DepartmentId);
                        if (oldDepartment.DepartmentState != DepartmentState.Inactive)
                        {
                            oldDepartment.DepartmentState = DepartmentState.Inactive;
                            DepartmentsWithModifiedState.Add(oldDepartment.Id);
                        }
                    }
                    dh.DepartmentId = null;
                    NewDepartment.DepartmentHead = dh;
                }

                if (SelectedProjects.Length > 0)
                {
                    NewDepartment.Projects = new List<Project>();
                }
                foreach (var project in SelectedProjects)
                {
                    var foundProject = await _context.Projects.FindAsync(project);
                    if (foundProject != null)
                        NewDepartment.Projects.Add(foundProject);
                }

                _context.Departments.Add(NewDepartment);
                await _context.SaveChangesAsync();

                DepartmentsWithModifiedState.Add(NewDepartment.Id);
                Utility utility = new Utility(_context);
                utility.UpdateDepartmentDependants(DepartmentsWithModifiedState);

                return RedirectToPage("./Index", new
                {
                    pageIndex = $"{pageIndex}",
                    sortOrder = $"{sortOrder}",
                    currentFilter = $"{currentFilter}"
                });
            }
            return Page();
        }
        public async Task<JsonResult> OnGetCompanyAsync(string companyId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetCompanyStateAsync(companyId);
        }
        public async Task<JsonResult> OnGetEmployeeAsync(string employeeId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetEmployeeStateAsync(employeeId);
        }
    }
}
