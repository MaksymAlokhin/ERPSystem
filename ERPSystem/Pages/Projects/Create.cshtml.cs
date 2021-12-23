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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Projects
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<CreateModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedPositions { get; set; }
        public SelectList PositionsSelectList { get; set; }
        public List<SelectListItem> ProjectManagerList { get; set; }
        public int? ProjectManagerId;

        public CreateModel(ERPSystem.Data.ApplicationDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet(string sortOrder,
            string currentFilter, int? pageIndex)
        {
            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            ProjectManagerList = new List<SelectListItem>();
            foreach (Employee pm in _context.Employees
                    .Where(e => e.EmployeeRole == EmployeeRole.ProjectManager)
                    .OrderBy(e => e.LastName)
                    .ThenBy(e => e.FirstName))
            {
                ProjectManagerList.Add(new SelectListItem { Value = $"{pm.Id}", Text = $"{pm.FullName}" });
            }

            var PositionsQuery = _context.Positions.OrderBy(p => p.Name).AsNoTracking();
            PositionsSelectList = new SelectList(PositionsQuery, "Id", "Name"); //list, id, value

            SelectedPositions = new List<int>();
            ViewData["DepartmentId"] = new SelectList(_context.Departments.OrderBy(d => d.Name), "Id", "Name");

            Project = new Project();
            Project.ProjectState = ProjectState.Inactive;
            Project.StartDate = Utility.GetRandomDate(DateTime.Now.AddYears(-2), DateTime.Now);
            Project.EndDate = Utility.GetRandomDate(DateTime.Now, DateTime.Now.AddYears(2));
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? ProjectManagerId, int[] SelectedPositions)
        {
            List<int> ProjectsWithModifiedState = new List<int>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NewProject = new Project();

            //if (await TryUpdateModelAsync<Project>(
            //    NewProject,
            //    "Project",
            //    p => p.Name, p => p.ProjectState, p => p.StartDate, p => p.EndDate, p => p.DepartmentId))
            //return Page();

            if (Project.StartDate > Project.EndDate)
            {
                var temp = Project.StartDate;
                Project.StartDate = Project.EndDate;
                Project.EndDate = temp;
            }

            NewProject.Name = Project.Name;
            NewProject.ProjectState = Project.ProjectState;
            NewProject.StartDate = Project.StartDate;
            NewProject.EndDate = Project.EndDate;
            NewProject.DepartmentId = Project.DepartmentId;

            if (ProjectManagerId != null)
            {
                Employee pm = await _context.Employees
                    .Where(e => e.EmployeeRole == EmployeeRole.ProjectManager && e.Id == ProjectManagerId)
                    .FirstOrDefaultAsync();
                if (pm.ProjectId != null)
                {
                    var oldProject = await _context.Projects.FindAsync(pm.ProjectId);
                    if (oldProject.ProjectState != ProjectState.Inactive)
                    {
                        oldProject.ProjectState = ProjectState.Inactive;
                        ProjectsWithModifiedState.Add(oldProject.Id);
                    }
                }
                pm.ProjectId = null;
                NewProject.ProjectManager = pm;
            }

            if (SelectedPositions != null)
            {
                if (SelectedPositions.Length > 0)
                {
                    NewProject.Positions = new List<Position>();
                }
                foreach (var position in SelectedPositions)
                {
                    var foundPosition = await _context.Positions.FindAsync(position);
                    if (foundPosition != null)
                    {
                        NewProject.Positions.Add(foundPosition);
                    }
                }
            }

            _context.Projects.Add(NewProject);
            await _context.SaveChangesAsync();

            ProjectsWithModifiedState.Add(NewProject.Id);

            Utility utility = new Utility(_context);
            utility.UpdateProjectDependants(ProjectsWithModifiedState);

            _logger.LogInformation("Project created: {1}", NewProject.Name);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
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
