using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Departments
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<EditModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedProjects { get; set; }
        public SelectList ProjectsSelectList { get; set; }
        public SelectList CompaniesSelectList { get; set; }
        List<int> DepartmentsWithModifiedState { get; set; }
        public List<SelectListItem> DepartmentHeadList { get; set; }
        public int? DepartmentHeadId;

        public EditModel(ERPSystem.Data.ApplicationDbContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments
                .Include(d => d.DepartmentHead)
                .Include(p => p.Projects)
                .Include(c => c.Company)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Department == null)
            {
                return NotFound();
            }

            DepartmentHeadList = new List<SelectListItem>();
            foreach (Employee dh in _context.Employees
                    .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead)
                    .OrderBy(dh => dh.LastName)
                    .ThenBy(dh => dh.FirstName))
            {
                DepartmentHeadList.Add(new SelectListItem { Value = $"{dh.Id}", Text = $"{dh.FullName}" });
            }
            if (Department.DepartmentHead != null)
                DepartmentHeadId = Department.DepartmentHead.Id;

            var ProjectsQuery = _context.Projects.OrderBy(p => p.Name).AsNoTracking();
            ProjectsSelectList = new SelectList(ProjectsQuery, "Id", "Name"); //list, id, value

            SelectedProjects = new List<int>();
            foreach (var project in Department.Projects)
            {
                SelectedProjects.Add(project.Id);
            }

            var CompaniesQuery = _context.Companies.OrderBy(c => c.Name).AsNoTracking();
            CompaniesSelectList = new SelectList(CompaniesQuery, "Id", "Name"); //list, id, value

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, int? DepartmentHeadId, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedProjects)
        {
            DepartmentsWithModifiedState = new List<int>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var DepartmentToUpdate = await _context.Departments
                .Include(d => d.DepartmentHead)
                .Include(p => p.Projects)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);

            DepartmentState InitialDepartmentState = DepartmentToUpdate.DepartmentState;

            //Refactored because TryUpdateModelAsync fails while unit testing:
            //https://github.com/dotnet/AspNetCore.Docs/issues/14009
            //if (await TryUpdateModelAsync<Department>(DepartmentToUpdate, "Department",
            //    d => d.Name, d => d.DepartmentState, d => d.CompanyId))

            DepartmentToUpdate.Name = Department.Name;
            DepartmentToUpdate.DepartmentState = Department.DepartmentState;
            DepartmentToUpdate.CompanyId = Department.CompanyId;

            Employee dh = await _context.Employees
        .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead && e.Id == DepartmentHeadId)
        .FirstOrDefaultAsync();

            if (dh != null)
            {
                if (dh.DepartmentId != null)
                {
                    if (dh.DepartmentId != id)
                    {
                        var oldDepartment = await _context.Departments.FindAsync(dh.DepartmentId);
                        if (oldDepartment.DepartmentState != DepartmentState.Inactive)
                        {
                            oldDepartment.DepartmentState = DepartmentState.Inactive;
                            DepartmentsWithModifiedState.Add(oldDepartment.Id);
                        }
                    }
                }
                dh.DepartmentId = id;
            }
            else
            {
                if (DepartmentToUpdate.DepartmentHead != null)
                {
                    Employee formerDh = await _context.Employees
                            .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead
                                && e.Id == DepartmentToUpdate.DepartmentHead.Id)
                            .FirstOrDefaultAsync();
                    formerDh.DepartmentId = null;
                }
            }

            if (DepartmentToUpdate.DepartmentState != InitialDepartmentState)
                DepartmentsWithModifiedState.Add(DepartmentToUpdate.Id);

            UpdateProjects(SelectedProjects, DepartmentToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(Department.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Utility utility = new Utility(_context);
            utility.UpdateDepartmentDependants(DepartmentsWithModifiedState);
            utility.UpdateWhenParentIsNull();

            _logger.LogInformation("Department modified: {0}", DepartmentToUpdate.Name);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
        private void UpdateProjects(int[] SelectedProjects, Department Department)
        {
            {
                if (SelectedProjects == null || SelectedProjects.Length == 0)
                {
                    Department.Projects = new List<Project>();
                    return;
                }

                var SelectedProjectsHS = new HashSet<int>(SelectedProjects);
                var DepartmentProjectsHS = new HashSet<int>
                    (Department.Projects.Select(p => p.Id));
                foreach (var project in _context.Projects)
                {
                    //If items are selected
                    if (SelectedProjectsHS.Contains(project.Id))
                    {
                        //If item not present
                        if (!DepartmentProjectsHS.Contains(project.Id))
                        {
                            Department.Projects.Add(project);
                            if (!DepartmentsWithModifiedState.Contains(Department.Id))
                                DepartmentsWithModifiedState.Add(Department.Id);
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (DepartmentProjectsHS.Contains(project.Id))
                        {
                            var toRemove = Department.Projects.Single(s => s.Id == project.Id);
                            Department.Projects.Remove(toRemove);
                        }
                    }
                }
            }
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
