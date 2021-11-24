using ERPSystem.Models;
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
        public static async Task UpdateStateAsync(ERPSystem.Data.ApplicationDbContext _context)
        {
            _context.Employees.Load();
            _context.Departments.Load();
            foreach (var company in _context.Companies)
            {
                if (company.GeneralManager == null)
                    company.CompanyState = CompanyState.Inactive;
                else if (company.GeneralManager.EmployeeState == EmployeeState.Inactive)
                    company.CompanyState = CompanyState.Inactive;
                else
                    company.CompanyState = CompanyState.Active;
                if (company.CompanyState == CompanyState.Inactive)
                {
                    if (company.Departments != null)
                    {
                        foreach (var department in company.Departments)
                        {
                            department.DepartmentState = DepartmentState.Inactive;
                        }
                    }
                }
                else
                {
                    if (company.Departments != null)
                    {
                        foreach (var department in company.Departments)
                        {
                            if (department.DepartmentHead != null)
                            {
                                if (department.DepartmentHead.EmployeeState == EmployeeState.Active)
                                    department.DepartmentState = DepartmentState.Active;
                                else
                                    department.DepartmentState = DepartmentState.Inactive;
                            }
                        }
                    }
                }
            }
            _context.Projects.Load();
            foreach (var department in _context.Departments)
            {
                if (department.DepartmentHead == null)
                    department.DepartmentState = DepartmentState.Inactive;
                else if (department.DepartmentHead.EmployeeState == EmployeeState.Inactive)
                    department.DepartmentState = DepartmentState.Inactive;
                else if (department.CompanyId != null && department.Company.CompanyState == CompanyState.Active)
                    department.DepartmentState = DepartmentState.Active;
                else
                    department.DepartmentState = DepartmentState.Inactive;
                if (department.DepartmentState == DepartmentState.Inactive)
                {
                    if (department.Projects != null)
                    {
                        foreach (var project in department.Projects)
                        {
                            project.ProjectState = ProjectState.Inactive;
                        }
                    }
                }
                else
                {
                    if (department.Projects != null)
                    {
                        foreach (var project in department.Projects)
                        {
                            if (project.ProjectManager != null)
                            {
                                if (project.ProjectManager.EmployeeState == EmployeeState.Active)
                                    project.ProjectState = ProjectState.Active;
                                else
                                    project.ProjectState = ProjectState.Inactive;
                            }
                        }
                    }

                }
            }
            foreach (var branch in _context.Branches)
            {
                if (branch.CompanyId == null)
                    branch.BranchState = BranchState.Inactive;
                else if (branch.Company.CompanyState == CompanyState.Active)
                    branch.BranchState = BranchState.Active;
                else
                    branch.BranchState = BranchState.Inactive;
                if (branch.BranchState == BranchState.Inactive)
                {
                    if (branch.Employees != null)
                    {
                        foreach (var employee in branch.Employees)
                        {
                            if (employee.EmployeeRole == EmployeeRole.Employee
                                || employee.EmployeeRole == EmployeeRole.Mentor)
                                employee.EmployeeState = EmployeeState.Inactive;
                        }
                    }
                }
                else
                {
                    if (branch.Employees != null)
                    {
                        foreach (var employee in branch.Employees)
                        {
                            if (employee.EmployeeRole == EmployeeRole.Employee
                                || employee.EmployeeRole == EmployeeRole.Mentor)
                                employee.EmployeeState = EmployeeState.Active;
                        }
                    }
                }
            }
            _context.Positions.Load();
            foreach (var project in _context.Projects)
            {
                if (project.ProjectManager == null)
                    project.ProjectState = ProjectState.Inactive;
                else if (project.ProjectManager.EmployeeState == EmployeeState.Inactive)
                    project.ProjectState = ProjectState.Inactive;
                else if (project.DepartmentId != null & project.Department.DepartmentState == DepartmentState.Active)
                    project.ProjectState = ProjectState.Active;
                else
                    project.ProjectState = ProjectState.Inactive;
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
                else
                {
                    if (project.Positions != null)
                    {
                        foreach (var position in project.Positions)
                        {
                            position.PositionState = PositionState.Active;
                        }
                    }
                }
            }
            foreach (var position in _context.Positions)
            {
                if (position.ProjectId == null)
                    position.PositionState = PositionState.Inactive;
                else if (position.Project.ProjectState == ProjectState.Active)
                    position.PositionState = PositionState.Active;
                else
                    position.PositionState = PositionState.Inactive;
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
                else
                {
                    if (position.Assignments != null)
                    {
                        foreach (var assignment in position.Assignments)
                        {
                            assignment.AssignmentState = AssignmentState.Active;
                        }
                    }
                }
            }
            foreach (var assignment in _context.Assignments)
            {
                if (assignment.PositionId == null)
                    assignment.AssignmentState = AssignmentState.Inactive;
                else if (assignment.Position.PositionState == PositionState.Active)
                    assignment.AssignmentState = AssignmentState.Active;
                else
                    assignment.AssignmentState = AssignmentState.Inactive;
            }
            //foreach (var employee in _context.Employees)
            //{
            //    switch (employee.EmployeeRole)
            //    {
            //        case EmployeeRole.Employee:
            //        case EmployeeRole.Mentor:
            //            if (employee.BranchId == null)
            //                employee.EmployeeState = EmployeeState.Inactive;
            //            else if (employee.Branch.BranchState == BranchState.Active)
            //                employee.EmployeeState = EmployeeState.Active;
            //            else
            //                employee.EmployeeState = EmployeeState.Inactive;
            //            break;
            //        case EmployeeRole.DepartmentHead:
            //            if (employee.DepartmentId == null)
            //                employee.EmployeeState = EmployeeState.Inactive;
            //            else if (employee.Department.DepartmentState == DepartmentState.Active)
            //                employee.EmployeeState = EmployeeState.Active;
            //            else
            //                employee.EmployeeState = EmployeeState.Inactive;
            //            break;
            //        case EmployeeRole.GeneralManager:
            //            if (employee.CompanyId == null)
            //                employee.EmployeeState = EmployeeState.Inactive;
            //            else if (employee.Company.CompanyState == CompanyState.Active)
            //                employee.EmployeeState = EmployeeState.Active;
            //            else
            //                employee.EmployeeState = EmployeeState.Inactive;
            //            break;
            //        case EmployeeRole.ProjectManager:
            //            if (employee.ProjectId == null)
            //                employee.EmployeeState = EmployeeState.Inactive;
            //            else if (employee.Project.ProjectState == ProjectState.Active)
            //                employee.EmployeeState = EmployeeState.Active;
            //            else
            //                employee.EmployeeState = EmployeeState.Inactive;
            //            break;
            //    }
            //}
            await _context.SaveChangesAsync();
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
