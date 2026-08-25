using ERPSystem.Application.Interfaces;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace ERPSystem.Infrastructure.Services
{
    public class EntityStateLookupService : IEntityStateLookupService
    {
        private readonly ApplicationDbContext _context;

        public EntityStateLookupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetEmployeeStateAsync(string employeeId)
        {
            if (!string.IsNullOrWhiteSpace(employeeId) && Int32.TryParse(employeeId, out int id))
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee != null)
                    return employee.EmployeeState == EmployeeState.Active ? "Active" : "Inactive";
            }
            return "Inactive";
        }

        public async Task<string> GetCompanyStateAsync(string companyId)
        {
            if (!string.IsNullOrWhiteSpace(companyId) && Int32.TryParse(companyId, out int id))
            {
                var company = await _context.Companies.FindAsync(id);
                if (company != null)
                    return company.CompanyState == CompanyState.Active ? "Active" : "Inactive";
            }
            return "Inactive";
        }

        public async Task<string> GetDepartmentStateAsync(string departmentId)
        {
            if (!string.IsNullOrWhiteSpace(departmentId) && Int32.TryParse(departmentId, out int id))
            {
                var department = await _context.Departments.FindAsync(id);
                if (department != null)
                    return department.DepartmentState == DepartmentState.Active ? "Active" : "Inactive";
            }
            return "Inactive";
        }

        public async Task<string> GetBranchStateAsync(string branchId)
        {
            if (!string.IsNullOrWhiteSpace(branchId) && Int32.TryParse(branchId, out int id))
            {
                var branch = await _context.Branches.FindAsync(id);
                if (branch != null)
                    return branch.BranchState == BranchState.Active ? "Active" : "Inactive";
            }
            return "Inactive";
        }

        public async Task<string> GetProjectStateAsync(string projectId)
        {
            if (!string.IsNullOrWhiteSpace(projectId) && Int32.TryParse(projectId, out int id))
            {
                var project = await _context.Projects.FindAsync(id);
                if (project != null)
                    return project.ProjectState == ProjectState.Active ? "Active" : "Inactive";
            }
            return "Inactive";
        }

        public async Task<string> GetPositionStateAsync(string positionId)
        {
            if (!string.IsNullOrWhiteSpace(positionId) && Int32.TryParse(positionId, out int id))
            {
                var position = await _context.Positions.FindAsync(id);
                if (position != null)
                    return position.PositionState == PositionState.Active ? "Active" : "Inactive";
            }
            return "Inactive";
        }

        public async Task<string> GetAssignmentStateAsync(string assignmentId)
        {
            if (!string.IsNullOrWhiteSpace(assignmentId) && Int32.TryParse(assignmentId, out int id))
            {
                var assignment = await _context.Assignments.FindAsync(id);
                if (assignment != null)
                    return assignment.AssignmentState == AssignmentState.Active ? "Active" : "Inactive";
            }
            return "Inactive";
        }
    }
}
