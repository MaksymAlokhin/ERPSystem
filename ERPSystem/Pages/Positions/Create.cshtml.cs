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

namespace ERPSystem.Pages.Positions
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<CreateModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }

        public CreateModel(ERPSystem.Data.ApplicationDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet(string sortOrder,
            string currentFilter, int? pageIndex)
        {

            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            SelectedAssignments = new List<int>();
            Position = new Position();
            Position.PositionState = PositionState.Inactive;
            Position.StartDate = DateTime.Now;
            Position.EndDate = Utility.GetRandomDate(DateTime.Now, DateTime.Now.AddYears(2));

            var AssignmentsQuery = _context.Assignments.OrderBy(e => e.Name).AsNoTracking();
            AssignmentsSelectList = new SelectList(AssignmentsQuery, "Id", "Name"); //list, id, value

            SelectedAssignments = new List<int>();

            ViewData["ProjectId"] = new SelectList(_context.Projects.OrderBy(p => p.Name), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Position Position { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedAssignments)
        {
            List<int> PositionsWithModifiedState = new List<int>();

            if (!ModelState.IsValid)
            {
                var AssignmentsQuery = _context.Assignments.OrderBy(e => e.Name).AsNoTracking();
                AssignmentsSelectList = new SelectList(AssignmentsQuery, "Id", "Name"); //list, id, value
                this.SelectedAssignments = SelectedAssignments.ToList();
                return Page();
            }

            if (Position.ProjectId != null)
            {
                Project project = await _context.Projects.FindAsync(Position.ProjectId);
                if (project != null)
                {
                    if (Position.StartDate < project.StartDate)
                        Position.StartDate = project.StartDate;
                    if (Position.EndDate > project.EndDate)
                        Position.EndDate = project.EndDate;
                }
            }

            var NewPosition = new Position();

            //Refactored because TryUpdateModelAsync fails while unit testing:
            //https://github.com/dotnet/AspNetCore.Docs/issues/14009
            //if (await TryUpdateModelAsync<Position>(
            //        NewPosition,
            //        "Position",
            //        d => d.Name, d => d.PositionState, d => d.StartDate, d => d.EndDate, d => d.ProjectId))
            //return Page();

            NewPosition.Name = Position.Name;
            NewPosition.PositionState = Position.PositionState;
            NewPosition.StartDate = Position.StartDate;
            NewPosition.EndDate = Position.EndDate;
            NewPosition.ProjectId = Position.ProjectId;

            if (SelectedAssignments != null)
            {
                if (SelectedAssignments.Length > 0)
                {
                    NewPosition.Assignments = new List<Assignment>();
                }
                foreach (var assignment in SelectedAssignments)
                {
                    var foundAssignment = await _context.Assignments.FindAsync(assignment);
                    if (foundAssignment != null)
                    {
                        NewPosition.Assignments.Add(foundAssignment);
                    }
                }
            }

            _context.Positions.Add(NewPosition);
            await _context.SaveChangesAsync();

            PositionsWithModifiedState.Add(NewPosition.Id);

            Utility utility = new Utility(_context);
            utility.UpdateProjectDependants(PositionsWithModifiedState);

            _logger.LogInformation("Position created: {1}", NewPosition.Name);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        public async Task<JsonResult> OnGetProjectAsync(string projectId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetProjectStateAsync(projectId);
        }
        public async Task<JsonResult> OnGetDateRangeAsync(string projectId)
        {
            if (Int32.TryParse(projectId, out int id))
            {
                Project project = await _context.Projects.FindAsync(id);
                if (project != null)
                {
                    return new JsonResult(new
                    {
                        startmin = project.StartDate.ToString("yyyy-MM-dd"),
                        startmax = project.EndDate.AddDays(-1).ToString("yyyy-MM-dd"),
                        endmin = project.StartDate.AddDays(1).ToString("yyyy-MM-dd"),
                        endmax = project.EndDate.ToString("yyyy-MM-dd")
                    });
                }
            }
            return new JsonResult(null);
        }
    }
}
