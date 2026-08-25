using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Domain.Entities;
using ERPSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ERPSystem.Pages.Employees
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        private readonly IStateCascadeService _stateCascade;
        private readonly IEntityStateLookupService _stateLookup;
        private readonly IMentorLookupService _mentorLookup;
        private readonly IPhotoUploadService _photoUpload;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedMentors { get; set; }
        public List<SelectListItem> MentorsSelectList { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }
        public EmployeeRole Role { get; set; }
        public IFormFile FormFile { get; set; }

        public EditModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context, IStateCascadeService stateCascade,
            IEntityStateLookupService stateLookup, IMentorLookupService mentorLookup, IPhotoUploadService photoUpload)
        {
            _context = context;
            _stateCascade = stateCascade;
            _stateLookup = stateLookup;
            _mentorLookup = mentorLookup;
            _photoUpload = photoUpload;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(EmployeeRole Role, string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            this.Role = Role;
            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(e => e.Branch)
                .Include(e => e.Company)
                .Include(e => e.Department)
                .Include(e => e.Project)
                .Include(e => e.Assignments)
                .Include(e => e.Mentors)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null)
            {
                return NotFound();
            }

            if (_context.Branches.Any())
                ViewData["BranchId"] = new SelectList(_context.Branches.OrderBy(b => b.Name), "Id", "Name");
            if (_context.Companies.Any())
                ViewData["CompanyId"] = new SelectList(_context.Companies.OrderBy(c => c.Name), "Id", "Name");
            if (_context.Departments.Any())
                ViewData["DepartmentId"] = new SelectList(_context.Departments.OrderBy(d => d.Name), "Id", "Name");
            if (_context.Projects.Any())
                ViewData["ProjectId"] = new SelectList(_context.Projects.OrderBy(p => p.Name), "Id", "Name");

            //Mentors Initial Dropdown List
            switch (Employee.EmployeeRole)
            {
                case EmployeeRole.Employee:
                case EmployeeRole.Mentor:
                    MentorsSelectList = (await _mentorLookup.GetMentorsByBranchAsync(Employee.BranchId.ToString()))
                        .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.FullName }).ToList();
                    break;
                case EmployeeRole.ProjectManager:
                    MentorsSelectList = (await _mentorLookup.GetMentorsByProjectAsync(Employee.ProjectId.ToString()))
                        .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.FullName }).ToList();
                    break;
                case EmployeeRole.DepartmentHead:
                    MentorsSelectList = (await _mentorLookup.GetMentorsByDepartmentAsync(Employee.DepartmentId.ToString()))
                        .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.FullName }).ToList();
                    break;
                case EmployeeRole.GeneralManager:
                    MentorsSelectList = new List<SelectListItem>()
                    {
                        new SelectListItem
                        {
                            Value = null,
                            Text = ""
                        }
                    };
                    break;
            }

            SelectedMentors = new List<int>();
            foreach (var mentor in Employee.Mentors)
            {
                SelectedMentors.Add(mentor.Id);
            }

            var AssignmentsQuery = _context.Assignments.OrderBy(e => e.Name).AsNoTracking();
            AssignmentsSelectList = new SelectList(AssignmentsQuery, "Id", "Name"); //list, id, value

            SelectedAssignments = new List<int>();
            foreach (var assignment in Employee.Assignments.OrderBy(a => a.Name))
            {
                SelectedAssignments.Add(assignment.Id);
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, EmployeeRole Role, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedMentors, int[] SelectedAssignments)
        {
            List<int> DepartmentsWithModifiedState = new List<int>();
            List<int> CompaniesWithModifiedState = new List<int>();
            List<int> ProjectsWithModifiedState = new List<int>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var EmployeeToUpdate = await _context.Employees
                .Include(e => e.Branch)
                .Include(e => e.Company)
                .Include(e => e.Department)
                .Include(e => e.Project)
                .Include(e => e.Assignments)
                .Include(e => e.Mentors)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Employee.EmployeeRole == EmployeeToUpdate.EmployeeRole)
            {
                //Copy data from model to existing entity we are editing
                switch (Employee.EmployeeRole)
                {
                    case EmployeeRole.Employee:
                        EmployeeToUpdate.BranchId = Employee.BranchId;
                        UpdateAssignments(SelectedAssignments, EmployeeToUpdate);
                        UpdateMentors(SelectedMentors, EmployeeToUpdate);
                        break;
                    case EmployeeRole.Mentor:
                        EmployeeToUpdate.BranchId = Employee.BranchId;
                        UpdateAssignments(SelectedAssignments, EmployeeToUpdate);
                        break;
                    case EmployeeRole.DepartmentHead:
                        UpdateMentors(SelectedMentors, EmployeeToUpdate);
                        if (EmployeeToUpdate.DepartmentId != Employee.DepartmentId)
                        {
                            if (EmployeeToUpdate.Department != null &&
                                EmployeeToUpdate.Department.DepartmentState != DepartmentState.Inactive)
                            {
                                EmployeeToUpdate.Department.DepartmentState = DepartmentState.Inactive;
                                DepartmentsWithModifiedState.Add(EmployeeToUpdate.Department.Id);
                            }
                            Employee oldDh = await _context.Employees.Where(e => e.DepartmentId == Employee.DepartmentId).FirstOrDefaultAsync();
                            if (oldDh != null)
                                oldDh.DepartmentId = null;
                            EmployeeToUpdate.DepartmentId = Employee.DepartmentId;
                            Department department = await _context.Departments
                                .Include(d => d.Company)
                                .Include(d => d.DepartmentHead)
                                .Where(d => d.Id == EmployeeToUpdate.DepartmentId)
                                .FirstOrDefaultAsync();
                            if (department != null)
                            {
                                if (department.Company != null)
                                {
                                    if (Employee.EmployeeState == EmployeeState.Active && department.Company.CompanyState == CompanyState.Active)
                                    {
                                        if (department.DepartmentState != DepartmentState.Active)
                                        {
                                            department.DepartmentState = DepartmentState.Active;
                                            DepartmentsWithModifiedState.Add(department.Id);
                                        }
                                    }
                                    else
                                    {
                                        if (department.DepartmentState != DepartmentState.Inactive)
                                        {
                                            department.DepartmentState = DepartmentState.Inactive;
                                            DepartmentsWithModifiedState.Add(department.Id);
                                        }
                                    }
                                }
                                else
                                {
                                    if (department.DepartmentState != DepartmentState.Inactive)
                                    {
                                        department.DepartmentState = DepartmentState.Inactive;
                                        DepartmentsWithModifiedState.Add(department.Id);
                                    }
                                }
                            }
                        }
                        break;
                    case EmployeeRole.GeneralManager:
                        if (EmployeeToUpdate.CompanyId != Employee.CompanyId)
                        {
                            if (EmployeeToUpdate.Company != null &&
                                EmployeeToUpdate.Company.CompanyState != CompanyState.Inactive)
                            {
                                EmployeeToUpdate.Company.CompanyState = CompanyState.Inactive;
                                CompaniesWithModifiedState.Add(EmployeeToUpdate.Company.Id);
                            }
                            Employee oldGm = await _context.Employees.Where(e => e.CompanyId == Employee.CompanyId).FirstOrDefaultAsync();
                            if (oldGm != null)
                                oldGm.CompanyId = null;
                            EmployeeToUpdate.CompanyId = Employee.CompanyId;
                            Company company = await _context.Companies
                                .Include(d => d.GeneralManager)
                                .Where(d => d.Id == EmployeeToUpdate.CompanyId)
                                .FirstOrDefaultAsync();
                            if (company != null)
                            {
                                if (Employee.EmployeeState == EmployeeState.Active)
                                {
                                    if (company.CompanyState != CompanyState.Active)
                                    {
                                        company.CompanyState = CompanyState.Active;
                                        CompaniesWithModifiedState.Add(company.Id);
                                    }
                                }
                                else
                                {
                                    if (company.CompanyState != CompanyState.Inactive)
                                    {
                                        company.CompanyState = CompanyState.Inactive;
                                        CompaniesWithModifiedState.Add(company.Id);
                                    }
                                }
                            }
                        }
                        break;
                    case EmployeeRole.ProjectManager:
                        UpdateMentors(SelectedMentors, EmployeeToUpdate);
                        if (EmployeeToUpdate.ProjectId != Employee.ProjectId)
                        {
                            if (EmployeeToUpdate.Project != null &&
                                EmployeeToUpdate.Project.ProjectState != ProjectState.Inactive)
                            {
                                EmployeeToUpdate.Project.ProjectState = ProjectState.Inactive;
                                ProjectsWithModifiedState.Add(EmployeeToUpdate.Project.Id);
                            }
                            Employee oldPm = await _context.Employees.Where(e => e.ProjectId == Employee.ProjectId).FirstOrDefaultAsync();
                            if (oldPm != null)
                                oldPm.ProjectId = null;
                            EmployeeToUpdate.ProjectId = Employee.ProjectId;
                            Project project = await _context.Projects
                                .Include(d => d.Department)
                                .Include(d => d.ProjectManager)
                                .Where(d => d.Id == EmployeeToUpdate.ProjectId)
                                .FirstOrDefaultAsync();
                            if (project != null)
                            {
                                if (project.Department != null)
                                {
                                    if (Employee.EmployeeState == EmployeeState.Active && project.Department.DepartmentState == DepartmentState.Active)
                                    {
                                        if (project.ProjectState != ProjectState.Active)
                                        {
                                            project.ProjectState = ProjectState.Active;
                                            ProjectsWithModifiedState.Add(project.Id);
                                        }
                                    }
                                    else
                                    {
                                        if (project.ProjectState != ProjectState.Inactive)
                                        {
                                            project.ProjectState = ProjectState.Inactive;
                                            ProjectsWithModifiedState.Add(project.Id);
                                        }
                                    }
                                }
                                else
                                {
                                    if (project.ProjectState != ProjectState.Inactive)
                                    {
                                        project.ProjectState = ProjectState.Inactive;
                                        ProjectsWithModifiedState.Add(project.Id);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                //remove old data
                switch (EmployeeToUpdate.EmployeeRole)
                {
                    case EmployeeRole.Employee:
                        if (Employee.EmployeeRole != EmployeeRole.Mentor)
                        {
                            foreach (Assignment assignment in EmployeeToUpdate.Assignments)
                                assignment.EmployeeId = null;
                            EmployeeToUpdate.BranchId = null;
                        }
                        if (Employee.EmployeeRole == EmployeeRole.Mentor
                            || Employee.EmployeeRole == EmployeeRole.GeneralManager)
                        {
                            foreach (Employee mentor in EmployeeToUpdate.Mentors)
                                EmployeeToUpdate.Mentors.Remove(mentor);
                        }
                        break;
                    case EmployeeRole.Mentor:
                        if (Employee.EmployeeRole != EmployeeRole.Employee)
                        {
                            foreach (Assignment assignment in EmployeeToUpdate.Assignments)
                                assignment.EmployeeId = null;
                            EmployeeToUpdate.BranchId = null;
                        }
                        break;
                    case EmployeeRole.DepartmentHead:
                        Department oldDepartment = await _context.Departments.FindAsync(EmployeeToUpdate.DepartmentId);
                        if (oldDepartment != null)
                        {
                            oldDepartment.DepartmentState = DepartmentState.Inactive;
                            DepartmentsWithModifiedState.Add(oldDepartment.Id);
                        }
                        EmployeeToUpdate.DepartmentId = null;
                        break;
                    case EmployeeRole.GeneralManager:
                        Company oldCompany = await _context.Companies.FindAsync(EmployeeToUpdate.CompanyId);
                        if (oldCompany != null)
                        {
                            oldCompany.CompanyState = CompanyState.Inactive;
                            CompaniesWithModifiedState.Add(oldCompany.Id);
                        }
                        EmployeeToUpdate.CompanyId = null;
                        break;
                    case EmployeeRole.ProjectManager:
                        Project oldProject = await _context.Projects.FindAsync(EmployeeToUpdate.ProjectId);
                        if (oldProject != null)
                        {
                            oldProject.ProjectState = ProjectState.Inactive;
                            ProjectsWithModifiedState.Add(oldProject.Id);
                        }
                        EmployeeToUpdate.ProjectId = null;
                        break;
                }
                //add new data
                switch (Employee.EmployeeRole)
                {
                    case EmployeeRole.Employee:
                        EmployeeToUpdate.BranchId = Employee.BranchId;
                        UpdateAssignments(SelectedAssignments, EmployeeToUpdate);
                        UpdateMentors(SelectedMentors, EmployeeToUpdate);
                        break;
                    case EmployeeRole.Mentor:
                        EmployeeToUpdate.BranchId = Employee.BranchId;
                        UpdateAssignments(SelectedAssignments, EmployeeToUpdate);
                        break;
                    case EmployeeRole.DepartmentHead:
                        UpdateMentors(SelectedMentors, EmployeeToUpdate);
                        if (Employee.DepartmentId != null)
                        {
                            Department department = await _context.Departments
                                .Include(d => d.DepartmentHead)
                                .Include(d => d.Company)
                                .FirstOrDefaultAsync(d => d.Id == Employee.DepartmentId);
                            if (department != null)
                            {
                                if (department.DepartmentHead != null)
                                {
                                    department.DepartmentHead.DepartmentId = null;
                                }
                                EmployeeToUpdate.DepartmentId = Employee.DepartmentId;
                                if (department.Company != null)
                                {
                                    if (Employee.EmployeeState == EmployeeState.Active && department.Company.CompanyState == CompanyState.Active)
                                    {
                                        if (department.DepartmentState != DepartmentState.Active)
                                        {
                                            department.DepartmentState = DepartmentState.Active;
                                            DepartmentsWithModifiedState.Add(department.Id);
                                        }
                                    }
                                    else
                                    {
                                        if (department.DepartmentState != DepartmentState.Inactive)
                                        {
                                            department.DepartmentState = DepartmentState.Inactive;
                                            DepartmentsWithModifiedState.Add(department.Id);
                                        }
                                    }
                                }
                                else
                                {
                                    if (department.DepartmentState != DepartmentState.Inactive)
                                    {
                                        department.DepartmentState = DepartmentState.Inactive;
                                        DepartmentsWithModifiedState.Add(department.Id);
                                    }
                                }
                            }
                        }
                        break;
                    case EmployeeRole.GeneralManager:
                        if (Employee.CompanyId != null)
                        {
                            Company company = await _context.Companies
                                .Include(g => g.GeneralManager)
                                .FirstOrDefaultAsync(g => g.Id == Employee.CompanyId);

                            if (company != null)
                            {
                                if (company.GeneralManager != null)
                                {
                                    company.GeneralManager.CompanyId = null;
                                }
                                EmployeeToUpdate.CompanyId = Employee.CompanyId;

                                if (Employee.EmployeeState == EmployeeState.Active)
                                {
                                    if (company.CompanyState != CompanyState.Active)
                                    {
                                        company.CompanyState = CompanyState.Active;
                                        CompaniesWithModifiedState.Add(company.Id);
                                    }
                                }
                                else
                                {
                                    if (company.CompanyState != CompanyState.Inactive)
                                    {
                                        company.CompanyState = CompanyState.Inactive;
                                        CompaniesWithModifiedState.Add(company.Id);
                                    }
                                }
                            }
                        }
                        break;
                    case EmployeeRole.ProjectManager:
                        UpdateMentors(SelectedMentors, EmployeeToUpdate);
                        if (Employee.ProjectId != null)
                        {
                            Project project = await _context.Projects
                                .Include(p => p.ProjectManager)
                                .Include(p => p.Department)
                                .FirstOrDefaultAsync(p => p.Id == Employee.ProjectId);
                            if (project != null)
                            {
                                if (project.ProjectManager != null)
                                {
                                    project.ProjectManager.ProjectId = null;
                                }
                                EmployeeToUpdate.ProjectId = Employee.ProjectId;
                                if (project.Department != null)
                                {
                                    if (Employee.EmployeeState == EmployeeState.Active && project.Department.DepartmentState == DepartmentState.Active)
                                    {
                                        if (project.ProjectState != ProjectState.Active)
                                        {
                                            project.ProjectState = ProjectState.Active;
                                            ProjectsWithModifiedState.Add(project.Id);
                                        }
                                    }
                                    else
                                    {
                                        if (project.ProjectState != ProjectState.Inactive)
                                        {
                                            project.ProjectState = ProjectState.Inactive;
                                            ProjectsWithModifiedState.Add(project.Id);
                                        }
                                    }
                                }
                                else
                                {
                                    if (project.ProjectState != ProjectState.Inactive)
                                    {
                                        project.ProjectState = ProjectState.Inactive;
                                        ProjectsWithModifiedState.Add(project.Id);
                                    }
                                }
                            }
                        }
                        break;
                }

            }

            if (FormFile != null)
            {
                var savedFileName = await _photoUpload.SaveAsync(FormFile.OpenReadStream(), FormFile.FileName);
                if (savedFileName != null)
                {
                    _photoUpload.DeleteIfProduction(EmployeeToUpdate.ProfilePicture);
                    EmployeeToUpdate.ProfilePicture = savedFileName;
                }
            }

            //Refactored because TryUpdateModelAsync fails while unit testing:
            //https://github.com/dotnet/AspNetCore.Docs/issues/14009
            //if (await TryUpdateModelAsync<Employee>(
            //    EmployeeToUpdate,
            //    "Employee",
            //    e => e.FirstName, e => e.LastName, e => e.EmployeeRole,
            //    e => e.EmployeeState, e => e.DateOfBirth))
            //return Page();

            EmployeeToUpdate.FirstName = Employee.FirstName;
            EmployeeToUpdate.LastName = Employee.LastName;
            EmployeeToUpdate.EmployeeRole = Employee.EmployeeRole;
            EmployeeToUpdate.EmployeeState = Employee.EmployeeState;
            EmployeeToUpdate.DateOfBirth = Employee.DateOfBirth;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            _stateCascade.UpdateCompanyDependants(CompaniesWithModifiedState);
            _stateCascade.UpdateDepartmentDependants(DepartmentsWithModifiedState);
            _stateCascade.UpdateProjectDependants(ProjectsWithModifiedState);
            _stateCascade.UpdateWhenParentIsNull();

            Role = EmployeeToUpdate.EmployeeRole;

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}",
                Role = $"{Role}"
            });
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        private void UpdateMentors(int[] SelectedMentors, Employee Employee)
        {
            {
                if (SelectedMentors == null || SelectedMentors.Length == 0)
                {
                    Employee.Mentors = new List<Employee>();
                    return;
                }

                var SelectedMentorsHS = new HashSet<int>(SelectedMentors);
                var EmployeeMentorsHS = new HashSet<int>
                    (Employee.Mentors.Select(s => s.Id));
                foreach (var mentor in _context.Employees)
                {
                    //If items are selected
                    if (SelectedMentorsHS.Contains(mentor.Id))
                    {
                        //If item not present
                        if (!EmployeeMentorsHS.Contains(mentor.Id))
                        {
                            Employee.Mentors.Add(mentor);
                            if (mentor.EmployeeRole == EmployeeRole.Employee)
                                mentor.EmployeeRole = EmployeeRole.Mentor;
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (EmployeeMentorsHS.Contains(mentor.Id))
                        {
                            var toRemove = Employee.Mentors.Single(s => s.Id == mentor.Id);
                            Employee.Mentors.Remove(toRemove);
                            if (toRemove.EmployeeRole == EmployeeRole.Mentor)
                                toRemove.EmployeeRole = EmployeeRole.Employee;
                        }
                    }
                }
            }
        }
        private void UpdateAssignments(int[] SelectedAssignments, Employee Employee)
        {
            {
                if (SelectedAssignments == null || SelectedAssignments.Length == 0)
                {
                    Employee.Assignments = new List<Assignment>();
                    return;
                }

                var SelectedAssignmentsHS = new HashSet<int>(SelectedAssignments);
                var EmployeeAssignmentsHS = new HashSet<int>
                    (Employee.Assignments.Select(s => s.Id));
                foreach (var assignment in _context.Assignments)
                {
                    //If items are selected
                    if (SelectedAssignmentsHS.Contains(assignment.Id))
                    {
                        //If item not present
                        if (!EmployeeAssignmentsHS.Contains(assignment.Id))
                        {
                            Employee.Assignments.Add(assignment);
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (EmployeeAssignmentsHS.Contains(assignment.Id))
                        {
                            var toRemove = Employee.Assignments.Single(s => s.Id == assignment.Id);
                            Employee.Assignments.Remove(toRemove);
                        }
                    }
                }
            }
        }
        public async Task<JsonResult> OnGetBranchStateAsync(string branchId)
        {
            return new JsonResult(await _stateLookup.GetBranchStateAsync(branchId));
        }
        public async Task<JsonResult> OnGetDepartmentAsync(string departmentId)
        {
            var mentors = await _mentorLookup.GetMentorsByDepartmentAsync(departmentId);
            return new JsonResult(mentors.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.FullName }));
        }
        public async Task<JsonResult> OnGetProjectAsync(string projectId)
        {
            var mentors = await _mentorLookup.GetMentorsByProjectAsync(projectId);
            return new JsonResult(mentors.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.FullName }));
        }
        public async Task<JsonResult> OnGetBranchAsync(string branchId)
        {
            var mentors = await _mentorLookup.GetMentorsByBranchAsync(branchId);
            return new JsonResult(mentors.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.FullName }));
        }
    }
}
