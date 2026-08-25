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

namespace ERPSystem.Pages.Projects
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        private readonly IStateCascadeService _stateCascade;
        private readonly IEntityStateLookupService _stateLookup;
        private readonly IValidator<Project> _validator;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedPositions { get; set; }
        public SelectList PositionsSelectList { get; set; }
        public List<SelectListItem> ProjectManagerList { get; set; }
        public int? ProjectManagerId;

        public CreateModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context, IStateCascadeService stateCascade,
            IEntityStateLookupService stateLookup, IValidator<Project> validator)
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

            ProjectManagerList = new List<SelectListItem>();
            foreach (Employee pm in _context.Employees
                    .Where(e => e.EmployeeRole == EmployeeRole.ProjectManager)
                    .OrderBy(e => e.LastName)
                    .ThenBy(e => e.FirstName))
            {
                ProjectManagerList.Add(new SelectListItem { Value = $"{pm.Id}", Text = $"{pm.FullName}" });
            }

            var PositionsQuery = _context.Positions.OrderBy(p => p.Name).AsNoTracking();
            PositionsSelectList = new SelectList(PositionsQuery, "Id", "Name"); //list, id, value

            SelectedPositions = new List<int>();
            ViewData["DepartmentId"] = new SelectList(_context.Departments.OrderBy(d => d.Name), "Id", "Name");

            Project = new Project();
            Project.ProjectState = ProjectState.Inactive;
            Project.StartDate = DateRangeHelper.GetRandomDate(DateTime.Now.AddYears(-2), DateTime.Now);
            Project.EndDate = DateRangeHelper.GetRandomDate(DateTime.Now, DateTime.Now.AddYears(2));
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? ProjectManagerId, int[] SelectedPositions)
        {
            List<int> ProjectsWithModifiedState = new List<int>();

            var validationResult = await _validator.ValidateAsync(Project);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState, nameof(Project));
            }

            if (!ModelState.IsValid)
            {
                var PositionsQuery = _context.Positions.OrderBy(p => p.Name).AsNoTracking();
                PositionsSelectList = new SelectList(PositionsQuery, "Id", "Name"); //list, id, value
                if (SelectedPositions != null)
                    this.SelectedPositions = SelectedPositions.ToList();
                return Page();
            }

            var NewProject = new Project();

            //if (await TryUpdateModelAsync<Project>(
            //    NewProject,
            //    "Project",
            //    p => p.Name, p => p.ProjectState, p => p.StartDate, p => p.EndDate, p => p.DepartmentId))
            //return Page();

            NewProject.Name = Project.Name;
            NewProject.ProjectState = Project.ProjectState;
            NewProject.StartDate = Project.StartDate;
            NewProject.EndDate = Project.EndDate;
            NewProject.DepartmentId = Project.DepartmentId;

            if (ProjectManagerId != null)
            {
                Employee pm = await _context.Employees
                    .Where(e => e.EmployeeRole == EmployeeRole.ProjectManager && e.Id == ProjectManagerId)
                    .FirstOrDefaultAsync();
                if (pm.ProjectId != null)
                {
                    var oldProject = await _context.Projects.FindAsync(pm.ProjectId);
                    if (oldProject.ProjectState != ProjectState.Inactive)
                    {
                        oldProject.ProjectState = ProjectState.Inactive;
                        ProjectsWithModifiedState.Add(oldProject.Id);
                    }
                }
                pm.ProjectId = null;
                NewProject.ProjectManager = pm;
            }

            if (SelectedPositions != null)
            {
                if (SelectedPositions.Length > 0)
                {
                    NewProject.Positions = new List<Position>();
                }
                foreach (var position in SelectedPositions)
                {
                    var foundPosition = await _context.Positions.FindAsync(position);
                    if (foundPosition != null)
                    {
                        NewProject.Positions.Add(foundPosition);
                    }
                }
            }

            _context.Projects.Add(NewProject);
            await _context.SaveChangesAsync();

            ProjectsWithModifiedState.Add(NewProject.Id);

            _stateCascade.UpdateProjectDependants(ProjectsWithModifiedState);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
        public async Task<JsonResult> OnGetDepartmentAsync(string departmentId)
        {
            return new JsonResult(await _stateLookup.GetDepartmentStateAsync(departmentId));
        }
        public async Task<JsonResult> OnGetEmployeeAsync(string employeeId)
        {
            return new JsonResult(await _stateLookup.GetEmployeeStateAsync(employeeId));
        }
    }
}
