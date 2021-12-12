//using System;
//using Xunit;
//using ERPSystem.Pages;
//using ERPSystem.Data;
//using ERPSystem.Models;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Microsoft.Extensions.Configuration;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.Json;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace ERPTest
//{
//    [Collection("InMemory Collection")]
//    public class InMemoryAssignmentTests
//    {
//        public InMemoryAssignmentTests(InMemorySharedDatabaseFixture fixture)
//        {
//            PageSize = fixture.PageSize;
//            Fixture = fixture;
//        }
//        public InMemorySharedDatabaseFixture Fixture;
//        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }
//        private int PageSize;

//        //IndexModel
//        [Fact]
//        public async Task Assignment_IndexModel_OnGetAsync_AssignmentsAreReturned()
//        {
//            // Arrange
//            var config = new ConfigurationBuilder().Build();
//            var pageModel = new ERPSystem.Pages.Assignments.IndexModel(Fixture.context, config);
//            var expectedAssignments = Fixture.context.Assignments;

//            // Act
//            await pageModel.OnGetAsync(null, null, null, null);

//            // Assert
//            var actualAssignments = Assert.IsAssignableFrom<List<Assignment>>(pageModel.Assignment);
//            Assert.Equal(
//                expectedAssignments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
//                actualAssignments.OrderBy(m => m.Name).Select(m => m.Name));
//        }

//        //IndexModel
//        [Fact]
//        public async Task Assignment_IndexModel_OnGetAsync_AssignmentsAreReturnedInDescendingOrder()
//        {
//            // Arrange
//            var config = new ConfigurationBuilder().Build();
//            var pageModel = new ERPSystem.Pages.Assignments.IndexModel(Fixture.context, config);
//            var expectedAssignments = Fixture.context.Assignments;

//            // Act
//            await pageModel.OnGetAsync("name_desc", null, null, null);

//            // Assert
//            var actualAssignments = Assert.IsAssignableFrom<List<Assignment>>(pageModel.Assignment);
//            Assert.Equal(
//                expectedAssignments.OrderByDescending(m => m.Name).Take(PageSize).Select(m => m.Name),
//                actualAssignments.OrderByDescending(m => m.Name).Select(m => m.Name));
//        }

//        //IndexModel
//        [Theory]
//        [InlineData("")]
//        [InlineData("a")]
//        [InlineData("e")]
//        [InlineData("er")]
//        public async Task Assignment_IndexModel_OnGetAsync_FilteredListOfAssignmentsIsReturned(string searchString)
//        {
//            // Arrange
//            var config = new ConfigurationBuilder().Build();
//            var pageModel = new ERPSystem.Pages.Assignments.IndexModel(Fixture.context, config);
//            var expectedAssignments = Fixture.context.Assignments.Where(c => c.Name.Contains(searchString)
//                                                             || c.Position.Name.Contains(searchString)
//                                                           || c.Employee.LastName.Contains(searchString)
//                                                           || c.Employee.FirstName.Contains(searchString));

//            // Act
//            await pageModel.OnGetAsync(null, searchString, null, null);

//            // Assert
//            var actualAssignments = Assert.IsAssignableFrom<List<Assignment>>(pageModel.Assignment);
//            Assert.Equal(
//                expectedAssignments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
//                actualAssignments.OrderBy(m => m.Name).Select(m => m.Name));
//        }

//        //IndexModel
//        [Theory]
//        [InlineData(0)]
//        [InlineData(1)]
//        [InlineData(2)]
//        [InlineData(3)]
//        [InlineData(int.MinValue)]
//        [InlineData(int.MaxValue)]
//        public async Task Assignment_IndexModel_OnGetAsync_Pagination(int pageIndex)
//        {
//            // Arrange
//            var config = new ConfigurationBuilder().Build();
//            var pageModel = new ERPSystem.Pages.Assignments.IndexModel(Fixture.context, config);
//            List<Assignment> expectedAssignments = new List<Assignment>();
//            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)Fixture.context.Assignments.Count() / (double)PageSize))
//            {
//                expectedAssignments = Fixture.context.Assignments
//                    .OrderBy(m => m.Name)
//                    .Skip((pageIndex - 1) * PageSize)
//                    .Take(PageSize)
//                    .ToList();

