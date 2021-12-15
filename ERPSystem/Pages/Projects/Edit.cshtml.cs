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

namespace ERPSystem.Pages.Projects
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<EditModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedPositions { get; set; }
        public SelectList PositionsSelectList { get; set; }
        public List<SelectListItem> ProjectManagerList { get; set; }
        public int? ProjectManagerId;
        List<int> ProjectsWithModifiedState { get; set; }
        public EditModel(ERPSystem.Data.ApplicationDbContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Project Project { get; set; }

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

            Project = await _context.Projects
                .Include(p => p.Department)
                .Include(p => p.ProjectManager)
                .Include(p => p.Positions)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Project == null)
            {
                return NotFound();
            }

            ProjectManagerList = new List<SelectListItem>();
            foreach (Employee pm in _context.Employees
                    .Where(e => e.EmployeeRole == EmployeeRole.ProjectManager)
                    .OrderBy(e => e.LastName)
                    .ThenBy(e => e.FirstName))
            {
                ProjectManagerList.Add(new SelectListItem { Value = $"{pm.Id}", Text = $"{pm.FullName}" });
            }
            if (Project.ProjectManager != null)
                ProjectManagerId = Project.ProjectManager.Id;

            var PositionsQuery = _context.Positions.OrderBy(p => p.Name).AsNoTracking();
            PositionsSelectList = new SelectList(PositionsQuery, "Id", "Name"); //list, id, value

            SelectedPositions = new List<int>();
            foreach (var position in Project.Positions)
            {
                SelectedPositions.Add(position.Id);
            }
            if (_context.Departments.Any())
                ViewData["DepartmentId"] = new SelectList(_context.Departments.OrderBy(d => d.Name), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, int? ProjectManagerId,
            string sortOrder, string currentFilter, int? pageIndex, int[] SelectedPositions)
        {
            ProjectsWithModifiedState = new List<int>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Project ProjectToUpdate = await _context.Projects
                .Include(p => p.Department)
                .Include(p => p.ProjectManager)
                .Include(p => p.Positions)
                .FirstOrDefaultAsync(m => m.Id == id);

            ProjectState InitialProjectState = ProjectToUpdate.ProjectState;

            UpdatePositions(SelectedPositions, ProjectToUpdate);

            //Refactored because TryUpdateModelAsync fails while unit testing:
            //https://github.com/dotnet/AspNetCore.Docs/issues/14009
            //if (await TryUpdateModelAsync<Project>(
            //    ProjectToUpdate,
            //    "Project",
            //    p => p.Name, p => p.ProjectState, p => p.StartDate, p => p.EndDate, p => p.DepartmentId))

            ProjectToUpdate.Name = Project.Name;
            ProjectToUpdate.ProjectState = Project.ProjectState;
            ProjectToUpdate.StartDate = Project.StartDate;
            ProjectToUpdate.EndDate = Project.EndDate;
            ProjectToUpdate.DepartmentId = Project.DepartmentId;

            Employee pm = await _context.Employees
                .Where(e => e.EmployeeRole == EmployeeRole.ProjectManager && e.Id == ProjectManagerId)
                .FirstOrDefaultAsync();
            if (pm != null)
            {
                if (pm.ProjectId != null)
                {
                    if (pm.ProjectId != id)
                    {
                        var oldProject = await _context.Projects.FindAsync(pm.ProjectId);
                        if (oldProject.ProjectState != ProjectState.Inactive)
                        {
                            oldProject.ProjectState = ProjectState.Inactive;
                            ProjectsWithModifiedState.Add(oldProject.Id);
                        }
                    }
                }
                pm.ProjectId = id;
            }
            else
            {
                if (ProjectToUpdate.ProjectManager != null)
                {
                    Employee formerPm = await _context.Employees
                            .Where(e => e.EmployeeRole == EmployeeRole.ProjectManager
                                && e.Id == ProjectToUpdate.ProjectManager.Id)
                            .FirstOrDefaultAsync();
                    formerPm.ProjectId = null;
                }
            }

            if (ProjectToUpdate.ProjectState != InitialProjectState)
                ProjectsWithModifiedState.Add(ProjectToUpdate.Id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Utility utility = new Utility(_context);
            utility.UpdateProjectDependants(ProjectsWithModifiedState);
            utility.UpdateWhenParentIsNull();

            _logger.LogInformation("Project modified: {1}", ProjectToUpdate.Name);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
        private void UpdatePositions(int[] SelectedPositions, Project Project)
        {
            {
                if (SelectedPositions == null || SelectedPositions.Length == 0)
                {
                    Project.Positions = new List<Position>();
                    return;
                }

                var SelectedPositionsHS = new HashSet<int>(SelectedPositions);
                var ProjectPositionsHS = new HashSet<int>
                    (Project.Positions.Select(p => p.Id));
                foreach (var position in _context.Positions)
                {
                    //If items are selected
                    if (SelectedPositionsHS.Contains(position.Id))
                    {
                        //If item not present
                        if (!ProjectPositionsHS.Contains(position.Id))
                        {
                            Project.Positions.Add(position);
                            if (!ProjectsWithModifiedState.Contains(Project.Id))
                                ProjectsWithModifiedState.Add(Project.Id);
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (ProjectPositionsHS.Contains(position.Id))
                        {
                            var toRemove = Project.Positions.Single(s => s.Id == position.Id);
                            Project.Positions.Remove(toRemove);
                        }
                    }
                }
            }
        }
        public async Task<JsonResult> OnGetDepartmentAsync(string departmentId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetDepartmentStateAsync(departmentId);
        }
        public async Task<JsonResult> OnGetEmployeeAsync(string employeeId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetEmployeeStateAsync(employeeId);
        }
    }
}
