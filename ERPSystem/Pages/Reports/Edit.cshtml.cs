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

namespace ERPSystem.Pages.Reports
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
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

        public EditModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Report Report { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Report = await _context.Reports
                .Include(r => r.Assignment)
                .ThenInclude(r => r.Employee).FirstOrDefaultAsync(m => m.Id == id);
            
            if (Report == null)
            {
                return NotFound();
            }

            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            Assignment = await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Position)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == Report.AssignmentId);

            if(Assignment != null)
            {
                MinDate = Assignment.StartDate.ToString("yyyy-MM-dd");
                MaxDate = Assignment.EndDate.ToString("yyyy-MM-dd");
            }

            Hours = Report.Hours;
            Report.ReportState = ReportState.Submitted;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string sortOrder,
            string currentFilter, int? pageIndex, double Hours)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Report.Hours = Hours;

            _context.Attach(Report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(Report.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        private bool ReportExists(int id)
        {
            return _context.Reports.Any(e => e.Id == id);
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
}
