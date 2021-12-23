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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ERPSystem.Pages.Employees
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<CreateModel> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedMentors { get; set; }
        public List<SelectListItem> MentorsSelectList { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }
        public EmployeeRole Role { get; set; }
        public IFormFile FormFile { get; set; }
        private readonly string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tif", ".tiff" };

        public CreateModel(ERPSystem.Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment, ILogger<CreateModel> logger)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(EmployeeRole Role, string sortOrder,
            string currentFilter, int? pageIndex)
        {
            this.Role = Role;
            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            ViewData["BranchId"] = new SelectList(_context.Branches.OrderBy(b => b.Name), "Id", "Name");
            ViewData["CompanyId"] = new SelectList(_context.Companies.OrderBy(c => c.Name), "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments.OrderBy(d => d.Name), "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Projects.OrderBy(p => p.Name), "Id", "Name");

            //var MentorsQuery = _context.Employees
            //    .OrderBy(e => e.LastName)
            //    .ThenBy(e => e.FirstName)
            //    .AsNoTracking();
            //MentorsSelectList = new SelectList(MentorsQuery, "Id", "FullName"); //list, id, value

            MentorsSelectList = Enumerable.Empty<SelectListItem>().ToList();

            SelectedMentors = new List<int>();

            var AssignmentsQuery = _context.Assignments.OrderBy(e => e.Name).AsNoTracking();
            AssignmentsSelectList = new SelectList(AssignmentsQuery, "Id", "Name"); //list, id, value

            SelectedAssignments = new List<int>();

            Employee = new Employee();
            Employee.EmployeeRole = Role;
            if (Employee.EmployeeRole == EmployeeRole.Employee || Employee.EmployeeRole == EmployeeRole.Mentor)
                Employee.EmployeeState = EmployeeState.Inactive;
            else Employee.EmployeeState = EmployeeState.Active;
            Employee.DateOfBirth = Utility.GetRandomDate(DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-20));
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(EmployeeRole Role, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedMentors, int[] SelectedAssignments)
        {
            List<int> DepartmentsWithModifiedState = new List<int>();
            List<int> CompaniesWithModifiedState = new List<int>();
            List<int> ProjectsWithModifiedState = new List<int>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Employee NewEmployee = new Employee();

            if (SelectedMentors != null)
            {
                if (SelectedMentors.Length > 0)
                {
                    NewEmployee.Mentors = new List<Employee>();
                }
                foreach (var mentor in SelectedMentors)
                {
                    var foundMentor = await _context.Employees.FindAsync(mentor);
                    if (foundMentor != null)
                    {
                        NewEmployee.Mentors.Add(foundMentor);
                        if (foundMentor.EmployeeRole == EmployeeRole.Employee)
                            foundMentor.EmployeeRole = EmployeeRole.Mentor;
                    }
                }
            }
            if (SelectedAssignments != null)
            {
                if (SelectedAssignments.Length > 0)
                {
                    NewEmployee.Assignments = new List<Assignment>();
                }
                foreach (var assignment in SelectedAssignments)
                {
                    var foundAssignment = await _context.Assignments.FindAsync(assignment);
                    if (foundAssignment != null)
                    {
                        NewEmployee.Assignments.Add(foundAssignment);
                    }
                }
            }

            //Refactored because TryUpdateModelAsync fails while unit testing:
            //https://github.com/dotnet/AspNetCore.Docs/issues/14009
            //if (await TryUpdateModelAsync<Employee>(
            //                NewEmployee,
            //                "Employee",
            //                e => e.FirstName, e => e.LastName, e => e.EmployeeRole, e => e.EmployeeState,
            //                e => e.DateOfBirth, e => e.ProjectId, e => e.CompanyId, e => e.DepartmentId,
            //                e => e.BranchId))
            //return Page();

            NewEmployee.FirstName = Employee.FirstName;
            NewEmployee.LastName = Employee.LastName;
            NewEmployee.EmployeeRole = Employee.EmployeeRole;
            NewEmployee.EmployeeState = Employee.EmployeeState;
            NewEmployee.DateOfBirth = Employee.DateOfBirth;
            NewEmployee.ProjectId = Employee.ProjectId;
            NewEmployee.CompanyId = Employee.CompanyId;
            NewEmployee.DepartmentId = Employee.DepartmentId;
            NewEmployee.BranchId = Employee.BranchId;

            switch (NewEmployee.EmployeeRole)
            {
                case EmployeeRole.DepartmentHead:
                    if (NewEmployee.DepartmentId != null)
                    {
                        Department department = await _context.Departments
                            .Include(d => d.DepartmentHead)
                            .Include(d => d.Company)
                            .FirstOrDefaultAsync(d => d.Id == NewEmployee.DepartmentId);
                        if (department != null)
                        {
                            if (department.DepartmentHead != null)
                            {
                                department.DepartmentHead.DepartmentId = null;
                            }
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
                    if (NewEmployee.CompanyId != null)
                    {
                        Company company = await _context.Companies
                            .Include(g => g.GeneralManager)
                            .FirstOrDefaultAsync(g => g.Id == NewEmployee.CompanyId);
                        if (company != null)
                        {
                            if (company.GeneralManager != null)
                            {
                                company.GeneralManager.CompanyId = null;
                            }
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
                    if (NewEmployee.ProjectId != null)
                    {
                        Project project = await _context.Projects
                            .Include(p => p.ProjectManager)
                            .Include(p => p.Department)
                            .FirstOrDefaultAsync(p => p.Id == NewEmployee.ProjectId);
                        if (project != null)
                        {
                            if (project.ProjectManager != null)
                            {
                                project.ProjectManager.ProjectId = null;
                            }
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

            if (FormFile != null)
            {
                //Check permitted extensions for photo
                var ext = Path.GetExtension(FormFile.FileName).ToLowerInvariant();
                if (!string.IsNullOrEmpty(ext) || permittedExtensions.Contains(ext))
                {
                    //Get random filename for server storage
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, @"images/avatars"); //webHost adds 'wwwroot'
                    var trustedFileNameForFileStorage = Path.GetRandomFileName();
                    trustedFileNameForFileStorage = trustedFileNameForFileStorage.Substring(0, 8)
                        + trustedFileNameForFileStorage.Substring(9) + ext;
                    var filePath = Path.Combine(uploadsFolder, trustedFileNameForFileStorage);

                    //Copy data to a new file
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        await FormFile.CopyToAsync(fileStream);
                    }

                    //Update photo
                    NewEmployee.ProfilePicture = trustedFileNameForFileStorage;
                }
            }

            _context.Employees.Add(NewEmployee);
            await _context.SaveChangesAsync();

            Utility utility = new Utility(_context);
            utility.UpdateCompanyDependants(CompaniesWithModifiedState);
            utility.UpdateDepartmentDependants(DepartmentsWithModifiedState);
            utility.UpdateProjectDependants(ProjectsWithModifiedState);

            Role = NewEmployee.EmployeeRole;

            _logger.LogInformation("Employee created: {1}, {2}", NewEmployee.LastName, NewEmployee.FirstName);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}",
                Role = $"{NewEmployee.EmployeeRole}"
            });
        }
        public async Task<JsonResult> OnGetBranchStateAsync(string branchId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetBranchStateAsync(branchId);
        }
        public async Task<JsonResult> OnGetDepartmentAsync(string departmentId)
        {
            if (!string.IsNullOrWhiteSpace(departmentId))
            {
                if (Int32.TryParse(departmentId, out int id))
                {
                    Department department = await _context.Departments.FindAsync(id);
                    if (department != null)
                    {
                        Company company = await _context.Companies
                            .Include(c => c.Branches)
                            .ThenInclude(b => b.Employees)
                            .Where(c => c.Id == department.CompanyId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
                        if (company != null)
                        {
                            if (company.Branches.Count > 0)
                            {
                                List<Employee> mentors = new List<Employee>();
                                foreach (Branch branch in company.Branches)
                                {
                                    foreach (Employee mentor in branch.Employees)
                                        mentors.Add(mentor);
                                }
                                IEnumerable<SelectListItem> items = mentors
                                        .OrderBy(n => n.FullName)
                                        .Select(n =>
                                           new SelectListItem
                                           {
                                               Value = n.Id.ToString(),
                                               Text = n.FullName
                                           }).ToList();
                                return new JsonResult(items);
                            }
                        }
                    }
                }
            }
            return new JsonResult(
                new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "No Mentors" }
                });
        }
        public async Task<JsonResult> OnGetProjectAsync(string projectId)
        {
            if (!string.IsNullOrWhiteSpace(projectId))
            {
                if (Int32.TryParse(projectId, out int id))
                {
                    Project project = await _context.Projects.FindAsync(id);
                    if (project != null)
                    {
                        Department department = await _context.Departments.FindAsync(project.DepartmentId);
                        if (department != null)
                        {
                            Company company = await _context.Companies
                                .Include(c => c.Branches)
                                .ThenInclude(b => b.Employees)
                                .Where(c => c.Id == department.CompanyId)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
                            if (company != null)
                            {
                                if (company.Branches.Count > 0)
                                {
                                    List<Employee> mentors = new List<Employee>();
                                    foreach (Branch branch in company.Branches)
                                    {
                                        foreach (Employee mentor in branch.Employees)
                                            mentors.Add(mentor);
                                    }
                                    IEnumerable<SelectListItem> items = mentors
                                            .OrderBy(n => n.FullName)
                                            .Select(n =>
                                               new SelectListItem
                                               {
                                                   Value = n.Id.ToString(),
                                                   Text = n.FullName
                                               }).ToList();
                                    return new JsonResult(items);
                                }
                            }
                        }
                    }
                }
            }
            return new JsonResult(
                new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "No Mentors" }
                });
        }
        public async Task<JsonResult> OnGetBranchAsync(string branchId)
        {
            if (!string.IsNullOrWhiteSpace(branchId))
            {
                if (Int32.TryParse(branchId, out int id))
                {
                    Branch branch = await _context.Branches.FindAsync(id);
                    if (branch != null)
                    {
                        Company company = await _context.Companies
                            .Include(c => c.Branches)
                            .ThenInclude(b => b.Employees)
                            .Where(c => c.Id == branch.CompanyId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
                        if (company != null)
                        {
                            if (company.Branches.Count > 0)
                            {
                                List<Employee> mentors = new List<Employee>();
                                foreach (Branch brnch in company.Branches)
                                {
                                    foreach (Employee mentor in brnch.Employees)
                                        mentors.Add(mentor);
                                }
                                IEnumerable<SelectListItem> items = mentors
                                    .OrderBy(n => n.FullName)
                                    .Select(n =>
                                       new SelectListItem
                                       {
                                           Value = n.Id.ToString(),
                                           Text = n.FullName
                                       }).ToList();
                                return new JsonResult(items);
                            }
                        }
                    }
                }
            }

            return new JsonResult(
                new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "No Mentors" }
                });
        }
    }
}