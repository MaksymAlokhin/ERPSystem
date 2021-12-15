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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Assignments
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration Configuration;
        public string NameSort { get; set; }
        public string FTESort { get; set; }
        public string StartDateSort { get; set; }
        public string EndDateSort { get; set; }
        public string PositionSort { get; set; }
        public string EmployeeSort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Assignment> Assignment { get; set; }

        public IndexModel(ERPSystem.Data.ApplicationDbContext context, IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _context = context;
            Configuration = configuration;
            _logger = logger;
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            FTESort = sortOrder == "fte" ? "fte_desc" : "fte";
            StartDateSort = sortOrder == "startDate" ? "startDate_desc" : "startDate";
            EndDateSort = sortOrder == "endDate" ? "endDate_desc" : "endDate";
            PositionSort = sortOrder == "position" ? "position_desc" : "position";
            EmployeeSort = sortOrder == "employee" ? "employee_desc" : "employee";
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
            IQueryable<Assignment> assignmentsIQ = _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Position);
            if (!String.IsNullOrEmpty(searchString))
            {
                assignmentsIQ = assignmentsIQ.Where(s => s.Name.Contains(searchString)
                                       || s.Position.Name.Contains(searchString)
                                       || s.Employee.LastName.Contains(searchString)
                                       || s.Employee.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    assignmentsIQ = assignmentsIQ.OrderByDescending(s => s.Name);
                    break;
                case "fte":
                    assignmentsIQ = assignmentsIQ.OrderBy(s => s.FTE).ThenBy(s => s.Name);
                    break;
                case "fte_desc":
                    assignmentsIQ = assignmentsIQ.OrderByDescending(s => s.FTE).ThenBy(s => s.Name);
                    break;
                case "startDate":
                    assignmentsIQ = assignmentsIQ.OrderBy(s => s.StartDate).ThenBy(s => s.Name);
                    break;
                case "startDate_desc":
                    assignmentsIQ = assignmentsIQ.OrderByDescending(s => s.StartDate).ThenBy(s => s.Name);
                    break;
                case "endDate":
                    assignmentsIQ = assignmentsIQ.OrderBy(s => s.EndDate).ThenBy(s => s.Name);
                    break;
                case "endDate_desc":
                    assignmentsIQ = assignmentsIQ.OrderByDescending(s => s.EndDate).ThenBy(s => s.Name);
                    break;
                case "position":
                    assignmentsIQ = assignmentsIQ.OrderBy(s => s.Position.Name).ThenBy(s => s.Name);
                    break;
                case "position_desc":
                    assignmentsIQ = assignmentsIQ.OrderByDescending(s => s.Position.Name).ThenBy(s => s.Name);
                    break;
                case "employee":
                    assignmentsIQ = assignmentsIQ.OrderBy(s => s.Employee.LastName).ThenBy(s => s.Employee.FirstName).ThenBy(s => s.Name);
                    break;
                case "employee_desc":
                    assignmentsIQ = assignmentsIQ.OrderByDescending(s => s.Employee.LastName).ThenBy(s => s.Employee.FirstName).ThenBy(s => s.Name);
                    break;
                case "state":
                    assignmentsIQ = assignmentsIQ.OrderBy(s => s.AssignmentState).ThenBy(s => s.Name);
                    break;
                case "state_desc":
                    assignmentsIQ = assignmentsIQ.OrderByDescending(s => s.AssignmentState).ThenBy(s => s.Name);
                    break;
                default:
                    assignmentsIQ = assignmentsIQ.OrderBy(s => s.Name);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Assignment = await PaginatedList<Assignment>.CreateAsync(
                assignmentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            _logger.LogInformation("Displaying page {1} of Assignments", pageIndex);
        }
        //Method to debug states
        public async Task<IActionResult> OnGetActivateAsync(string sortOrder,
            string currentFilter, int? pageIndex)
        {
            foreach (var assignment in _context.Assignments)
            {
                if (assignment.PositionId != null)
                {
                    _context.Entry(assignment)
                        .Reference(a => a.Position)
                        .Load();
                    if (assignment.Position.PositionState == PositionState.Active)
                        assignment.AssignmentState = AssignmentState.Active;
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
