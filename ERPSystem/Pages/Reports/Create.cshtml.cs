using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Domain.Entities;
using ERPSystem.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Reports
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        private readonly IReportCalculationService _reportCalculation;
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

        public CreateModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context, IReportCalculationService reportCalculation, ILogger<CreateModel> logger)
        {
            _context = context;
            _reportCalculation = reportCalculation;
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

            if (Assignment == null)
            {
                return NotFound();
            }

            Report = new Report();
            Report.ReportState = ReportState.Submitted;

            var obj = await _reportCalculation.GetHoursAsync(DateTime.Now.Date, id);
            if (obj == null)
            {
                // Nothing to report yet: the assignment hasn't started as of today.
                Report.Hours = Hours = 0;
                Report.Date = Assignment.StartDate;
            }
            else
            {
                Report.Hours = Hours = obj.hours;
                Report.Date = obj.date;
            }
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
            {
                Assignment.Reports.Add(Report);
                _logger.LogInformation("Report created for assignment: {0}", Assignment.Name);
            }

            _context.Reports.Add(Report);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
        public async Task<JsonResult> OnGetHoursAsync(string inDate, string assignmentId)
        {
            if (Int32.TryParse(assignmentId, out int id))
            {
                DateTime date = DateTime.Parse(inDate);
                var result = await _reportCalculation.GetHoursAsync(date, id);
                if (result != null)
                {
                    return new JsonResult(new
                    {
                        hours = result.hours.ToString(),
                        date = result.date.ToString("yyyy-MM-dd"),
                        min = result.min.ToString("yyyy-MM-dd"),
                        max = result.max.ToString("yyyy-MM-dd")
                    });
                }
            }
            return new JsonResult(null);
        }
    }
}
