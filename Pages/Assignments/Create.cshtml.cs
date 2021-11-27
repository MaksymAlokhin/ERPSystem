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
                _context.Positions.Load();
                if (Assignment.StartDate < Assignment.Position.StartDate)
                    Assignment.StartDate = Assignment.Position.StartDate;
                if (Assignment.EndDate > Assignment.Position.EndDate)
                    Assignment.EndDate = Assignment.Position.EndDate;
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
    }
}
