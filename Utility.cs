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
            foreach(var employee in _context.Employees)
            {
                switch(employee.EmployeeRole)
                {
                    case EmployeeRole.Employee:
                    case EmployeeRole.Mentor:
                        if (employee.BranchId == null)
                            employee.EmployeeState = EmployeeState.Inactive;
                        break;
                    case EmployeeRole.DepartmentHead:
                        if (employee.DepartmentId == null)
                            employee.EmployeeState = EmployeeState.Inactive;
                        break;
                    case EmployeeRole.GeneralManager:
                        if (employee.CompanyId == null)
                            employee.EmployeeState = EmployeeState.Inactive;
                        break;
                    case EmployeeRole.ProjectManager:
                        if (employee.ProjectId == null)
                            employee.EmployeeState = EmployeeState.Inactive;
                        break;
                }
            }
            _context.Departments.Load();
            foreach (var company in _context.Companies)
            {
                if (company.GeneralManager == null)
                    company.CompanyState = CompanyState.Inactive;
                if (company.CompanyState == CompanyState.Inactive)
                {
                    foreach(var department in company.Departments)
                    {
                        department.DepartmentState = DepartmentState.Inactive;
                    }
                }
            }
            _context.Projects.Load();
            foreach (var department in _context.Departments)
            {
                if (department.DepartmentHead == null)
                    department.DepartmentState = DepartmentState.Inactive;
                if (department.CompanyId == null)
                    department.DepartmentState = DepartmentState.Inactive;
                if (department.DepartmentState == DepartmentState.Inactive)
                {
                    foreach (var project in department.Projects)
                    {
                        project.ProjectState = ProjectState.Inactive;
                    }
                }
            }
            foreach (var branch in _context.Branches)
            {
                if (branch.CompanyId == null)
                    branch.BranchState = BranchState.Inactive;
                if (branch.BranchState == BranchState.Inactive)
                {
                    foreach (var employee in branch.Employees)
                    {
                        if(employee.EmployeeRole == EmployeeRole.Employee 
                            || employee.EmployeeRole == EmployeeRole.Mentor)
                        employee.EmployeeState = EmployeeState.Inactive;
                    }
                }
            }
            _context.Positions.Load();
            foreach (var project in _context.Projects)
            {
                if (project.ProjectManager == null)
                    project.ProjectState = ProjectState.Inactive;
                if (project.DepartmentId == null)
                    project.ProjectState = ProjectState.Inactive;
                if (project.ProjectState == ProjectState.Inactive)
                {
                    foreach (var position in project.Positions)
                    {
                        position.PositionState = PositionState.Inactive;
                    }
                }
            }
            foreach (var assignment in _context.Assignments)
            {
                if (assignment.PositionId == null)
                    assignment.AssignmentState = AssignmentState.Inactive;
            }
            foreach (var position in _context.Positions)
            {
                if (position.ProjectId == null)
                    position.PositionState = PositionState.Inactive;
                if (position.PositionState == PositionState.Inactive)
                {
                    foreach (var assignment in position.Assignments)
                    {
                        assignment.AssignmentState = AssignmentState.Inactive;
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
