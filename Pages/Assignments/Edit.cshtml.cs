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

namespace ERPSystem.Pages.Assignments
{
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public EditModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
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
           ViewData["EmployeeId"] = new SelectList(_context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName), "Id", "FullName");
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
                _context.Positions.Load();
                if (Assignment.StartDate < Assignment.Position.StartDate)
                    Assignment.StartDate = Assignment.Position.StartDate;
                if (Assignment.EndDate > Assignment.Position.EndDate)
                    Assignment.EndDate = Assignment.Position.EndDate;
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
    }
}
