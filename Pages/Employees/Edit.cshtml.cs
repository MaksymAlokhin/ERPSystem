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

namespace ERPSystem.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedMentors { get; set; }
        public SelectList MentorsSelectList { get; set; }
        public List<int> SelectedAssignments { get; set; }
        public SelectList AssignmentsSelectList { get; set; }

        public EditModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

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

            ViewData["BranchId"] = new SelectList(_context.Branches.OrderBy(b => b.Name), "Id", "Name");
            ViewData["CompanyId"] = new SelectList(_context.Companies.OrderBy(c => c.Name), "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments.OrderBy(d => d.Name), "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Projects.OrderBy(p => p.Name), "Id", "Name");

            var MenteesQuery = _context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).AsNoTracking();
            MentorsSelectList = new SelectList(MenteesQuery, "Id", "FullName"); //list, id, value

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
        public async Task<IActionResult> OnPostAsync(int? id, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedMentors, int[] SelectedAssignments)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var EmployeeToUpdate = await _context.Employees
                .Include(e => e.Branch)
                .Include(e => e.Company).ThenInclude(e => e.GeneralManager)
                .Include(e => e.Department).ThenInclude(e => e.DepartmentHead)
                .Include(e => e.Project).ThenInclude(e => e.ProjectManager)
                .Include(e => e.Assignments)
                .Include(e => e.Mentors)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (EmployeeToUpdate.DepartmentId != null)
            {
                Department department = await _context.Departments.FindAsync(EmployeeToUpdate.DepartmentId);
                department.DepartmentState = DepartmentState.Inactive;
                EmployeeToUpdate.DepartmentId = null;
            }
            if (EmployeeToUpdate.CompanyId != null)
            {
                Company company = await _context.Companies.FindAsync(EmployeeToUpdate.CompanyId);
                company.CompanyState = CompanyState.Inactive;
                EmployeeToUpdate.CompanyId = null;
            }
            if (EmployeeToUpdate.ProjectId != null)
            {
                Project project = await _context.Projects.FindAsync(EmployeeToUpdate.ProjectId);
                project.ProjectState = ProjectState.Inactive;
                EmployeeToUpdate.ProjectId = null;
            }
            if (EmployeeToUpdate.BranchId != null)
            {
                EmployeeToUpdate.BranchId = null;
            }

            if (EmployeeToUpdate.EmployeeRole == EmployeeRole.Employee ||
                EmployeeToUpdate.EmployeeRole == EmployeeRole.Mentor)
            {
                foreach (Assignment assignment in EmployeeToUpdate.Assignments)
                {
                    assignment.EmployeeId = null;
                }
            }
            foreach (Employee mentor in EmployeeToUpdate.Mentors)
            {
                EmployeeToUpdate.Mentors.Remove(mentor);
            }


            if (await TryUpdateModelAsync<Employee>(
                            EmployeeToUpdate,
                            "Employee",
                            e => e.FirstName, e => e.LastName, e => e.EmployeeRole, e => e.EmployeeState,
                            e => e.DateOfBirth))
            {

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
                        if (Employee.DepartmentId != null)
                        {
                            Department department = await _context.Departments.Include(d => d.DepartmentHead).FirstOrDefaultAsync(d => d.Id == Employee.DepartmentId);
                            department.DepartmentState = DepartmentState.Active;
                            if (department.DepartmentHead != null)
                            {
                                department.DepartmentHead.DepartmentId = null;
                            }
                        }
                        EmployeeToUpdate.DepartmentId = Employee.DepartmentId;
                        UpdateMentors(SelectedMentors, EmployeeToUpdate);
                        break;
                    case EmployeeRole.GeneralManager:
                        if(Employee.CompanyId != null)
                        {
                            Company company = await _context.Companies.Include(g => g.GeneralManager).FirstOrDefaultAsync(g => g.Id == Employee.CompanyId);
                            company.CompanyState = CompanyState.Active;
                            if (company.GeneralManager != null)
                            {
                                company.GeneralManager.CompanyId = null;
                            }
                        }
                        EmployeeToUpdate.CompanyId = Employee.CompanyId;
                        break;
                    case EmployeeRole.ProjectManager:
                        if(Employee.ProjectId != null)
                        {
                            Project project = await _context.Projects.Include(p => p.ProjectManager).FirstOrDefaultAsync(p => p.Id == Employee.ProjectId);
                            project.ProjectState = ProjectState.Active;
                            if(project.ProjectManager != null)
                            {
                                project.ProjectManager.ProjectId = null;
                            }
                        }
                        EmployeeToUpdate.ProjectId = Employee.ProjectId;
                        UpdateMentors(SelectedMentors, EmployeeToUpdate);
                        break;
                }
            }

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

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
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
