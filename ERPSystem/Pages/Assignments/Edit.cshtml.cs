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

namespace ERPSystem.Pages.Assignments
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<EditModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public EditModel(ERPSystem.Data.ApplicationDbContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

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

            Assignment = await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Position).FirstOrDefaultAsync(m => m.Id == id);

            if (Assignment == null)
            {
                return NotFound();
            }
            if (_context.Employees.Any())
                ViewData["EmployeeId"] = new SelectList(_context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName), "Id", "FullName");
            if (_context.Positions.Any())
                ViewData["PositionId"] = new SelectList(_context.Positions.OrderBy(e => e.Name), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string sortOrder,
            string currentFilter, int? pageIndex)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Assignment.PositionId != null)
            {
                Position position = await _context.Positions.FindAsync(Assignment.PositionId);
                if (position != null)
                {
                    if (Assignment.StartDate < position.StartDate)
                        Assignment.StartDate = position.StartDate;
                    if (Assignment.EndDate > position.EndDate)
                        Assignment.EndDate = position.EndDate;
                }
            }

            _context.Attach(Assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(Assignment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation("Assignment modified: {0}", Assignment.Name);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
        public async Task<JsonResult> OnGetPositionAsync(string positionId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetPositionStateAsync(positionId);
        }
        public async Task<JsonResult> OnGetEmployeeAsync(string employeeId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetEmployeeStateAsync(employeeId);
        }
        public async Task<JsonResult> OnGetDateRangeAsync(string positionId)
        {
            if (Int32.TryParse(positionId, out int id))
            {
                Position position = await _context.Positions.FindAsync(id);
                if (position != null)
                {
                    return new JsonResult(new
                    {
                        startmin = position.StartDate.ToString("yyyy-MM-dd"),
                        startmax = position.EndDate.AddDays(-1).ToString("yyyy-MM-dd"),
                        endmin = position.StartDate.AddDays(1).ToString("yyyy-MM-dd"),
                        endmax = position.EndDate.ToString("yyyy-MM-dd")
                    });
                }
            }
            return new JsonResult(null);
        }
    }
}
