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

namespace ERPSystem.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;
        public string NameSort { get; set; }
        public string StartDateSort { get; set; }
        public string EndDateSort { get; set; }
        public string DepartmentSort { get; set; }
        public string ProjectManagerSort { get; set; }
        public string PositionsSort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Project> Project { get; set; }

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
            StartDateSort = sortOrder == "startDate" ? "startDate_desc" : "startDate";
            EndDateSort = sortOrder == "endDate" ? "endDate_desc" : "endDate";
            DepartmentSort = sortOrder == "department" ? "department_desc" : "department";
            ProjectManagerSort = sortOrder == "projectManager" ? "projectManager_desc" : "projectManager";
            PositionsSort = sortOrder == "positions" ? "positions_desc" : "positions";
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

            IQueryable<Project> projectsIQ = _context.Projects
                .Include(p => p.Department)
                .Include(p => p.ProjectManager)
                .Include(p => p.Positions)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                projectsIQ = projectsIQ.Where(s => s.Name.Contains(searchString)
                                       || s.Department.Name.Contains(searchString)
                                       || s.ProjectManager.LastName.Contains(searchString)
                                       || s.ProjectManager.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    projectsIQ = projectsIQ.OrderByDescending(s => s.Name);
                    break;
                case "startDate":
                    projectsIQ = projectsIQ.OrderBy(s => s.StartDate).ThenBy(s => s.Name);
                    break;
                case "startDate_desc":
                    projectsIQ = projectsIQ.OrderByDescending(s => s.StartDate).ThenBy(s => s.Name);
                    break;
                case "endDate":
                    projectsIQ = projectsIQ.OrderBy(s => s.EndDate).ThenBy(s => s.Name);
                    break;
                case "endDate_desc":
                    projectsIQ = projectsIQ.OrderByDescending(s => s.EndDate).ThenBy(s => s.Name);
                    break;
                case "department":
                    projectsIQ = projectsIQ.OrderBy(s => s.Department.Name).ThenBy(s => s.Name);
                    break;
                case "department_desc":
                    projectsIQ = projectsIQ.OrderByDescending(s => s.Department.Name).ThenBy(s => s.Name);
                    break;
                case "projectManager":
                    projectsIQ = projectsIQ.OrderBy(s => s.ProjectManager.LastName).ThenBy(s => s.Name);
                    break;
                case "projectManager_desc":
                    projectsIQ = projectsIQ.OrderByDescending(s => s.ProjectManager.LastName).ThenBy(s => s.Name);
                    break;
                case "positions":
                    projectsIQ = projectsIQ.OrderBy(s => s.Positions.Count()).ThenBy(s => s.Name);
                    break;
                case "positions_desc":
                    projectsIQ = projectsIQ.OrderByDescending(s => s.Positions.Count()).ThenBy(s => s.Name);
                    break;
                case "state":
                    projectsIQ = projectsIQ.OrderBy(s => s.ProjectState).ThenBy(s => s.Name);
                    break;
                case "state_desc":
                    projectsIQ = projectsIQ.OrderByDescending(s => s.ProjectState).ThenBy(s => s.Name);
                    break;
                default:
                    projectsIQ = projectsIQ.OrderBy(s => s.Name);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Project = await PaginatedList<Project>.CreateAsync(
                projectsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
        public async Task<IActionResult> OnGetActivateAsync(string sortOrder,
            string currentFilter, int? pageIndex)
        {
            foreach (var project in _context.Projects)
            {
                if (project.DepartmentId != null)
                {
                    _context.Entry(project)
                        .Reference(p => p.Department)
                        .Load();
                    if (project.Department.DepartmentState == DepartmentState.Active)
                    {
                        _context.Entry(project)
                        .Reference(p => p.ProjectManager)
                        .Load();
                        if (project.ProjectManager != null)
                        {
                            if (project.ProjectManager.EmployeeState == EmployeeState.Active)
                                project.ProjectState = ProjectState.Active;
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
