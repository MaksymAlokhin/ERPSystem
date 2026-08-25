using ERPSystem.Application.Interfaces;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ERPSystem.Infrastructure.Services
{
    public class StateCascadeService : IStateCascadeService
    {
        private readonly ApplicationDbContext _context;

        public StateCascadeService(ApplicationDbContext context)
        {
            _context = context;
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
                if (project != null)
                {
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
            foreach (Employee employee in _context.Employees)
            {
                if (employee.EmployeeRole == EmployeeRole.Employee || employee.EmployeeRole == EmployeeRole.Mentor)
                {
                    if (employee.BranchId == null)
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
    }
}
