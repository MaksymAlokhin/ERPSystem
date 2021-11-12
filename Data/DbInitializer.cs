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

            if (!context.Mentors.Any())
            {
                context.AddRange(SeedMentor.data);
            }

            if (!context.Employees.Any())
            {
                context.AddRange(SeedEmployee.data);
            }

            if (!context.DepartmentHeads.Any())
            {
                context.AddRange(SeedDepartmentHead.data);
            }

            if (!context.GeneralManagers.Any())
            {
                context.AddRange(SeedGeneralManager.data);
            }

            if (!context.ProjectManagers.Any())
            {
                context.AddRange(SeedProjectManager.data);
            }

            context.SaveChanges();
        }
    }
}
