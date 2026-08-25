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
using ERPSystem.Web.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ERPSystem.Pages.Positions
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        private readonly IStateCascadeService _stateCascade;
        private readonly IEntityStateLookupService _stateLookup;
        private readonly IValidator<Position> _validator;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }

        public CreateModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context, IStateCascadeService stateCascade,
            IEntityStateLookupService stateLookup, IValidator<Position> validator)
        {
            _context = context;
            _stateCascade = stateCascade;
            _stateLookup = stateLookup;
            _validator = validator;
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
            Position.EndDate = DateRangeHelper.GetRandomDate(DateTime.Now, DateTime.Now.AddYears(2));

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

            var validationResult = await _validator.ValidateAsync(Position);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState, nameof(Position));
            }

            if (!ModelState.IsValid)
            {
                var AssignmentsQuery = _context.Assignments.OrderBy(e => e.Name).AsNoTracking();
                AssignmentsSelectList = new SelectList(AssignmentsQuery, "Id", "Name"); //list, id, value
                if (SelectedAssignments != null)
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

            _stateCascade.UpdatePositionDependants(PositionsWithModifiedState);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        public async Task<JsonResult> OnGetProjectAsync(string projectId)
        {
            return new JsonResult(await _stateLookup.GetProjectStateAsync(projectId));
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
