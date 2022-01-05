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

namespace PositionTest
{
    public abstract class PositionTests : IDisposable
    {
        public PositionTests(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            PageSize = 7;

            context = new ApplicationDbContext(contextOptions);

            SeedPosition(context);
        }
        public ApplicationDbContext context { get; private set; }
        private int PageSize;
        public void Dispose()
        {
            context.Dispose();
        }

        private void SeedPosition(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Position pos0101 = new Position
            {
                Name = "Operations Manager",
                StartDate = DateTime.Parse("2020-12-30"),
                EndDate = DateTime.Parse("2023-03-05"),
                PositionState = PositionState.Active
            };
            Position pos0102 = new Position
            {
                Name = "Quality Control",
                StartDate = DateTime.Parse("2020-07-10"),
                EndDate = DateTime.Parse("2022-09-09"),
                PositionState = PositionState.Active
            };
            Position pos0103 = new Position
            {
                Name = "Accountant",
                StartDate = DateTime.Parse("2021-05-10"),
                EndDate = DateTime.Parse("2023-10-09"),
                PositionState = PositionState.Active
            };
            Position pos0104 = new Position
            {
                Name = "Office Manager",
                StartDate = DateTime.Parse("2021-06-03"),
                EndDate = DateTime.Parse("2022-03-14"),
                PositionState = PositionState.Active
            };
            Position pos0105 = new Position
            {
                Name = "Receptionist",
                StartDate = DateTime.Parse("2020-09-23"),
                EndDate = DateTime.Parse("2022-05-28"),
                PositionState = PositionState.Active
            };
            Position pos0106 = new Position
            {
                Name = "Supervisor",
                StartDate = DateTime.Parse("2020-07-28"),
                EndDate = DateTime.Parse("2022-08-03"),
                PositionState = PositionState.Active
            };
            Position pos0107 = new Position
            {
                Name = "Marketing Manager",
                StartDate = DateTime.Parse("2020-04-29"),
                EndDate = DateTime.Parse("2022-11-04"),
                PositionState = PositionState.Active
            };
            Position pos0108 = new Position
            {
                Name = "Purchasing Manager",
                StartDate = DateTime.Parse("2020-02-13"),
                EndDate = DateTime.Parse("2022-02-10"),
                PositionState = PositionState.Active
            };
            Position pos0109 = new Position
            {
                Name = "Shipping Manager",
                StartDate = DateTime.Parse("2021-08-18"),
                EndDate = DateTime.Parse("2022-04-01"),
                PositionState = PositionState.Active
            };
            context.Add(pos0101);
            context.Add(pos0102);
            context.Add(pos0103);
            context.Add(pos0104);
            context.Add(pos0105);
            context.Add(pos0106);
            context.Add(pos0107);
            context.Add(pos0108);
            context.Add(pos0109);
            context.SaveChanges();
        }

        //IndexModel
        [Fact]
        public async Task Position_IndexModel_OnGetAsync_PositionsAreReturned()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Positions.IndexModel(context, config, logger);
            var expectedPositions = context.Positions;

            // Act
            await pageModel.OnGetAsync(null, null, null, null);

            // Assert
            var actualPositions = Assert.IsAssignableFrom<List<Position>>(pageModel.Position);
            Assert.Equal(
                expectedPositions.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualPositions.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Fact]
        public async Task Position_IndexModel_OnGetAsync_PositionsAreReturnedInDescendingOrder()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Positions.IndexModel(context, config, logger);
            var expectedPositions = context.Positions;

            // Act
            await pageModel.OnGetAsync("name_desc", null, null, null);

