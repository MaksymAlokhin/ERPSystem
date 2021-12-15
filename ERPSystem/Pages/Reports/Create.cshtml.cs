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

namespace ERPSystem.Pages.Reports
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<CreateModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public Assignment Assignment { get; set; }
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
        public double Hours { get; set; }
        public List<SelectListItem> State { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Draft" },
            new SelectListItem { Value = "1", Text = "Submitted" }
        };

        public CreateModel(ERPSystem.Data.ApplicationDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> OnGet(string sortOrder,
            string currentFilter, int? pageIndex, int id)
        {
            Assignment = await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Position)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            Report = new Report();
            Report.ReportState = ReportState.Submitted;

            Utility utility = new Utility(_context);
            var obj = await utility.GetHours(DateTime.Now.Date, id);
            Report.Hours = Hours = obj.hours;
            Report.Date = obj.date;
            MinDate = Assignment.StartDate.ToString("yyyy-MM-dd");
            MaxDate = Assignment.EndDate.ToString("yyyy-MM-dd");
            return Page();
        }

        [BindProperty]
        public Report Report { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? id, double Hours)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Report.Hours = Hours;

            Assignment = await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Position)
                .Include(a => a.Reports)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (Assignment != null)
                Assignment.Reports.Add(Report);

            _context.Reports.Add(Report);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Report created for assignment: {1}", Assignment.Name);

            return RedirectToPage("./Index");
        }
        public async Task<JsonResult> OnGetHoursAsync(string inDate, string assignmentId)
        {
            if (Int32.TryParse(assignmentId, out int id))
            {
                Utility utility = new Utility(_context);
                DateTime date = DateTime.Parse(inDate);
                var result = await utility.GetHours(date, id);
                return new JsonResult(new
                {
                    hours = result.hours.ToString(),
                    date = result.date.ToString("yyyy-MM-dd"),
                    min = result.min.ToString("yyyy-MM-dd"),
                    max = result.max.ToString("yyyy-MM-dd")
                });
            }
            return new JsonResult(null);
        }
    }
    public class ReportData
    {
        public double hours { get; set; }
        public DateTime date { get; set; }
        public DateTime min { get; set; }
        public DateTime max { get; set; }
    }
}
