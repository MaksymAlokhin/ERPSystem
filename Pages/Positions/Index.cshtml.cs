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

namespace ERPSystem.Pages.Positions
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;
        public string NameSort { get; set; }
        public string StartDateSort { get; set; }
        public string EndDateSort { get; set; }
        public string ProjectSort { get; set; }
        public string AssignmentsSort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Position> Position { get; set; }
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
            ProjectSort = sortOrder == "project" ? "project_desc" : "project";
            AssignmentsSort = sortOrder == "assignments" ? "assignments_desc" : "assignments";
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
            IQueryable<Position> positionsIQ = _context
                .Positions
                .Include(p => p.Project)
                .Include(p => p.Assignments)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                positionsIQ = positionsIQ.Where(s => s.Name.Contains(searchString)
                                       || s.Project.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    positionsIQ = positionsIQ.OrderByDescending(s => s.Name);
                    break;
                case "startDate":
                    positionsIQ = positionsIQ.OrderBy(s => s.StartDate).ThenBy(s => s.Name);
                    break;
                case "startDate_desc":
                    positionsIQ = positionsIQ.OrderByDescending(s => s.StartDate).ThenBy(s => s.Name);
                    break;
                case "endDate":
                    positionsIQ = positionsIQ.OrderBy(s => s.EndDate).ThenBy(s => s.Name);
                    break;
                case "endDate_desc":
                    positionsIQ = positionsIQ.OrderByDescending(s => s.EndDate).ThenBy(s => s.Name);
                    break;
                case "project":
                    positionsIQ = positionsIQ.OrderBy(s => s.Project.Name).ThenBy(s => s.Name);
                    break;
                case "project_desc":
                    positionsIQ = positionsIQ.OrderByDescending(s => s.Project.Name).ThenBy(s => s.Name);
                    break;
                case "assignments":
                    positionsIQ = positionsIQ.OrderBy(s => s.Assignments.Count()).ThenBy(s => s.Name);
                    break;
                case "assignments_desc":
                    positionsIQ = positionsIQ.OrderByDescending(s => s.Assignments.Count()).ThenBy(s => s.Name);
                    break;
                case "state":
                    positionsIQ = positionsIQ.OrderBy(s => s.PositionState).ThenBy(s => s.Name);
                    break;
                case "state_desc":
                    positionsIQ = positionsIQ.OrderByDescending(s => s.PositionState).ThenBy(s => s.Name);
                    break;
                default:
                    positionsIQ = positionsIQ.OrderBy(s => s.Name);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Position = await PaginatedList<Position>.CreateAsync(
                positionsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
        public async Task<IActionResult> OnGetActivateAsync(string sortOrder,
            string currentFilter, int? pageIndex)
        {
            foreach (var position in _context.Positions)
            {
                if (position.ProjectId != null)
                {
                    _context.Entry(position)
                        .Reference(p => p.Project)
                        .Load();
                    if (position.Project.ProjectState == ProjectState.Active)
                        position.PositionState = PositionState.Active;
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