            // Assert
            var actualPositions = Assert.IsAssignableFrom<List<Position>>(pageModel.Position);
            Assert.Equal(
                expectedPositions.OrderByDescending(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualPositions.OrderByDescending(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("e")]
        [InlineData("er")]
        public async Task Position_IndexModel_OnGetAsync_FilteredListOfPositionsIsReturned(string searchString)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Positions.IndexModel(context, config, logger);
            IQueryable<Position> expectedPositions = context.Positions;
            if (!String.IsNullOrEmpty(searchString))
            {
                expectedPositions = context.Positions.Where(s => s.Name.Contains(searchString)
                                           || s.Project.Name.Contains(searchString));
            }

            // Act
            await pageModel.OnGetAsync(null, searchString, null, null);

            // Assert
            var actualPositions = Assert.IsAssignableFrom<List<Position>>(pageModel.Position);
            Assert.Equal(
                expectedPositions.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualPositions.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task Position_IndexModel_OnGetAsync_PaginationWorkingAsExpected(int pageIndex)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Positions.IndexModel(context, config, logger);
            List<Position> expectedPositions = new List<Position>();
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)context.Positions.Count() / (double)PageSize))
            {
                expectedPositions = context.Positions
                    .OrderBy(m => m.Name)
                    .Skip((pageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

            }
            else
            {
                expectedPositions = context.Positions
                    .OrderBy(m => m.Name)
                    .Take(PageSize)
                    .ToList(); ;
            }

            // Act
            await pageModel.OnGetAsync(null, null, null, pageIndex);

            // Assert
            var actualPositions = Assert.IsAssignableFrom<List<Position>>(pageModel.Position);
            Assert.Equal(
                expectedPositions.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualPositions.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //CreateModel
        [Fact]
        public async Task Position_CreateModel_OnPostAsync_PositionIsAdded()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Positions.CreateModel(context, logger);
            var expectedPosition = new Position 
            {
                Name = "Test Position",
                StartDate = DateTime.Parse("2021-08-18"),
                EndDate = DateTime.Parse("2022-04-01"),
                PositionState = PositionState.Active
            };

            pageModel.Position = expectedPosition;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, null);

            // Assert
            var actualPosition = await context.Positions.Where(c => c.Name == "Test Position").FirstOrDefaultAsync();
            Assert.Equal(expectedPosition.Name, actualPosition.Name);
            Assert.Equal(expectedPosition.PositionState, actualPosition.PositionState);
            Assert.Equal(expectedPosition.StartDate, actualPosition.StartDate);
            Assert.Equal(expectedPosition.EndDate, actualPosition.EndDate);
            Assert.IsType<RedirectToPageResult>(result);
        }

        //CreateModel
        [Fact]
        public async Task Position_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Positions.CreateModel(context, logger);
            var expectedPosition = new Position
            {
                Name = "Test Position",
                StartDate = DateTime.Parse("2021-08-18"),
                EndDate = DateTime.Parse("2022-04-01"),
                PositionState = PositionState.Active
            };
            pageModel.Position = expectedPosition;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Position_DeleteModel_OnGetAsync_PositionIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Positions.DeleteModel(context, logger);
            var testId = 1;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Position>(pageModel.Position);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Operations Manager", model.Name);
            Assert.Equal(DateTime.Parse("2020-12-30"), model.StartDate);
            Assert.Equal(DateTime.Parse("2023-03-05"), model.EndDate);
            Assert.Equal(PositionState.Active, model.PositionState);
        }

    //DeleteModel
    [Fact]
        public async Task Position_DeleteModel_OnPostAsync_PositionIsDeleted_WhenPositionIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Positions.DeleteModel(context, logger);
            var testId = 1;
            var expectedPositions = context.Positions.Where(c => c.Id != testId).ToList();

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualPositions = await context.Positions.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedPositions.OrderBy(m => m.Id).Select(m => m.Name),
                actualPositions.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Position_DeleteModel_OnPostAsync_NoPositionIsDeleted_WhenPositionIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Positions.DeleteModel(context, logger);
            var testId = 11;
            var expectedPositions = context.Positions;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualPositions = await context.Positions.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedPositions.OrderBy(m => m.Id).Select(m => m.Name),
                actualPositions.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //EditModel
        [Fact]
        public async Task Position_EditModel_OnGetAsync_PositionIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.EditModel>>();
            var pageModel = new ERPSystem.Pages.Positions.EditModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Position>(pageModel.Position);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Quality Control", model.Name);
            Assert.Equal(DateTime.Parse("2020-07-10"), model.StartDate);
            Assert.Equal(DateTime.Parse("2022-09-09"), model.EndDate);
            Assert.Equal(PositionState.Active, model.PositionState);
        }

        //EditModel
        [Fact]
        public async Task Position_EditModel_OnPostAsync_PositionIsModified()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.EditModel>>();
            var testId = 1;
            var pageModel = new ERPSystem.Pages.Positions.EditModel(context, logger);
            var expectedPosition = context.Positions.FirstOrDefault(m => m.Id == testId);
            pageModel.Position = expectedPosition;
            pageModel.Position.Name = "Modified Entity";
            pageModel.Position.PositionState = PositionState.Inactive;

            // Act
            var result = await pageModel.OnPostAsync(testId, null, null, null, null);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var model = Assert.IsAssignableFrom<Position>(pageModel.Position);
            Assert.Equal("Modified Entity", model.Name);
            Assert.Equal(PositionState.Inactive, model.PositionState);
            Assert.Equal(DateTime.Parse("2020-12-30"), model.StartDate);
            Assert.Equal(DateTime.Parse("2023-03-05"), model.EndDate);
        }

        //EditModel
        [Fact]
        public async Task Position_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.EditModel>>();
            var pageModel = new ERPSystem.Pages.Positions.EditModel(context, logger);
            int testId = 1;
            var expectedPosition = context.Positions.FirstOrDefault(m => m.Id == testId);
            pageModel.Position = expectedPosition;
            pageModel.Position.Name = "Modified Entity";
            pageModel.Position.PositionState = PositionState.Inactive;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(testId, null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DetailsModel
        [Fact]
        public async Task Position_DetailsModel_OnGetAsync_PositionIsFetched_WhenPositionIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Positions.DetailsModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Position>(pageModel.Position);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Quality Control", model.Name);
            Assert.Equal(DateTime.Parse("2020-07-10"), model.StartDate);
            Assert.Equal(DateTime.Parse("2022-09-09"), model.EndDate);
            Assert.Equal(PositionState.Active, model.PositionState);
        }

        //DetailsModel
        [Fact]
        public async Task Position_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenPositionIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Positions.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Positions.DetailsModel(context, logger);
            int testId = 11;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
