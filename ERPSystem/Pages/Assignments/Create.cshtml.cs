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
using ERPSystem.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Assignments
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        private readonly IEntityStateLookupService _stateLookup;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public CreateModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context, IEntityStateLookupService stateLookup, ILogger<CreateModel> logger)
        {
            _context = context;
            _stateLookup = stateLookup;
            _logger = logger;
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
            Assignment.StartDate = DateRangeHelper.GetRandomDate(DateTime.Now.AddYears(-2), DateTime.Now);
            Assignment.EndDate = DateRangeHelper.GetRandomDate(DateTime.Now, DateTime.Now.AddYears(2));

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

            //Static Serilog
            //Log.Information("Assignment created: {1}", Assignment.Name);
            _logger.LogInformation("Assignment created: {0}", Assignment.Name);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
        public async Task<JsonResult> OnGetPositionAsync(string positionId)
        {
            return new JsonResult(await _stateLookup.GetPositionStateAsync(positionId));
        }
        public async Task<JsonResult> OnGetEmployeeAsync(string employeeId)
        {
            return new JsonResult(await _stateLookup.GetEmployeeStateAsync(employeeId));
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
