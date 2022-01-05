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

namespace AssignmentTest
{
    public abstract class AssignmentTests : IDisposable
    {
        public AssignmentTests(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            PageSize = 7;

            context = new ApplicationDbContext(contextOptions);

            SeedAssignment(context);
        }
        public ApplicationDbContext context { get; private set; }
        private int PageSize;
        public void Dispose()
        {
            context.Dispose();
        }

        private void SeedAssignment(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Assignment as0101 = new Assignment
            {
                Name = "Operations Manager Assignment",
                StartDate = DateTime.Parse("2020-12-30"),
                EndDate = DateTime.Parse("2023-03-05"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0102 = new Assignment
            {
                Name = "Quality Control Assignment",
                StartDate = DateTime.Parse("2020-07-10"),
                EndDate = DateTime.Parse("2022-09-09"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active

            };
            Assignment as0103 = new Assignment
            {
                Name = "Accountant Assignment",
                StartDate = DateTime.Parse("2021-05-10"),
                EndDate = DateTime.Parse("2023-10-09"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0104 = new Assignment
            {
                Name = "Office Manager Assignment",
                StartDate = DateTime.Parse("2021-06-03"),
                EndDate = DateTime.Parse("2022-03-14"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0105 = new Assignment
            {
                Name = "Receptionist Assignment",
                StartDate = DateTime.Parse("2020-09-23"),
                EndDate = DateTime.Parse("2022-05-28"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0106 = new Assignment
            {
                Name = "Supervisor Assignment",
                StartDate = DateTime.Parse("2020-07-28"),
                EndDate = DateTime.Parse("2022-08-03"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0107 = new Assignment
            {
                Name = "Marketing Manager Assignment",
                StartDate = DateTime.Parse("2020-04-29"),
                EndDate = DateTime.Parse("2022-11-04"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0108 = new Assignment
            {
                Name = "Purchasing Manager Assignment",
                StartDate = DateTime.Parse("2020-02-13"),
                EndDate = DateTime.Parse("2022-02-10"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0109 = new Assignment
            {
                Name = "Shipping Manager Assignment",
                StartDate = DateTime.Parse("2021-08-18"),
                EndDate = DateTime.Parse("2022-04-01"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };

            context.Add(as0101);
            context.Add(as0102);
            context.Add(as0103);
            context.Add(as0104);
            context.Add(as0105);
            context.Add(as0106);
            context.Add(as0107);
            context.Add(as0108);
            context.Add(as0109);
            context.SaveChanges();
        }

        //IndexModel
        [Fact]
        public async Task Assignment_IndexModel_OnGetAsync_AssignmentsAreReturned()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Assignments.IndexModel(context, config, logger);
            var expectedAssignments = context.Assignments;

            // Act
            await pageModel.OnGetAsync(null, null, null, null);

            // Assert
            var actualAssignments = Assert.IsAssignableFrom<List<Assignment>>(pageModel.Assignment);
            Assert.Equal(
                expectedAssignments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualAssignments.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Fact]
        public async Task Assignment_IndexModel_OnGetAsync_AssignmentsAreReturnedInDescendingOrder()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Assignments.IndexModel(context, config, logger);
            var expectedAssignments = context.Assignments;

            // Act
            await pageModel.OnGetAsync("name_desc", null, null, null);

            // Assert
            var actualAssignments = Assert.IsAssignableFrom<List<Assignment>>(pageModel.Assignment);
            Assert.Equal(
                expectedAssignments.OrderByDescending(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualAssignments.OrderByDescending(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("e")]
        [InlineData("er")]
        public async Task Assignment_IndexModel_OnGetAsync_FilteredListOfAssignmentsIsReturned(string searchString)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.IndexModel>>(); 
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Assignments.IndexModel(context, config, logger);
            IQueryable<Assignment> expectedAssignments = context.Assignments;
            if (!String.IsNullOrEmpty(searchString))
            {
                expectedAssignments = expectedAssignments.Where(c => c.Name.Contains(searchString)
                                                                 || c.Position.Name.Contains(searchString)
                                                               || c.Employee.LastName.Contains(searchString)
                                                               || c.Employee.FirstName.Contains(searchString));
            }

            // Act
            await pageModel.OnGetAsync(null, searchString, null, null);

            // Assert
            var actualAssignments = Assert.IsAssignableFrom<List<Assignment>>(pageModel.Assignment);
            Assert.Equal(
                expectedAssignments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualAssignments.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task Assignment_IndexModel_OnGetAsync_PaginationWorkingAsExpected(int pageIndex)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Assignments.IndexModel(context, config, logger);
            List<Assignment> expectedAssignments = new List<Assignment>();
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)context.Assignments.Count() / (double)PageSize))
            {
                expectedAssignments = context.Assignments
                    .OrderBy(m => m.Name)
                    .Skip((pageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

            }
            else
            {
                expectedAssignments = context.Assignments
                    .OrderBy(m => m.Name)
                    .Take(PageSize)
                    .ToList(); ;

            }

            // Act
            await pageModel.OnGetAsync(null, null, null, pageIndex);

            // Assert
            var actualAssignments = Assert.IsAssignableFrom<List<Assignment>>(pageModel.Assignment);
            Assert.Equal(
                expectedAssignments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualAssignments.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //CreateModel
        [Fact]
        public async Task Assignment_CreateModel_OnPostAsync_AssignmentIsAdded()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Assignments.CreateModel(context, logger);
            var expectedAssignment = new Assignment
            {
                Name = "Test Assignment",
                StartDate = DateTime.Parse("2020-12-30"),
                EndDate = DateTime.Parse("2023-03-05"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Inactive
            };
            pageModel.Assignment = expectedAssignment;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null);

            // Assert
            var actualAssignment = await context.Assignments.Where(c => c.Name == "Test Assignment").FirstOrDefaultAsync();
            Assert.Equal(expectedAssignment.Name, actualAssignment.Name);
            Assert.Equal(expectedAssignment.StartDate, actualAssignment.StartDate);
            Assert.Equal(expectedAssignment.EndDate, actualAssignment.EndDate);
            Assert.Equal(expectedAssignment.FTE, actualAssignment.FTE);
            Assert.Equal(expectedAssignment.AssignmentState, actualAssignment.AssignmentState);
            Assert.IsType<RedirectToPageResult>(result);
        }

        //CreateModel
        [Fact]
        public async Task Assignment_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.CreateModel>>(); 
            var pageModel = new ERPSystem.Pages.Assignments.CreateModel(context, logger);
            var expectedAssignment = new Assignment
            {
                Id = 10,
                Name = "Test Assignment",
                StartDate = DateTime.Parse("2020-12-30"),
                EndDate = DateTime.Parse("2023-03-05"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Inactive
            };
            pageModel.Assignment = expectedAssignment;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Assignment_DeleteModel_OnGetAsync_AssignmentIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.DeleteModel>>(); 
            var pageModel = new ERPSystem.Pages.Assignments.DeleteModel(context, logger);
            var testId = 1;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Assignment>(pageModel.Assignment);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Operations Manager Assignment", model.Name);
            Assert.Equal(AssignmentState.Active, model.AssignmentState);
        }

        //DeleteModel
        [Fact]
        public async Task Assignment_DeleteModel_OnPostAsync_AssignmentIsDeleted_WhenAssignmentIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.DeleteModel>>(); 
            var pageModel = new ERPSystem.Pages.Assignments.DeleteModel(context, logger);
            var testId = 1;
            var expectedAssignments = context.Assignments.Where(c => c.Id != testId).ToList();

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualAssignments = await context.Assignments.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedAssignments.OrderBy(m => m.Id).Select(m => m.Name),
                actualAssignments.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Assignment_DeleteModel_OnPostAsync_NoAssignmentIsDeleted_WhenAssignmentIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Assignments.DeleteModel(context, logger);
            var testId = 11;
            var expectedAssignments = context.Assignments;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualAssignments = await context.Assignments.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedAssignments.OrderBy(m => m.Id).Select(m => m.Name),
                actualAssignments.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //EditModel
        [Fact]
        public async Task Assignment_EditModel_OnGetAsync_AssignmentIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.EditModel>>();
            var pageModel = new ERPSystem.Pages.Assignments.EditModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Assignment>(pageModel.Assignment);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Quality Control Assignment", model.Name);
            Assert.Equal(AssignmentState.Active, model.AssignmentState);
        }

        //EditModel
        [Fact]
        public async Task Assignment_EditModel_OnPostAsync_AssignmentIsModified()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.EditModel>>();
            var testId = 1;
            var pageModel = new ERPSystem.Pages.Assignments.EditModel(context, logger);
            var expectedAssignment = context.Assignments.FirstOrDefault(m => m.Id == testId);
            pageModel.Assignment = expectedAssignment;
            pageModel.Assignment.Name = "Modified Entity";
            pageModel.Assignment.AssignmentState = AssignmentState.Inactive;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var model = Assert.IsAssignableFrom<Assignment>(pageModel.Assignment);
            Assert.Equal("Modified Entity", model.Name);
            Assert.Equal(AssignmentState.Inactive, model.AssignmentState);
        }

        //EditModel
        [Fact]
        public async Task Assignment_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.EditModel>>();
            var pageModel = new ERPSystem.Pages.Assignments.EditModel(context, logger);
            int testId = 1;
            var expectedAssignment = context.Assignments.FirstOrDefault(m => m.Id == testId);
            pageModel.Assignment = expectedAssignment;
            pageModel.Assignment.Name = "Modified Entity";
            pageModel.Assignment.AssignmentState = AssignmentState.Inactive;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DetailsModel
        [Fact]
        public async Task Assignment_DetailsModel_OnGetAsync_AssignmentIsFetched_WhenAssignmentIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Assignments.DetailsModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Assignment>(pageModel.Assignment);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Quality Control Assignment", model.Name);
            Assert.Equal(AssignmentState.Active, model.AssignmentState);
        }

        //DetailsModel
        [Fact]
        public async Task Assignment_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenAssignmentIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Assignments.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Assignments.DetailsModel(context, logger);
            int testId = 11;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
