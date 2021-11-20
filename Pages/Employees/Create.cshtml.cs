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

namespace ERPSystem.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedMentors { get; set; }
        public SelectList MentorsSelectList { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }

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

            ViewData["BranchId"] = new SelectList(_context.Branches.OrderBy(b => b.Name), "Id", "Name");
            ViewData["CompanyId"] = new SelectList(_context.Companies.OrderBy(c => c.Name), "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments.OrderBy(d => d.Name), "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Projects.OrderBy(p => p.Name), "Id", "Id");

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

            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string sortOrder,
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
                _context.Employees.Load();
            }
            if (SelectedAssignments.Length > 0)
            {
                NewEmployee.Assignments = new List<Assignment>();
                _context.Assignments.Load();
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
                            e => e.DateOfBirth))
            {
                switch (Employee.EmployeeRole)
                {
                    case EmployeeRole.Employee:
                        NewEmployee.BranchId = Employee.BranchId;
                        UpdateAssignments(SelectedAssignments, NewEmployee);
                        UpdateMentors(SelectedMentors, NewEmployee);
                        break;
                    case EmployeeRole.Mentor:
                        NewEmployee.BranchId = Employee.BranchId;
                        UpdateAssignments(SelectedAssignments, NewEmployee);
                        break;
                    case EmployeeRole.DepartmentHead:
                        if (Employee.DepartmentId != null)
                        {
                            Department department = await _context.Departments.Include(d => d.DepartmentHead).FirstOrDefaultAsync(d => d.Id == Employee.DepartmentId);
                            department.DepartmentState = DepartmentState.Active;
                            if (department.DepartmentHead != null)
                            {
                                department.DepartmentHead.DepartmentId = null;
                            }
                        }
                        NewEmployee.DepartmentId = Employee.DepartmentId;
                        UpdateMentors(SelectedMentors, NewEmployee);
                        break;
                    case EmployeeRole.GeneralManager:
                        if (Employee.CompanyId != null)
                        {
                            Company company = await _context.Companies.Include(g => g.GeneralManager).FirstOrDefaultAsync(g => g.Id == Employee.CompanyId);
                            company.CompanyState = CompanyState.Active;
                            if (company.GeneralManager != null)
                            {
                                company.GeneralManager.CompanyId = null;
                            }
                        }
                        NewEmployee.CompanyId = Employee.CompanyId;
                        break;
                    case EmployeeRole.ProjectManager:
                        if (Employee.ProjectId != null)
                        {
                            Project project = await _context.Projects.Include(p => p.ProjectManager).FirstOrDefaultAsync(p => p.Id == Employee.ProjectId);
                            project.ProjectState = ProjectState.Active;
                            if (project.ProjectManager != null)
                            {
                                project.ProjectManager.ProjectId = null;
                            }
                        }
                        NewEmployee.ProjectId = Employee.ProjectId;
                        UpdateMentors(SelectedMentors, NewEmployee);
                        break;
                }

                _context.Employees.Add(NewEmployee);
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
        private void UpdateMentors(int[] SelectedMentors, Employee Employee)
        {
            {
                if (SelectedMentors == null)
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
                        }
                    }
                }
            }
        }
        private void UpdateAssignments(int[] SelectedAssignments, Employee Employee)
        {
            {
                if (SelectedAssignments == null)
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
    }
}
