using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Companies.Any())
            {
                context.AddRange(SeedCompany.data);
            }
            if (!context.Branches.Any())
            {
                context.AddRange(SeedBranch.data);
            }
            if (!context.Departments.Any())
            {
                context.AddRange(SeedDepartment.data);
            }
            if (!context.Projects.Any())
            {
                context.AddRange(SeedProject.data);
            }
            if (!context.DepartmentHeads.Any())
            {
                context.AddRange(SeedDepartmentHead.data);
            }
            if (!context.Mentors.Any())
            {
                context.AddRange(SeedMentor.data);
            }
            if (!context.Employees.Any())
            {
                context.AddRange(SeedEmployee.data);
            }
            if (!context.ProjectManagers.Any())
            {
                context.AddRange(SeedProjectManager.data);
            }
            if (!context.GeneralManagers.Any())
            {
                context.AddRange(SeedGeneralManager.data);
            }
            if (!context.Positions.Any())
            {
                context.AddRange(SeedPosition.data);
            }
            if (!context.Assignments.Any())
            {
                context.AddRange(SeedAssignment.data);
            }
            context.SaveChanges();
        }
    }
}
