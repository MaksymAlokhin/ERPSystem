using ERPSystem.Models;
using ERPSystem.Pages.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem
{
    public class Utility : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public Utility(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            var random = new Random();
            var range = Convert.ToInt32(endDate.Subtract(startDate).TotalDays);
            return startDate.AddDays(random.Next(range));
        }
        public static double GetBusinessDays(DateTime startD, DateTime endD)
        {
            double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
        }
        public async Task<ReportData> GetHours(DateTime date, int assignmentId)
        {
            double hoursPerWeek = 8.0;
            Assignment assignment = await _context.Assignments.FindAsync(assignmentId);
            if (assignment != null)
            {
                if (assignment.StartDate > date)
                    return null;
                if (assignment.EndDate < date)
                    return new ReportData
                    {
                        hours = GetBusinessDays(assignment.StartDate, assignment.EndDate) * hoursPerWeek * assignment.FTE,
                        date = assignment.EndDate,
                        min = assignment.StartDate,
                        max = assignment.EndDate
                    };
                return new ReportData
                {
                    hours = GetBusinessDays(assignment.StartDate, date) * hoursPerWeek * assignment.FTE,
                    date = date,
                    min = assignment.StartDate,
                    max = assignment.EndDate
                };
            }
            return null;
        }
        public void UpdateCompanyDependants(List<int> ids)
        {
            ids = ids.Distinct().ToList();

            foreach (int id in ids)
            {
                Company company = _context.Companies
                    .Include(b => b.Branches)
                        .ThenInclude(e => e.Employees)
                    .Include(d => d.Departments)
                        .ThenInclude(p => p.Projects)
                            .ThenInclude(p => p.Positions)
                                .ThenInclude(a => a.Assignments)
                    .FirstOrDefault(c => c.Id == id);
                if (company.CompanyState != CompanyState.Active)
                {
                    foreach (Branch branch in company.Branches)
                    {
                        branch.BranchState = BranchState.Inactive;
                        foreach (Employee employee in branch.Employees)
                            employee.EmployeeState = EmployeeState.Inactive;
                    }
                    foreach (Department department in company.Departments)
                    {
                        department.DepartmentState = DepartmentState.Inactive;
                        foreach (Project project in department.Projects)
                        {
                            project.ProjectState = ProjectState.Inactive;
                            foreach (Position position in project.Positions)
                            {
                                position.PositionState = PositionState.Inactive;
                                foreach (Assignment assignment in position.Assignments)
                                    assignment.AssignmentState = AssignmentState.Inactive;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Branch branch in company.Branches)
                    {
                        branch.BranchState = BranchState.Active;
                        foreach (Employee employee in branch.Employees)
                            employee.EmployeeState = EmployeeState.Active;
                    }
                    foreach (Department department in company.Departments)
                    {
                        _context.Entry(department).Reference(d => d.DepartmentHead).Load();
                        if (department.DepartmentHead != null && department.DepartmentHead.EmployeeState == EmployeeState.Active)
                            department.DepartmentState = DepartmentState.Active;
                        else department.DepartmentState = DepartmentState.Inactive;

                        foreach (Project project in department.Projects)
                        {
                            _context.Entry(project).Reference(p => p.ProjectManager).Load();
                            if (project.ProjectManager != null && project.ProjectManager.EmployeeState == EmployeeState.Active)
                                project.ProjectState = ProjectState.Active;
                            else project.ProjectState = ProjectState.Inactive;
                            foreach (Position position in project.Positions)
                            {
                                position.PositionState = PositionState.Active;
                                foreach (Assignment assignment in position.Assignments)
                                    assignment.AssignmentState = AssignmentState.Active;
                            }
                        }
                    }
                }
            }
            _context.SaveChanges();
        }
        public void UpdateBranchDependants(List<int> ids)
        {
            ids = ids.Distinct().ToList();
            foreach (int id in ids)
            {
                Branch branch = _context.Branches
                    .Include(e => e.Employees)
                    .FirstOrDefault(b => b.Id == id);

                if (branch.BranchState != BranchState.Active)
                {
                    foreach (Employee employee in branch.Employees)
                        employee.EmployeeState = EmployeeState.Inactive;
                }
                else
                {
                    foreach (Employee employee in branch.Employees)
                        employee.EmployeeState = EmployeeState.Active;
                }
            }
            _context.SaveChanges();
        }
        public void UpdateDepartmentDependants(List<int> ids)
        {
            ids = ids.Distinct().ToList();
            
            foreach (int id in ids)
            {
                Department department = _context.Departments
                    .Include(p => p.Projects)
                        .ThenInclude(p => p.Positions)
                            .ThenInclude(a => a.Assignments)
                    .FirstOrDefault(c => c.Id == id);

                if (department.DepartmentState != DepartmentState.Active)
                {
                    foreach (Project project in department.Projects)
                    {
                        project.ProjectState = ProjectState.Inactive;
                        foreach (Position position in project.Positions)
                        {
                            position.PositionState = PositionState.Inactive;
                            foreach (Assignment assignment in position.Assignments)
                                assignment.AssignmentState = AssignmentState.Inactive;
                        }
                    }
                }
                else
                {
                    foreach (Project project in department.Projects)
                    {
                        _context.Entry(project).Reference(p => p.ProjectManager).Load();
                        if (project.ProjectManager != null && project.ProjectManager.EmployeeState == EmployeeState.Active)
                            project.ProjectState = ProjectState.Active;
                        else project.ProjectState = ProjectState.Inactive;
                        foreach (Position position in project.Positions)
                        {
                            position.PositionState = PositionState.Active;
                            foreach (Assignment assignment in position.Assignments)
                                assignment.AssignmentState = AssignmentState.Active;
                        }
                    }
                }
            }
            _context.SaveChanges();
        }
        public void UpdateProjectDependants(List<int> ids)
        {
            ids = ids.Distinct().ToList();
            
            foreach (int id in ids)
            {
                Project project = _context.Projects
                    .Include(p => p.Positions)
                        .ThenInclude(a => a.Assignments)
                    .FirstOrDefault(c => c.Id == id);

                if (project.ProjectState != ProjectState.Active)
                {
                    foreach (Position position in project.Positions)
                    {
                        position.PositionState = PositionState.Inactive;
                        foreach (Assignment assignment in position.Assignments)
                            assignment.AssignmentState = AssignmentState.Inactive;
                    }
                }
                else
                {
                    foreach (Position position in project.Positions)
                    {
                        _context.Entry(position).Collection(p => p.Assignments).Load();
                        position.PositionState = PositionState.Active;
                        foreach (Assignment assignment in position.Assignments)
                            assignment.AssignmentState = AssignmentState.Active;
                    }
                }
            }
            _context.SaveChanges();
        }
        public void UpdatePositionDependants(List<int> ids)
        {
            ids = ids.Distinct().ToList();

            foreach (int id in ids)
            {
                Position position = _context.Positions
                    .Include(a => a.Assignments)
                    .FirstOrDefault(c => c.Id == id);

                if (position.PositionState != PositionState.Active)
                {
                    foreach (Assignment assignment in position.Assignments)
                        assignment.AssignmentState = AssignmentState.Inactive;
                }
                else
                {
                    foreach (Assignment assignment in position.Assignments)
                        assignment.AssignmentState = AssignmentState.Active;
                }
            }
            _context.SaveChanges();
        }
        public void UpdateWhenParentIsNull()
        {
            foreach (Company company in _context.Companies.Include(c => c.GeneralManager))
            {
                if (company.GeneralManager == null)
                {
                    _context.Entry(company).Collection(c => c.Branches).Load();
                    company.CompanyState = CompanyState.Inactive;
                    foreach (Branch branch in company.Branches)
                    {
                        _context.Entry(branch).Collection(b => b.Employees).Load();
                        branch.BranchState = BranchState.Inactive;
                        {
                            foreach (Employee employee in branch.Employees
                                .Where(e => e.EmployeeRole == EmployeeRole.Employee
                                    || e.EmployeeRole == EmployeeRole.Mentor))
                            {
                                employee.EmployeeState = EmployeeState.Inactive;
                            }
                        }
                    }
                    _context.Entry(company).Collection(c => c.Departments).Load();
                    foreach (Department department in company.Departments)
                    {
                        _context.Entry(department).Collection(d => d.Projects).Load();
                        department.DepartmentState = DepartmentState.Inactive;
                        foreach (Project project in department.Projects)
                        {
                            _context.Entry(project).Collection(p => p.Positions).Load();
                            project.ProjectState = ProjectState.Inactive;
                            foreach (Position position in project.Positions)
                            {
                                _context.Entry(position).Collection(p => p.Assignments).Load();
                                position.PositionState = PositionState.Inactive;
                                foreach (Assignment assignment in position.Assignments)
                                    assignment.AssignmentState = AssignmentState.Inactive;
                            }
                        }
                    }
                }
            }
            foreach (Branch branch in _context.Branches)
            {
                if (branch.CompanyId == null)
                {
                    _context.Entry(branch).Collection(b => b.Employees).Load();
                    branch.BranchState = BranchState.Inactive;
                    foreach (Employee employee in branch.Employees
                        .Where(e => e.EmployeeRole == EmployeeRole.Employee
                            || e.EmployeeRole == EmployeeRole.Mentor))
                    {
                        employee.EmployeeState = EmployeeState.Inactive;
                    }
                }
            }
            foreach (Department department in _context.Departments)
            {
                _context.Entry(department).Reference(d => d.DepartmentHead).Load();
                if (department.CompanyId == null || department.DepartmentHead == null)
                {
                    _context.Entry(department).Collection(d => d.Projects).Load();
                    department.DepartmentState = DepartmentState.Inactive;
                    foreach (Project project in department.Projects)
                    {
                        _context.Entry(project).Collection(p => p.Positions).Load();
                        project.ProjectState = ProjectState.Inactive;
                        foreach (Position position in project.Positions)
                        {
                            _context.Entry(position).Collection(p => p.Assignments).Load();
                            position.PositionState = PositionState.Inactive;
                            foreach (Assignment assignment in position.Assignments)
                                assignment.AssignmentState = AssignmentState.Inactive;
                        }
                    }
                }
            }
            foreach (Project project in _context.Projects)
            {
                _context.Entry(project).Reference(p => p.ProjectManager).Load();
                if (project.DepartmentId == null || project.ProjectManager == null)
                {
                    _context.Entry(project).Collection(p => p.Positions).Load();
                    project.ProjectState = ProjectState.Inactive;
                    foreach (Position position in project.Positions)
                    {
                        _context.Entry(position).Collection(p => p.Assignments).Load();
                        position.PositionState = PositionState.Inactive;
                        foreach (Assignment assignment in position.Assignments)
                            assignment.AssignmentState = AssignmentState.Inactive;
                    }
                }
            }
            foreach (Position position in _context.Positions)
            {
                if (position.ProjectId == null)
                {
                    _context.Entry(position).Collection(p => p.Assignments).Load();
                    position.PositionState = PositionState.Inactive;
                    foreach (Assignment assignment in position.Assignments)
                        assignment.AssignmentState = AssignmentState.Inactive;
                }
            }
            foreach (Assignment assignment in _context.Assignments)
            {
                if (assignment.PositionId == null)
                    assignment.AssignmentState = AssignmentState.Inactive;
            }
            _context.SaveChanges();
        }

        public async Task<JsonResult> GetEmployeeStateAsync(string employeeId)
        {
            if (!string.IsNullOrWhiteSpace(employeeId))
            {
                if (Int32.TryParse(employeeId, out int id))
                {
                    var employee = await _context.Employees.FindAsync(id);
                    if (employee != null)
                    {
                        if (employee.EmployeeState == EmployeeState.Active)
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
        public async Task<JsonResult> GetCompanyStateAsync(string companyId)
        {
            if (!string.IsNullOrWhiteSpace(companyId))
            {
                if (Int32.TryParse(companyId, out int id))
                {
                    var company = await _context.Companies.FindAsync(id);
                    if (company != null)
                    {
                        if (company.CompanyState == CompanyState.Active)
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
        public async Task<JsonResult> GetDepartmentStateAsync(string departmentId)
        {
            if (!string.IsNullOrWhiteSpace(departmentId))
            {
                if (Int32.TryParse(departmentId, out int id))
                {
                    var department = await _context.Departments.FindAsync(id);
                    if (department != null)
                    {
                        if (department.DepartmentState == DepartmentState.Active)
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
        public async Task<JsonResult> GetBranchStateAsync(string branchId)
        {
            if (!string.IsNullOrWhiteSpace(branchId))
            {
                if (Int32.TryParse(branchId, out int id))
                {
                    var branch = await _context.Branches.FindAsync(id);
                    if (branch != null)
                    {
                        if (branch.BranchState == BranchState.Active)
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
        public async Task<JsonResult> GetProjectStateAsync(string projectId)
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
        public async Task<JsonResult> GetPositionStateAsync(string positionId)
        {
            if (!string.IsNullOrWhiteSpace(positionId))
            {
                if (Int32.TryParse(positionId, out int id))
                {
                    var position = await _context.Positions.FindAsync(id);
                    if (position != null)
                    {
                        if (position.PositionState == PositionState.Active)
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
        public async Task<JsonResult> GetAssignmentStateAsync(string assignmentId)
        {
            if (!string.IsNullOrWhiteSpace(assignmentId))
            {
                if (Int32.TryParse(assignmentId, out int id))
                {
                    var assignment = await _context.Assignments.FindAsync(id);
                    if (assignment != null)
                    {
                        if (assignment.AssignmentState == AssignmentState.Active)
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
