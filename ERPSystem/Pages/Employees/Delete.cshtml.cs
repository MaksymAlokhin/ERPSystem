using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Employees
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<DeleteModel> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public EmployeeRole Role { get; set; }

        public DeleteModel(ERPSystem.Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment, ILogger<DeleteModel> logger)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            _logger = logger;
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
                .Include(e => e.Assignments)
                .Include(e => e.Mentors)
                .Include(e => e.Project)
                .Include(e => e.Company)
                .Include(e => e.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(EmployeeRole Role, string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            List<int> DepartmentsWithModifiedState = new List<int>();
            List<int> CompaniesWithModifiedState = new List<int>();
            List<int> ProjectsWithModifiedState = new List<int>();

            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(e => e.Branch)
                .Include(e => e.Assignments)
                .Include(e => e.Mentors)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Employee != null)
            {
                //Delete photo file
                bool isProduction = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production";
                //if (isProduction)
                //{
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, @"images/avatars"); //webHost adds 'wwwroot'
                    var oldFile = Employee.ProfilePicture;
                    var fileToDelete = string.Empty;
                    if (!string.IsNullOrEmpty(oldFile))
                    {
                        fileToDelete = Path.Combine(uploadsFolder, oldFile);
                    }
                    //Delete photo file
                    if (System.IO.File.Exists(fileToDelete))
                        System.IO.File.Delete(fileToDelete);
                //}

                switch (Employee.EmployeeRole)
                {
                    case EmployeeRole.DepartmentHead:
                        if (Employee.DepartmentId != null)
                        {
                            Department department = await _context.Departments
                                .Include(d => d.DepartmentHead)
                                .FirstOrDefaultAsync(d => d.Id == Employee.DepartmentId);
                            if (department != null)
                            {
                                if (department.DepartmentState != DepartmentState.Inactive)
                                {
                                    department.DepartmentState = DepartmentState.Inactive;
                                    DepartmentsWithModifiedState.Add(department.Id);
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
                                if (company.CompanyState != CompanyState.Inactive)
                                {
                                    company.CompanyState = CompanyState.Inactive;
                                    CompaniesWithModifiedState.Add(company.Id);
                                }
                            }
                        }
                        break;
                    case EmployeeRole.ProjectManager:
                        if (Employee.ProjectId != null)
                        {
                            Project project = await _context.Projects
                                .Include(p => p.ProjectManager)
                                .FirstOrDefaultAsync(p => p.Id == Employee.ProjectId);
                            if (project != null)
                            {
                                if (project.ProjectState != ProjectState.Inactive)
                                {
                                    project.ProjectState = ProjectState.Inactive;
                                    ProjectsWithModifiedState.Add(project.Id);
                                }
                            }
                        }
                        break;
                }

                _logger.LogInformation("Employee deleted: {1}, {2}", Employee.LastName, Employee.FirstName);

                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();
            }

            Utility utility = new Utility(_context);
            utility.UpdateCompanyDependants(CompaniesWithModifiedState);
            utility.UpdateDepartmentDependants(DepartmentsWithModifiedState);
            utility.UpdateProjectDependants(ProjectsWithModifiedState);
            utility.UpdateWhenParentIsNull();

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}",
                Role = $"{Role}"
            });
        }
    }
}
