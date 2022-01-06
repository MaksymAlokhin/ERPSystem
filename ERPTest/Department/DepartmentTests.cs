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

namespace DepartmentTest
{
    public abstract class DepartmentTests : IDisposable
    {
        public DepartmentTests(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            PageSize = 7;

            context = new ApplicationDbContext(contextOptions);

            SeedDepartment(context);
        }
        public ApplicationDbContext context { get; private set; }
        private int PageSize;
        public void Dispose()
        {
            context.Dispose();
        }

        private void SeedDepartment(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Department WalmartMarketing = new Department
            {
                Name = "Walmart Marketing",
                DepartmentState = DepartmentState.Active

            };
            Department WalmartAccountingAndFinance = new Department
            {
                Name = "Walmart Accounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            Department AmazonMarketing = new Department
            {
                Name = "Amazon Marketing",
                DepartmentState = DepartmentState.Active
            };
            Department AmazonAccountingAndFinance = new Department
            {
                Name = "Amazon Accounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            Department AppleMarketing = new Department
            {
                Name = "Apple Marketing",
                DepartmentState = DepartmentState.Active
            };
            Department AppleAccountingAndFinance = new Department
            {
                Name = "Apple Accounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            Department FordMotorMarketing = new Department
            {
                Name = "Ford Motor Marketing",
                DepartmentState = DepartmentState.Active
            };
            Department FordMotorAccountingAndFinance = new Department
            {
                Name = "Ford Motor Accounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            Department FedExMarketing = new Department
            {
                Name = "FedExMarketing",
                DepartmentState = DepartmentState.Active
            };
            Department FedExAccountingAndFinance = new Department
            {
                Name = "FedExAccounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            context.Add(WalmartMarketing);
            context.Add(WalmartAccountingAndFinance);
            context.Add(AmazonMarketing);
            context.Add(AmazonAccountingAndFinance);
            context.Add(AppleMarketing);
            context.Add(AppleAccountingAndFinance);
            context.Add(FordMotorMarketing);
            context.Add(FordMotorAccountingAndFinance);
            context.Add(FedExMarketing);
            context.Add(FedExAccountingAndFinance);
            context.SaveChanges();
        }

        //IndexModel
        [Fact]
        public async Task Department_IndexModel_OnGetAsync_DepartmentsAreReturned()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Departments.IndexModel(context, config, logger);
            var expectedDepartments = context.Departments;

            // Act
            await pageModel.OnGetAsync(null, null, null, null);

            // Assert
            var actualDepartments = Assert.IsAssignableFrom<List<Department>>(pageModel.Department);
            Assert.Equal(
                expectedDepartments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualDepartments.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Fact]
        public async Task Department_IndexModel_OnGetAsync_DepartmentsAreReturnedInDescendingOrder()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Departments.IndexModel(context, config, logger);
            var expectedDepartments = context.Departments;

            // Act
            await pageModel.OnGetAsync("name_desc", null, null, null);

            // Assert
            var actualDepartments = Assert.IsAssignableFrom<List<Department>>(pageModel.Department);
            Assert.Equal(
                expectedDepartments.OrderByDescending(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualDepartments.OrderByDescending(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("e")]
        [InlineData("er")]
        public async Task Department_IndexModel_OnGetAsync_FilteredListOfDepartmentsIsReturned(string searchString)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Departments.IndexModel(context, config, logger);
            IQueryable<Department> expectedDepartments = context.Departments;
            if (!String.IsNullOrEmpty(searchString))
            {
                expectedDepartments = expectedDepartments.Where(c => c.Name.Contains(searchString)
                                                                 || c.Company.Name.Contains(searchString));
            }

            // Act
            await pageModel.OnGetAsync(null, searchString, null, null);

            // Assert
            var actualDepartments = Assert.IsAssignableFrom<List<Department>>(pageModel.Department);
            Assert.Equal(
                expectedDepartments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualDepartments.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task Department_IndexModel_OnGetAsync_PaginationWorkingAsExpected(int pageIndex)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Departments.IndexModel(context, config, logger);
            List<Department> expectedDepartments = new List<Department>();
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)context.Departments.Count() / (double)PageSize))
            {
                expectedDepartments = context.Departments
                    .OrderBy(m => m.Name)
                    .Skip((pageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

            }
            else
            {
                expectedDepartments = context.Departments
                    .OrderBy(m => m.Name)
                    .Take(PageSize)
                    .ToList(); ;
            }

            // Act
            await pageModel.OnGetAsync(null, null, null, pageIndex);

            // Assert
            var actualDepartments = Assert.IsAssignableFrom<List<Department>>(pageModel.Department);
            Assert.Equal(
                expectedDepartments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualDepartments.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //CreateModel
        [Fact]
        public async Task Department_CreateModel_OnPostAsync_DepartmentIsAdded()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Departments.CreateModel(context, logger);
            var expectedDepartment = new Department 
            {
                Name = "Test Department",
                DepartmentState = DepartmentState.Inactive
            };

            pageModel.Department = expectedDepartment;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, null, null);

            // Assert
            var actualDepartment = await context.Departments.Where(c => c.Name == "Test Department").FirstOrDefaultAsync();
            Assert.Equal(expectedDepartment.Name, actualDepartment.Name);
            Assert.Equal(expectedDepartment.DepartmentState, actualDepartment.DepartmentState);
            Assert.IsType<RedirectToPageResult>(result);
        }

        //CreateModel
        [Fact]
        public async Task Department_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Departments.CreateModel(context, logger);
            var expectedDepartment = new Department
            {
                Name = "Test Department",
                DepartmentState = DepartmentState.Inactive
            };
            pageModel.Department = expectedDepartment;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(null, null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Department_DeleteModel_OnGetAsync_DepartmentIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Departments.DeleteModel(context, logger);
            var testId = 1;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Department>(pageModel.Department);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Walmart Marketing", model.Name);
            Assert.Equal(DepartmentState.Active, model.DepartmentState);
        }

        //DeleteModel
        [Fact]
        public async Task Department_DeleteModel_OnPostAsync_DepartmentIsDeleted_WhenDepartmentIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Departments.DeleteModel(context, logger);
            var testId = 1;
            var expectedDepartments = context.Departments.Where(c => c.Id != testId).ToList();

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualDepartments = await context.Departments.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedDepartments.OrderBy(m => m.Id).Select(m => m.Name),
                actualDepartments.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Department_DeleteModel_OnPostAsync_NoDepartmentIsDeleted_WhenDepartmentIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Departments.DeleteModel(context, logger);
            var testId = 11;
            var expectedDepartments = context.Departments;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualDepartments = await context.Departments.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedDepartments.OrderBy(m => m.Id).Select(m => m.Name),
                actualDepartments.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //EditModel
        [Fact]
        public async Task Department_EditModel_OnGetAsync_DepartmentIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.EditModel>>();
            var pageModel = new ERPSystem.Pages.Departments.EditModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Department>(pageModel.Department);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Walmart Accounting and Finance", model.Name);
            Assert.Equal(DepartmentState.Active, model.DepartmentState);
        }

        //EditModel
        [Fact]
        public async Task Department_EditModel_OnPostAsync_DepartmentIsModified()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.EditModel>>();
            var testId = 1;
            var pageModel = new ERPSystem.Pages.Departments.EditModel(context, logger);
            var expectedDepartment = context.Departments.FirstOrDefault(m => m.Id == testId);
            pageModel.Department = expectedDepartment;
            pageModel.Department.Name = "Modified Entity";
            pageModel.Department.DepartmentState = DepartmentState.Inactive;

            // Act
            var result = await pageModel.OnPostAsync(testId, null, null, null, null, null);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var model = Assert.IsAssignableFrom<Department>(pageModel.Department);
            Assert.Equal("Modified Entity", model.Name);
            Assert.Equal(DepartmentState.Inactive, model.DepartmentState);
            var actualDepartment = context.Departments.FirstOrDefault(m => m.Id == testId);
            Assert.Equal("Modified Entity", actualDepartment.Name);
            Assert.Equal(DepartmentState.Inactive, actualDepartment.DepartmentState);
        }

        //EditModel
        [Fact]
        public async Task Department_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.EditModel>>();
            var pageModel = new ERPSystem.Pages.Departments.EditModel(context, logger);
            int testId = 1;
            var expectedDepartment = context.Departments.FirstOrDefault(m => m.Id == testId);
            pageModel.Department = expectedDepartment;
            pageModel.Department.Name = "Modified Entity";
            pageModel.Department.DepartmentState = DepartmentState.Inactive;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(testId, null, null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DetailsModel
        [Fact]
        public async Task Department_DetailsModel_OnGetAsync_DepartmentIsFetched_WhenDepartmentIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Departments.DetailsModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Department>(pageModel.Department);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Walmart Accounting and Finance", model.Name);
            Assert.Equal(DepartmentState.Active, model.DepartmentState);
        }

        //DetailsModel
        [Fact]
        public async Task Department_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenDepartmentIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Departments.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Departments.DetailsModel(context, logger);
            int testId = 11;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