//            }
//            else
//            {
//                expectedAssignments = Fixture.context.Assignments
//                    .OrderBy(m => m.Name)
//                    .Take(PageSize)
//                    .ToList(); ;

//            }

//            // Act
//            await pageModel.OnGetAsync(null, null, null, pageIndex);

//            // Assert
//            var actualAssignments = Assert.IsAssignableFrom<List<Assignment>>(pageModel.Assignment);
//            Assert.Equal(
//                expectedAssignments.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
//                actualAssignments.OrderBy(m => m.Name).Select(m => m.Name));
//        }

//        //CreateModel
//        [Fact]
//        public async Task Assignment_CreateModel_OnPostAsync_AssignmentIsAdded()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.CreateModel(Fixture.context);
//            var expectedAssignment = new Assignment
//            {
//                Id = 10,
//                Name = "Test Assignment",
//                StartDate = DateTime.Parse("2020-12-30"),
//                EndDate = DateTime.Parse("2023-03-05"),
//                FTE = 0.5,
//                AssignmentState = AssignmentState.Inactive
//            };
//            pageModel.Assignment = expectedAssignment;

//            // Act
//            var result = await pageModel.OnPostAsync(null, null, null);

//            // Assert
//            var actualAssignment = await Fixture.context.Assignments.Where(c => c.Name == "Test Assignment").FirstOrDefaultAsync();
//            var object1Json = JsonSerializer.Serialize(expectedAssignment);
//            var object2Json = JsonSerializer.Serialize(actualAssignment);
//            Assert.Equal(object1Json, object2Json);
//            Assert.IsType<RedirectToPageResult>(result);
//        }

//        //CreateModel
//        [Fact]
//        public async Task Assignment_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.CreateModel(Fixture.context);
//            var expectedAssignment = new Assignment
//            {
//                Id = 10,
//                Name = "Test Assignment",
//                StartDate = DateTime.Parse("2020-12-30"),
//                EndDate = DateTime.Parse("2023-03-05"),
//                FTE = 0.5,
//                AssignmentState = AssignmentState.Inactive
//            };
//            pageModel.Assignment = expectedAssignment;

//            // Act
//            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
//            var result = await pageModel.OnPostAsync(null, null, null);

//            // Assert
//            Assert.IsType<PageResult>(result);
//        }

//        //DeleteModel
//        [Fact]
//        public async Task Assignment_DeleteModel_OnGetAsync_AssignmentIsFetched()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.DeleteModel(Fixture.context);
//            var testId = 1;

//            // Act
//            var result = await pageModel.OnGetAsync(null, null, null, testId);

//            // Assert
//            Assert.IsType<PageResult>(result);
//            var model = Assert.IsAssignableFrom<Assignment>(pageModel.Assignment);
//            Assert.Equal(testId, model.Id);
//            Assert.Equal("Walmart", model.Name);
//            Assert.Equal(AssignmentState.Active, model.AssignmentState);
//        }

//        //DeleteModel
//        [Fact]
//        public async Task Assignment_DeleteModel_OnPostAsync_AssignmentIsDeleted_WhenAssignmentIsFound()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.DeleteModel(Fixture.context);
//            var testId = 1;
//            var expectedAssignments = Fixture.context.Assignments.Where(c => c.Id != testId).ToList();

//            // Act
//            var result = await pageModel.OnPostAsync(null, null, null, testId);

//            // Assert
//            var actualAssignments = await Fixture.context.Assignments.AsNoTracking().ToListAsync();
//            Assert.Equal(
//                expectedAssignments.OrderBy(m => m.Id).Select(m => m.Name),
//                actualAssignments.OrderBy(m => m.Id).Select(m => m.Name));
//            Assert.IsType<RedirectToPageResult>(result);
//        }

