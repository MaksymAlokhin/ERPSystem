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

namespace ERPSystem.Pages.Positions
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }
        public List<SelectListItem> InactiveState { get; set; }


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

            SelectedAssignments = new List<int>();
            Position = new Position();
            Position.PositionState = PositionState.Inactive;

            InactiveState = new List<SelectListItem>
            {
                new SelectListItem { Value = "2", Text = "Inactive" }
            };

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NewPosition = new Position();

            if (SelectedAssignments.Length > 0)
            {
                NewPosition.Assignments = new List<Assignment>();
                _context.Assignments.Load();
            }

            foreach (var assignment in SelectedAssignments)
            {
                var foundAssignment = await _context.Assignments.FindAsync(assignment);
                if (foundAssignment != null)
                {
                    NewPosition.Assignments.Add(foundAssignment);
                }
            }

            if (await TryUpdateModelAsync<Position>(
                    NewPosition,
                    "Position",
                    d => d.Name, d => d.PositionState, d => d.StartDate, d => d.EndDate, d => d.ProjectId))
            {

                if (Position.Project != null)
                {
                    if (Position.StartDate < Position.Project.StartDate)
                        Position.StartDate = Position.Project.StartDate;
                    if (Position.EndDate > Position.Project.EndDate)
                        Position.EndDate = Position.Project.EndDate;
                }

                _context.Positions.Add(NewPosition);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index", new
                {
                    pageIndex = $"{pageIndex}",
                    sortOrder = $"{sortOrder}",
                    currentFilter = $"{currentFilter}"
                });
            }
            return Page();
        }
        public async Task<JsonResult> OnGetProjectAsync(string projectId)
        {
            if (!string.IsNullOrWhiteSpace(projectId))
            {
                if (Int32.TryParse(projectId, out int id))
                {
                    var project = await _context.Projects.FindAsync(id);
                    if(project != null)
                    {
                        if (project.ProjectState == ProjectState.Active)
                            return new JsonResult("Active");
                        else
                            return new JsonResult("Inactive");
                    }
                    else return new JsonResult("Inactive");
                }
                else
                {
                    return new JsonResult("Inactive");
                }
            }
            return new JsonResult("Inactive");
        }
    }
}
