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

namespace ERPSystem.Pages.Departments
{
    public class EditModel : PageModel
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
        public int? FormerDepartmentHeadId;

        public EditModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
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
            {
                DepartmentHeadId = FormerDepartmentHeadId = Department.DepartmentHead.Id;
            }

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
        public async Task<IActionResult> OnPostAsync(int? id, int? DepartmentHeadId, int? FormerDepartmentHeadId, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedProjects)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var DepartmentToUpdate = await _context.Departments
                .Include(d => d.DepartmentHead)
                .Include(p => p.Projects)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (await TryUpdateModelAsync<Department>(
                DepartmentToUpdate,
                "Department",
                d => d.Name, d => d.DepartmentState, d => d.CompanyId))
            {
                Employee dh = await _context.Employees
                        .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead && e.Id == DepartmentHeadId)
                        .FirstOrDefaultAsync();

                if (dh != null)
                {
                    if (dh.Id != FormerDepartmentHeadId && dh.DepartmentId != null)
                    {
                        var oldDepartment = await _context.Departments.FindAsync(dh.DepartmentId);
                        oldDepartment.DepartmentState = DepartmentState.Inactive;
                    }
                    dh.DepartmentId = Department.Id;
                }
                else
                {
                    if (FormerDepartmentHeadId != null)
                    {
                        Employee formerDh = await _context.Employees
                                .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead && e.Id == FormerDepartmentHeadId)
                                .FirstOrDefaultAsync();
                        formerDh.DepartmentId = null;
                    }
                    DepartmentToUpdate.DepartmentState = DepartmentState.Inactive;
                }

                UpdateProjects(SelectedProjects, DepartmentToUpdate);

                if (DepartmentToUpdate.DepartmentState == DepartmentState.Active)
                {
                    foreach (var project in DepartmentToUpdate.Projects)
                    {
                        _context.Entry(project)
                            .Reference(p => p.ProjectManager)
                            .Load();
                        if (project.ProjectManager != null)
                        {
                            if (project.ProjectManager.EmployeeState == EmployeeState.Active)
                            {
                                project.ProjectState = ProjectState.Active;
                            }
                            else
                                project.ProjectState = ProjectState.Inactive;
                        }
                        else
                            project.ProjectState = ProjectState.Inactive;
                    }
                }
                else
                {
                    foreach (var project in DepartmentToUpdate.Projects)
                        project.ProjectState = ProjectState.Inactive;
                }
            }

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
            utility.UpdatePositionsState();
            utility.UpdateAssignmentsState();

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
                if (SelectedProjects.Length == 0)
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
                            toRemove.ProjectState = ProjectState.Inactive;
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