//        //DeleteModel
//        [Fact]
//        public async Task Assignment_DeleteModel_OnPostAsync_NoAssignmentIsDeleted_WhenAssignmentIsNotFound()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.DeleteModel(Fixture.context);
//            var testId = 11;
//            var expectedAssignments = Fixture.context.Assignments;

//            // Act
//            var result = await pageModel.OnPostAsync(null, null, null, testId);

//            // Assert
//            var actualAssignments = await Fixture.context.Assignments.AsNoTracking().ToListAsync();
//            Assert.Equal(
//                expectedAssignments.OrderBy(m => m.Id).Select(m => m.Name),
//                actualAssignments.OrderBy(m => m.Id).Select(m => m.Name));
//            Assert.IsType<RedirectToPageResult>(result);
//        }

//        //EditModel
//        [Fact]
//        public async Task Assignment_EditModel_OnGetAsync_AssignmentIsFetched()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.EditModel(Fixture.context);
//            int testId = 2;

//            // Act
//            var result = await pageModel.OnGetAsync(null, null, null, testId);

//            // Assert
//            Assert.IsType<PageResult>(result);
//            var model = Assert.IsAssignableFrom<Assignment>(pageModel.Assignment);
//            Assert.Equal(testId, model.Id);
//            Assert.Equal("Amazon", model.Name);
//            Assert.Equal(AssignmentState.Inactive, model.AssignmentState);
//        }

//        //EditModel
//        [Fact]
//        public async Task Assignment_EditModel_OnPostAsync_AssignmentIsModified()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.EditModel(Fixture.context);
//            int testId = 1;
//            var expectedAssignment = new Assignment
//            {
//                Name = "Modified Entity",
//                AssignmentState = AssignmentState.Inactive,
//            };
//            pageModel.Assignment = expectedAssignment;

//            // Act
//            var result = await pageModel.OnPostAsync(testId, null, null, null);

//            // Assert
//            Assert.IsType<RedirectToPageResult>(result);
//            var model = Assert.IsAssignableFrom<Assignment>(pageModel.Assignment);
//            Assert.Equal("Modified Entity", model.Name);
//            Assert.Equal(AssignmentState.Inactive, model.AssignmentState);
//        }

//        //EditModel
//        [Fact]
//        public async Task Assignment_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.EditModel(Fixture.context);
//            int testId = 1;
//            var expectedAssignment = new Assignment
//            {
//                Name = "Modified Entity",
//                AssignmentState = AssignmentState.Inactive,
//            };
//            pageModel.Assignment = expectedAssignment;

//            // Act
//            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
//            var result = await pageModel.OnPostAsync(testId, null, null, null);

//            // Assert
//            Assert.IsType<PageResult>(result);
//        }

//        //DetailsModel
//        [Fact]
//        public async Task Assignment_DetailsModel_OnGetAsync_AssignmentIsFetched_WhenAssignmentIsFound()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.DetailsModel(Fixture.context);
//            int testId = 2;

//            // Act
//            var result = await pageModel.OnGetAsync(null, null, null, testId);

//            // Assert
//            Assert.IsType<PageResult>(result);
//            var model = Assert.IsAssignableFrom<Assignment>(pageModel.Assignment);
//            Assert.Equal(testId, model.Id);
//            Assert.Equal("Amazon", model.Name);
//            Assert.Equal(AssignmentState.Inactive, model.AssignmentState);
//        }

//        //DetailsModel
//        [Fact]
//        public async Task Assignment_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenAssignmentIsNotFound()
//        {
//            // Arrange
//            var pageModel = new ERPSystem.Pages.Assignments.DetailsModel(Fixture.context);
//            int testId = 11;

//            // Act
//            var result = await pageModel.OnGetAsync(null, null, null, testId);

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }
//    }
//}
