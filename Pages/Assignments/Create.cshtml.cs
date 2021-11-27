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

namespace ERPSystem.Pages.Assignments
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

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

            ViewData["EmployeeId"] = new SelectList(_context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName), "Id", "FullName");
            ViewData["PositionId"] = new SelectList(_context.Positions.OrderBy(e => e.Name), "Id", "Name");

            Assignment = new Assignment();
            Assignment.AssignmentState = AssignmentState.Inactive;

            return Page();
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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

            _context.Assignments.Add(Assignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
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
