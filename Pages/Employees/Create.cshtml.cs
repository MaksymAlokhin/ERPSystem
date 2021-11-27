﻿using System;
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

namespace ERPSystem.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedMentors { get; set; }
        public SelectList MentorsSelectList { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }
        public EmployeeRole Role { get; set; }
        public IFormFile FormFile { get; set; }
        private readonly string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tif", ".tiff" };

        public CreateModel(ERPSystem.Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet(EmployeeRole Role, string sortOrder,
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

            var MentorsQuery = _context.Employees
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .AsNoTracking();
            MentorsSelectList = new SelectList(MentorsQuery, "Id", "FullName"); //list, id, value

            SelectedMentors = new List<int>();

            var AssignmentsQuery = _context.Assignments.OrderBy(e => e.Name).AsNoTracking();
            AssignmentsSelectList = new SelectList(AssignmentsQuery, "Id", "Name"); //list, id, value

            SelectedAssignments = new List<int>();

            Employee = new Employee();
            Employee.EmployeeState = EmployeeState.Inactive;
            Employee.DateOfBirth = Utility.GetRandomDate(DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-20));
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(EmployeeRole Role, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedMentors, int[] SelectedAssignments)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Employee NewEmployee = new Employee();

            if (SelectedMentors.Length > 0)
            {
                NewEmployee.Mentors = new List<Employee>();
            }
            if (SelectedAssignments.Length > 0)
            {
                NewEmployee.Assignments = new List<Assignment>();
            }

            foreach (var mentor in SelectedMentors)
            {
                var foundMentor = await _context.Employees.FindAsync(mentor);
                if (foundMentor != null)
                {
                    NewEmployee.Mentors.Add(foundMentor);
                }
            }

            foreach (var assignment in SelectedAssignments)
            {
                var foundAssignment = await _context.Assignments.FindAsync(assignment);
                if (foundAssignment != null)
                {
                    NewEmployee.Assignments.Add(foundAssignment);
                }
            }

            if (await TryUpdateModelAsync<Employee>(
                            NewEmployee,
                            "Employee",
                            e => e.FirstName, e => e.LastName, e => e.EmployeeRole, e => e.EmployeeState,
                            e => e.DateOfBirth, e => e.ProjectId, e => e.CompanyId, e => e.DepartmentId,
                            e => e.BranchId))
            {
                //Make dependants active or inactive
                switch (NewEmployee.EmployeeRole)
                {
                    case EmployeeRole.DepartmentHead:
                        if (NewEmployee.DepartmentId != null)
                        {
                            Department department = await _context.Departments
                                .Include(d => d.DepartmentHead)
                                .Include(d => d.Company)
                                .FirstOrDefaultAsync(d => d.Id == NewEmployee.DepartmentId);
                            if (department.Company.CompanyState == CompanyState.Active
                                && NewEmployee.EmployeeState == EmployeeState.Active)
                                department.DepartmentState = DepartmentState.Active;
                            else
                                department.DepartmentState = DepartmentState.Inactive;
                            if (department.DepartmentHead != null)
                            {
                                department.DepartmentHead.DepartmentId = null;
                            }
                        }
                        break;
                    case EmployeeRole.GeneralManager:
                        if (NewEmployee.CompanyId != null)
                        {
                            Company company = await _context.Companies
                                .Include(g => g.GeneralManager)
                                .FirstOrDefaultAsync(g => g.Id == NewEmployee.CompanyId);
                            if (NewEmployee.EmployeeState == EmployeeState.Active)
                                company.CompanyState = CompanyState.Active;
                            if (company.GeneralManager != null)
                            {
                                company.GeneralManager.CompanyId = null;
                            }
                        }
                        break;
                    case EmployeeRole.ProjectManager:
                        if (NewEmployee.ProjectId != null)
                        {
                            Project project = await _context.Projects
                                .Include(p => p.ProjectManager)
                                .Include(p => p.Positions)
                                .FirstOrDefaultAsync(p => p.Id == NewEmployee.ProjectId);
                            if (project.Department.DepartmentState == DepartmentState.Active
                                && NewEmployee.EmployeeState == EmployeeState.Active)
                                project.ProjectState = ProjectState.Active;
                            else project.ProjectState = ProjectState.Inactive;
                            if (project.ProjectManager != null)
                            {
                                project.ProjectManager.ProjectId = null;
                            }
                        }
                        break;
                    case EmployeeRole.Employee:
                    case EmployeeRole.Mentor:
                        if (NewEmployee.Assignments != null)
                        {
                            foreach (Assignment assignment in NewEmployee.Assignments)
                            {
                                _context.Entry(assignment)
                                    .Reference(a => a.Position)
                                    .Load();
                                if (assignment.Position.PositionState == PositionState.Active
                                    && NewEmployee.EmployeeState == EmployeeState.Active)
                                    assignment.AssignmentState = AssignmentState.Active;
                                else assignment.AssignmentState = AssignmentState.Inactive;
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
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, @"images\avatars"); //webHost adds 'wwwroot'
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
                utility.UpdateDepartmentsState();
                utility.UpdateBranchesState();
                utility.UpdateProjectsState();
                utility.UpdatePositionsState();
                utility.UpdateAssignmentsState();

                return RedirectToPage("./Index", new
                {
                    pageIndex = $"{pageIndex}",
                    sortOrder = $"{sortOrder}",
                    currentFilter = $"{currentFilter}",
                    Role = $"{NewEmployee.EmployeeRole}"
                });
            }
            return Page();
        }
    }
}