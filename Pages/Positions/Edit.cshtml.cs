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

namespace ERPSystem.Pages.Positions
{
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }
        public List<SelectListItem> InactiveState { get; set; }

        public EditModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

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

            Position = await _context.Positions
                .Include(p => p.Project)
                .Include(p => p.Assignments)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Position == null)
            {
                return NotFound();
            }

            ViewData["ProjectId"] = new SelectList(_context.Projects.OrderBy(p => p.Name), "Id", "Name");

            InactiveState = new List<SelectListItem>
            {
                new SelectListItem { Value = "2", Text = "Inactive" }
            };

            var AssignmentsQuery = _context.Assignments.OrderBy(e => e.Name).AsNoTracking();
            AssignmentsSelectList = new SelectList(AssignmentsQuery, "Id", "Name"); //list, id, value

            SelectedAssignments = new List<int>();
            foreach (var assignment in Position.Assignments.OrderBy(a => a.Name))
            {
                SelectedAssignments.Add(assignment.Id);
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedAssignments)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var PositionToUpdate = await _context.Positions
                .Include(p => p.Project)
                .Include(p => p.Assignments)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if(Position.Project != null)
            {
                if (Position.StartDate < Position.Project.StartDate)
                    Position.StartDate = Position.Project.StartDate;
                if (Position.EndDate > Position.Project.EndDate)
                    Position.EndDate = Position.Project.EndDate;
            }

            if (await TryUpdateModelAsync<Position>(
                    PositionToUpdate,
                    "Position",
                    b => b.Name, b => b.PositionState, b => b.ProjectId, b => b.StartDate, b => b.EndDate))
            {
                UpdateAssignments(SelectedAssignments, PositionToUpdate);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(Position.Id))
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

        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }

        private void UpdateAssignments(int[] SelectedAssignments, Position Position)
        {
            {
                if (SelectedAssignments.Length == 0)
                {
                    Position.Assignments = new List<Assignment>();
                    return;
                }

                var SelectedAssignmentsHS = new HashSet<int>(SelectedAssignments);
                var PositionAssignmentsHS = new HashSet<int>
                    (Position.Assignments.Select(s => s.Id));
                foreach (var assignment in _context.Assignments)
                {
                    //If items are selected
                    if (SelectedAssignmentsHS.Contains(assignment.Id))
                    {
                        //If item not present
                        if (!PositionAssignmentsHS.Contains(assignment.Id))
                        {
                            Position.Assignments.Add(assignment);
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (PositionAssignmentsHS.Contains(assignment.Id))
                        {
                            var toRemove = Position.Assignments.Single(s => s.Id == assignment.Id);
                            Position.Assignments.Remove(toRemove);
                        }
                    }
                }
            }
        }
        public async Task<JsonResult> OnGetProjectAsync(string projectId)
        {
            if (!string.IsNullOrWhiteSpace(projectId))
            {
                if (Int32.TryParse(projectId, out int id))
                {
                    var project = await _context.Projects.FindAsync(id);
                    if (project != null)
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
