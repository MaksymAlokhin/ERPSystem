using ERPSystem.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ERPSystem.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@avenga.com");
                await EnsureClaim(serviceProvider, adminID, "Admin", ""); //Claim based authorization
                //await EnsureRole(serviceProvider, adminID, Constants.AdministratorsRole); //Role based authorization (discouraged by Microsoft)

                var employeeID = await EnsureUser(serviceProvider, testUserPw, "employee@avenga.com");
                await EnsureClaim(serviceProvider, employeeID, "Employee", ""); //Claim based authorization
                //await EnsureRole(serviceProvider, employeeID, Constants.EmployeesRole); //Role based authorization (discouraged by Microsoft)

                SeedDB(context);
            }
        }
        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }
        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
        private static async Task<IdentityResult> EnsureClaim(IServiceProvider serviceProvider, string id,
            string type, string value)
        {
            IdentityResult result = null;
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByIdAsync(id);
            Claim claim = new Claim(type, value);

            var claims = await userManager.GetClaimsAsync(user);
            if (!claims.Any(c => c.Type == claim.Type && c.Value == claim.Value))
            {
                result = await userManager.AddClaimAsync(user, claim);
            }
            return result;
        }

        public static void SeedDB(ApplicationDbContext context)
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
            if (!context.Employees.Any())
            {
                context.AddRange(SeedGeneralManager.data);
                context.AddRange(SeedMentor.data);
                context.AddRange(SeedDepartmentHead.data);
                context.AddRange(SeedProjectManager.data);
                context.AddRange(SeedEmployee.data);
            }
            if (!context.Positions.Any())
            {
                context.AddRange(SeedPosition.data);
            }
            if (!context.Assignments.Any())
            {
                context.AddRange(SeedAssignment.data);
            }
            if (!context.Reports.Any())
            {
                context.AddRange(SeedReport.data);
            }
            context.SaveChanges();
        }
    }
}