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

namespace ERPSystem.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration Configuration;
        public string AssignmentSort { get; set; }
        public string DateSort { get; set; }
        public string EmployeeSort { get; set; }
        public string HoursSort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Report> Report { get; set; }
        public List<StateDoughnut> Doughnut { get; set; }

        public IndexModel(ERPSystem.Data.ApplicationDbContext context, IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _context = context;
            Configuration = configuration;
            _logger = logger;
            Doughnut = _context.Reports
                .GroupBy(r => r.ReportState)
                .Select(g => new StateDoughnut
                {
                    state = g.Key.ToString(),
                    count = g.Count()
                })
                .AsNoTracking()
                .ToList();
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            AssignmentSort = String.IsNullOrEmpty(sortOrder) ? "assignment_desc" : "";
            EmployeeSort = sortOrder == "employee" ? "employee_desc" : "employee";
            DateSort = sortOrder == "date" ? "date_desc" : "date";
            HoursSort = sortOrder == "hours" ? "hours_desc" : "hours";
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
            IQueryable<Report> reportsIQ = _context.Reports
                .Include(r => r.Assignment)
                .ThenInclude(r => r.Employee);
            if (!String.IsNullOrEmpty(searchString))
            {
                reportsIQ = reportsIQ.Where(s => s.Assignment.Name.Contains(searchString)
                                       || s.Assignment.Employee.LastName.Contains(searchString)
                                       || s.Assignment.Employee.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "assignment_desc":
                    reportsIQ = reportsIQ.OrderByDescending(s => s.Assignment.Name)
                        .ThenBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Date);
                    break;
                case "date":
                    reportsIQ = reportsIQ.OrderBy(s => s.Date)
                        .ThenBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Assignment.Name);
                    break;
                case "date_desc":
                    reportsIQ = reportsIQ.OrderByDescending(s => s.Date)
                        .ThenBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Assignment.Name);
                    break;
                case "hours":
                    reportsIQ = reportsIQ.OrderBy(s => s.Hours)
                        .ThenBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Assignment.Name)
                        .ThenBy(s => s.Date);
                    break;
                case "hours_desc":
                    reportsIQ = reportsIQ.OrderByDescending(s => s.Hours)
                        .ThenBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Assignment.Name)
                        .ThenBy(s => s.Date);
                    break;
                case "state":
                    reportsIQ = reportsIQ.OrderBy(s => s.ReportState)
                        .ThenBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Assignment.Name)
                        .ThenBy(s => s.Date);
                    break;
                case "state_desc":
                    reportsIQ = reportsIQ.OrderByDescending(s => s.ReportState)
                        .ThenBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Assignment.Name)
                        .ThenBy(s => s.Date);
                    break;
                case "employee":
                    reportsIQ = reportsIQ.OrderBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Assignment.Name)
                        .ThenBy(s => s.Date);
                    break;
                case "employee_desc":
                    reportsIQ = reportsIQ.OrderByDescending(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Assignment.Name)
                        .ThenBy(s => s.Date);
                    break;
                default:
                    reportsIQ = reportsIQ.OrderBy(s => s.Assignment.Name)
                        .ThenBy(s => s.Assignment.Employee.LastName)
                        .ThenBy(s => s.Assignment.Employee.FirstName)
                        .ThenBy(s => s.Date);
                    break;


            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Report = await PaginatedList<Report>.CreateAsync(
                reportsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            _logger.LogInformation("Displaying page {0} of Reports", pageIndex ?? 1);
        }
        public async Task<IActionResult> OnGetApproveAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            Report report = await _context.Reports.FindAsync(id);
            report.ReportState = ReportState.Approved;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
        public JsonResult OnGetReportState()
        {
            return new JsonResult(Doughnut);
        }
    }
    public class StateDoughnut
    {
        public string state { get; set; }
        public int count { get; set; }
    }

}
