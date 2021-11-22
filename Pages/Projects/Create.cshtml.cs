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

namespace ERPSystem.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedPositions { get; set; }
        public SelectList PositionsSelectList { get; set; }
        public List<SelectListItem> ProjectManagerList { get; set; }
        public int? ProjectManagerId;

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NewProject = new Project();

            if (SelectedPositions.Length > 0)
            {
                NewProject.Positions = new List<Position>();
                _context.Positions.Load();
            }

            foreach (var position in SelectedPositions)
            {
                var foundPosition = await _context.Positions.FindAsync(position);
                if (foundPosition != null)
                {
                    NewProject.Positions.Add(foundPosition);
                }
            }

            if (await TryUpdateModelAsync<Project>(
                NewProject,
                "Project",
                p => p.Name, p => p.ProjectState, p => p.StartDate, p => p.EndDate, p => p.DepartmentId))
            {
                if (ProjectManagerId != null)
                {
                    Employee pm = await _context.Employees
                        .Where(e => e.EmployeeRole == EmployeeRole.ProjectManager && e.Id == ProjectManagerId)
                        .FirstOrDefaultAsync();
                    if (pm.ProjectId != null)
                    {
                        var oldProject = await _context.Projects.FindAsync(pm.ProjectId);
                        oldProject.ProjectState = ProjectState.Inactive;
                    }
                    pm.ProjectId = null;
                    NewProject.ProjectManager = pm;
                }
                else
                {
                    NewProject.ProjectState = ProjectState.Inactive;
                }
                _context.Projects.Add(NewProject);
                await _context.SaveChangesAsync();
                await Utility.UpdateStateAsync(_context);
                return RedirectToPage("./Index", new
                {
                    pageIndex = $"{pageIndex}",
                    sortOrder = $"{sortOrder}",
                    currentFilter = $"{currentFilter}"
                });
            }
            return Page();
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
