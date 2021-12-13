using System;
using Xunit;
using ERPSystem.Pages;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;

namespace EmployeeTest
{
    public abstract class EmployeeTests : IDisposable
    {
        public EmployeeTests(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            PageSize = 7;

            context = new ApplicationDbContext(contextOptions);

            SeedEmployee(context);
        }
        public ApplicationDbContext context { get; private set; }
        private int PageSize;
        public void Dispose()
        {
            context.Dispose();
        }

        private void SeedEmployee(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Employee e001 = new Employee
            {
                FirstName = "Beverly",
                LastName = "Diaz",
                DateOfBirth = DateTime.Parse("1993-09-27"),
                ProfilePicture = "female_001.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e002 = new Employee
            {
                FirstName = "Jescie",
                LastName = "Webb",
                DateOfBirth = DateTime.Parse("1987-09-27"),
                ProfilePicture = "female_002.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e003 = new Employee
            {
                FirstName = "Deacon",
                LastName = "Bass",
                DateOfBirth = DateTime.Parse("1990-11-18"),
                ProfilePicture = "male_001.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e004 = new Employee
            {
                FirstName = "Felix",
                LastName = "Chapman",
                DateOfBirth = DateTime.Parse("1995-09-11"),
                ProfilePicture = "male_002.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e005 = new Employee
            {
                FirstName = "Alma",
                LastName = "O'donnell",
                DateOfBirth = DateTime.Parse("1984-07-19"),
                ProfilePicture = "female_003.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e006 = new Employee
            {
                FirstName = "Dante",
                LastName = "Gordon",
                DateOfBirth = DateTime.Parse("1994-10-04"),
                ProfilePicture = "male_003.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e007 = new Employee
            {
                FirstName = "Clarke",
                LastName = "Conley",
                DateOfBirth = DateTime.Parse("1996-04-22"),
                ProfilePicture = "male_004.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e008 = new Employee
            {
                FirstName = "Myles",
                LastName = "Turner",
                DateOfBirth = DateTime.Parse("1993-04-16"),
                ProfilePicture = "male_005.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e009 = new Employee
            {
                FirstName = "Leroy",
                LastName = "Morrow",
                DateOfBirth = DateTime.Parse("1988-03-15"),
                ProfilePicture = "male_006.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e010 = new Employee
            {
                FirstName = "Charissa",
                LastName = "Conrad",
                DateOfBirth = DateTime.Parse("1997-07-30"),
                ProfilePicture = "female_004.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };

            context.Add(e001);
            context.Add(e002);
            context.Add(e003);
            context.Add(e004);
            context.Add(e005);
            context.Add(e006);
            context.Add(e007);
            context.Add(e008);
            context.Add(e009);
            context.Add(e010);
            context.SaveChanges();
        }

        //IndexModel
        [Fact]
        public async Task Employee_IndexModel_OnGetAsync_EmployeesAreReturned()
        {
            // Arrange
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Employees.IndexModel(context, config);
            var expectedEmployees = context.Employees;

            // Act
            await pageModel.OnGetAsync(EmployeeRole.Employee, null, null, null, null);

            // Assert
            var actualEmployees = Assert.IsAssignableFrom<List<Employee>>(pageModel.Employee);
            Assert.Equal(
                expectedEmployees.OrderBy(m => m.LastName).Take(PageSize).Select(m => m.LastName),
                actualEmployees.OrderBy(m => m.LastName).Select(m => m.LastName));
        }

        //IndexModel
        [Fact]
        public async Task Employee_IndexModel_OnGetAsync_EmployeesAreReturnedInDescendingOrder()
        {
            // Arrange
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Employees.IndexModel(context, config);
            var expectedEmployees = context.Employees;

            // Act
            await pageModel.OnGetAsync(EmployeeRole.Employee, "name_desc", null, null, null);

            // Assert
            var actualEmployees = Assert.IsAssignableFrom<List<Employee>>(pageModel.Employee);
            Assert.Equal(
                expectedEmployees.OrderByDescending(m => m.LastName).Take(PageSize).Select(m => m.LastName),
                actualEmployees.OrderByDescending(m => m.LastName).Select(m => m.LastName));
        }

        //IndexModel
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("e")]
        [InlineData("er")]
        public async Task Employee_IndexModel_OnGetAsync_FilteredListOfEmployeesIsReturned(string searchString)
        {
            // Arrange
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Employees.IndexModel(context, config);
            var expectedEmployees = context.Employees.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));

            // Act
            await pageModel.OnGetAsync(EmployeeRole.Employee, null, searchString, null, null);

            // Assert
            var actualEmployees = Assert.IsAssignableFrom<List<Employee>>(pageModel.Employee);
            Assert.Equal(
                expectedEmployees.OrderBy(m => m.LastName).Take(PageSize).Select(m => m.LastName),
                actualEmployees.OrderBy(m => m.LastName).Select(m => m.LastName));
        }

        //IndexModel
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task Employee_IndexModel_OnGetAsync_Pagination(int pageIndex)
        {
            // Arrange
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Employees.IndexModel(context, config);
            List<Employee> expectedEmployees = new List<Employee>();
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)context.Employees.Count() / (double)PageSize))
            {
                expectedEmployees = context.Employees
                    .OrderBy(m => m.LastName)
                    .Skip((pageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

            }
            else
            {
                expectedEmployees = context.Employees
                    .OrderBy(m => m.LastName)
                    .Take(PageSize)
                    .ToList(); ;
            }

            // Act
            await pageModel.OnGetAsync(EmployeeRole.Employee, null, null, null, pageIndex);

            // Assert
            var actualEmployees = Assert.IsAssignableFrom<List<Employee>>(pageModel.Employee);
            Assert.Equal(
                expectedEmployees.OrderBy(m => m.LastName).Take(PageSize).Select(m => m.LastName),
                actualEmployees.OrderBy(m => m.LastName).Select(m => m.LastName));
        }

        //CreateModel
        [Fact]
        public async Task Employee_CreateModel_OnPostAsync_EmployeeIsAdded()
        {
            // Arrange
            //IWebHostEnvironment hostEnvironment = new 
            var pageModel = new ERPSystem.Pages.Employees.CreateModel(context, null);
            var expectedEmployee = new Employee
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                DateOfBirth = DateTime.Parse("1983-03-02"),
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };

            pageModel.Employee = expectedEmployee;

            // Act
            var result = await pageModel.OnPostAsync(EmployeeRole.Employee, null, null, null, null, null);

            // Assert
            var actualEmployee = await context.Employees.Where(c => c.LastName == "Test Last Name").FirstOrDefaultAsync();
            Assert.Equal(expectedEmployee.LastName, actualEmployee.LastName);
            Assert.Equal(expectedEmployee.FirstName, actualEmployee.FirstName);
            Assert.Equal(expectedEmployee.DateOfBirth, actualEmployee.DateOfBirth);
            Assert.Equal(expectedEmployee.EmployeeState, actualEmployee.EmployeeState);
            Assert.Equal(expectedEmployee.EmployeeRole, actualEmployee.EmployeeRole);
            Assert.IsType<RedirectToPageResult>(result);
        }

        //CreateModel
        [Fact]
        public async Task Employee_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var pageModel = new ERPSystem.Pages.Employees.CreateModel(context, null);
            var expectedEmployee = new Employee
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                DateOfBirth = DateTime.Parse("1983-03-02"),
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            pageModel.Employee = expectedEmployee;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(EmployeeRole.Employee, null, null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Employee_DeleteModel_OnGetAsync_EmployeeIsFetched()
        {
            // Arrange
            var pageModel = new ERPSystem.Pages.Employees.DeleteModel(context, null);
            var testId = 1;

            // Act
            var result = await pageModel.OnGetAsync(EmployeeRole.Employee, null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Employee>(pageModel.Employee);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Diaz", model.LastName);
            Assert.Equal("Beverly", model.FirstName);
            Assert.Equal(DateTime.Parse("1993-09-27"), model.DateOfBirth);
            Assert.Equal(EmployeeRole.Employee, model.EmployeeRole);
            Assert.Equal(EmployeeState.Active, model.EmployeeState);
        }

        //DeleteModel
        [Fact]
        public async Task Employee_DeleteModel_OnPostAsync_EmployeeIsDeleted_WhenEmployeeIsFound()
        {
            // Arrange
            var pageModel = new ERPSystem.Pages.Employees.DeleteModel(context, null);
            var testId = 1;
            var expectedEmployees = context.Employees.Where(c => c.Id != testId).ToList();

            // Act
            var result = await pageModel.OnPostAsync(EmployeeRole.Employee, null, null, null, testId);

            // Assert
            var actualEmployees = await context.Employees.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedEmployees.OrderBy(m => m.Id).Select(m => m.LastName),
                actualEmployees.OrderBy(m => m.Id).Select(m => m.LastName));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Employee_DeleteModel_OnPostAsync_NoEmployeeIsDeleted_WhenEmployeeIsNotFound()
        {
            // Arrange
            var pageModel = new ERPSystem.Pages.Employees.DeleteModel(context, null);
            var testId = 11;
            var expectedEmployees = context.Employees;

            // Act
            var result = await pageModel.OnPostAsync(EmployeeRole.Employee, null, null, null, testId);

            // Assert
            var actualEmployees = await context.Employees.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedEmployees.OrderBy(m => m.Id).Select(m => m.LastName),
                actualEmployees.OrderBy(m => m.Id).Select(m => m.LastName));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //EditModel
        [Fact]
        public async Task Employee_EditModel_OnGetAsync_EmployeeIsFetched()
        {
            // Arrange
            var pageModel = new ERPSystem.Pages.Employees.EditModel(context, null);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(EmployeeRole.Employee, null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Employee>(pageModel.Employee);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Jescie", model.FirstName);
            Assert.Equal("Webb", model.LastName);
            Assert.Equal(DateTime.Parse("1987-09-27"), model.DateOfBirth);
            Assert.Equal(EmployeeState.Active, model.EmployeeState);
            Assert.Equal(EmployeeRole.Employee, model.EmployeeRole);
        }

        //EditModel
        [Fact]
        public async Task Employee_EditModel_OnPostAsync_EmployeeIsModified()
        {
            // Arrange
            var testId = 1;
            var pageModel = new ERPSystem.Pages.Employees.EditModel(context, null);
            var expectedEmployee = context.Employees.FirstOrDefault(m => m.Id == testId);
            pageModel.Employee = expectedEmployee;
            pageModel.Employee.LastName = "Modified Entity";
            pageModel.Employee.EmployeeState = EmployeeState.Inactive;

            // Act
            var result = await pageModel.OnPostAsync(testId, EmployeeRole.Employee, null, null, null, null, null);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var model = Assert.IsAssignableFrom<Employee>(pageModel.Employee);
            Assert.Equal("Modified Entity", model.LastName);
            Assert.Equal(EmployeeState.Inactive, model.EmployeeState);
        }

        //EditModel
        [Fact]
        public async Task Employee_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var pageModel = new ERPSystem.Pages.Employees.EditModel(context, null);
            int testId = 1;
            var expectedEmployee = context.Employees.FirstOrDefault(m => m.Id == testId);
            pageModel.Employee = expectedEmployee;
            pageModel.Employee.LastName = "Modified Entity";
            pageModel.Employee.EmployeeState = EmployeeState.Inactive;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(testId, EmployeeRole.Employee, null, null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DetailsModel
        [Fact]
        public async Task Employee_DetailsModel_OnGetAsync_EmployeeIsFetched_WhenEmployeeIsFound()
        {
            // Arrange
            var pageModel = new ERPSystem.Pages.Employees.DetailsModel(context);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(EmployeeRole.Employee, null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Employee>(pageModel.Employee);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Jescie", model.FirstName);
            Assert.Equal("Webb", model.LastName);
            Assert.Equal(DateTime.Parse("1987-09-27"), model.DateOfBirth);
            Assert.Equal(EmployeeState.Active, model.EmployeeState);
            Assert.Equal(EmployeeRole.Employee, model.EmployeeRole);
        }

        //DetailsModel
        [Fact]
        public async Task Employee_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenEmployeeIsNotFound()
        {
            // Arrange
            var pageModel = new ERPSystem.Pages.Employees.DetailsModel(context);
            int testId = 11;

            // Act
            var result = await pageModel.OnGetAsync(EmployeeRole.Employee, null, null, null, testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
