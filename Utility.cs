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
            Assignment assignment = await _context.Assignments.FindAsync(assignmentId);
            if (assignment != null)
            {
                if (assignment.StartDate > date)
                    return null;
                if (assignment.EndDate < date)
                    return new ReportData
                    {
                        hours = GetBusinessDays(assignment.StartDate, assignment.EndDate) * 8,
                        date = assignment.EndDate,
                        min = assignment.StartDate,
                        max = assignment.EndDate
                    };
                return new ReportData
                {
                    hours = GetBusinessDays(assignment.StartDate, date) * 8,
                    date = date,
                    min = assignment.StartDate,
                    max = assignment.EndDate
                };
            }
            return null;
        }
        public void UpdateDepartmentsState()
        {
            foreach (var department in _context.Departments)
            {
                if (department.CompanyId == null)
                    department.DepartmentState = DepartmentState.Inactive;
            }
            foreach (var company in _context.Companies)
            {
                if (company.CompanyState == CompanyState.Inactive
                    || company.CompanyState == CompanyState.Draft)
                {
                    if (company.Departments != null)
                    {
                        foreach (var department in company.Departments)
                        {
                            department.DepartmentState = DepartmentState.Inactive;
                        }
                    }
                }
            }
        }
        public void UpdateProjectsState()
        {
            foreach (var project in _context.Projects)
            {
                if (project.DepartmentId == null)
                    project.ProjectState = ProjectState.Inactive;
            }
            foreach (var department in _context.Departments)
            {
                if (department.DepartmentState == DepartmentState.Inactive
                    || department.DepartmentState == DepartmentState.Draft)
                {
                    if (department.Projects != null)
                    {
                        foreach (var project in department.Projects)
                        {
                            project.ProjectState = ProjectState.Inactive;
                        }
                    }
                }
            }
        }
        public void UpdateBranchesState()
        {
            foreach (var branch in _context.Branches)
            {
                if (branch.CompanyId == null)
                    branch.BranchState = BranchState.Inactive;
            }
            foreach (var company in _context.Companies)
            {
                if (company.CompanyState == CompanyState.Inactive)
                {
                    if (company.Branches != null)
                    {
                        foreach (var branch in company.Branches)
                        {
                            branch.BranchState = BranchState.Inactive;
                        }
                    }
                }
            }
        }
        //public void UpdateEmployeesState()
        //{
        //    foreach (var employee in _context.Employees
        //        .Where(e => e.EmployeeRole == EmployeeRole.Employee || e.EmployeeRole == EmployeeRole.Mentor))
        //    {
        //        if (employee.BranchId == null)
        //            employee.EmployeeState = EmployeeState.Inactive;
        //    }
        //    foreach (var branch in _context.Branches)
        //    {
        //        if (branch.BranchState == BranchState.Inactive)
        //        {
        //            if (branch.Employees != null)
        //            {
        //                foreach (var employee in branch.Employees)
        //                {
        //                    if (employee.EmployeeRole == EmployeeRole.Employee
        //                        || employee.EmployeeRole == EmployeeRole.Mentor)
        //                        employee.EmployeeState = EmployeeState.Inactive;
        //                }
        //            }
        //        }
        //    }
        //}
        public void UpdatePositionsState()
        {
            foreach (var position in _context.Positions)
            {
                if (position.ProjectId == null)
                    position.PositionState = PositionState.Inactive;
            }
            foreach (var project in _context.Projects)
            {
                if (project.ProjectState == ProjectState.Inactive)
                {
                    if (project.Positions != null)
                    {
                        foreach (var position in project.Positions)
                        {
                            position.PositionState = PositionState.Inactive;
                        }
                    }
                }
            }
        }
        public void UpdateAssignmentsState()
        {
            foreach (var assignment in _context.Assignments)
            {
                if (assignment.PositionId == null)
                    assignment.AssignmentState = AssignmentState.Inactive;
            }
            foreach (var position in _context.Positions)
            {
                if (position.PositionState == PositionState.Inactive)
                {
                    if (position.Assignments != null)
                    {
                        foreach (var assignment in position.Assignments)
                        {
                            assignment.AssignmentState = AssignmentState.Inactive;
                        }
                    }
                }
            }
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
