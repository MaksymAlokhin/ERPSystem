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

namespace BranchTest
{
    public abstract class BranchTests : IDisposable
    {
        public BranchTests(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            PageSize = 7;

            context = new ApplicationDbContext(contextOptions);

            SeedBranch(context);
        }
        public ApplicationDbContext context { get; private set; }
        private int PageSize;
        public void Dispose()
        {
            context.Dispose();
        }

        private void SeedBranch(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Branch WalmartNorthAmerica = new Branch
            {
                Name = "Walmart North America",
                BranchState = BranchState.Active
            };
            Branch WalmartEurope = new Branch
            {
                Name = "Walmart Europe",
                BranchState = BranchState.Active
            };
            Branch AmazonNorthAmerica = new Branch
            {
                Name = "Amazon North America",
                BranchState = BranchState.Active
            };
            Branch AmazonEurope = new Branch
            {
                Name = "Amazon Europe",
                BranchState = BranchState.Active
            };
            Branch AppleNorthAmerica = new Branch
            {
                Name = "Apple North America",
                BranchState = BranchState.Active
            };
            Branch AppleEurope = new Branch
            {
                Name = "Apple Europe",
                BranchState = BranchState.Active
            };
            Branch FordMotorNorthAmerica = new Branch
            {
                Name = "Ford Motor North America",
                BranchState = BranchState.Active
            };
            Branch FordMotorEurope = new Branch
            {
                Name = "Ford Motor Europe",
                BranchState = BranchState.Active
            };
            Branch FedExNorthAmerica = new Branch
            {
                Name = "FedEx North America",
                BranchState = BranchState.Active
            };
            Branch FedExEurope = new Branch
            {
                Name = "FedEx Europe",
                BranchState = BranchState.Active
            };
            context.Add(WalmartNorthAmerica);
            context.Add(WalmartEurope);
            context.Add(AmazonNorthAmerica);
            context.Add(AmazonEurope);
            context.Add(AppleNorthAmerica);
            context.Add(AppleEurope);
            context.Add(FordMotorNorthAmerica);
            context.Add(FordMotorEurope);
            context.Add(FedExNorthAmerica);
            context.Add(FedExEurope);
            context.SaveChanges();
        }

        //IndexModel
        [Fact]
        public async Task Branch_IndexModel_OnGetAsync_BranchesAreReturned()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Branches.IndexModel(context, config, logger);
            var expectedBranches = context.Branches;

            // Act
            await pageModel.OnGetAsync(null, null, null, null);

            // Assert
            var actualBranches = Assert.IsAssignableFrom<List<Branch>>(pageModel.Branch);
            Assert.Equal(
                expectedBranches.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualBranches.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Fact]
        public async Task Branch_IndexModel_OnGetAsync_BranchesAreReturnedInDescendingOrder()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Branches.IndexModel(context, config, logger);
            var expectedBranches = context.Branches;

            // Act
            await pageModel.OnGetAsync("name_desc", null, null, null);

            // Assert
            var actualBranches = Assert.IsAssignableFrom<List<Branch>>(pageModel.Branch);
            Assert.Equal(
                expectedBranches.OrderByDescending(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualBranches.OrderByDescending(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("e")]
        [InlineData("er")]
        public async Task Branch_IndexModel_OnGetAsync_FilteredListOfBranchesIsReturned(string searchString)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Branches.IndexModel(context, config, logger);
            IQueryable<Branch> expectedBranches = context.Branches;
            if (!String.IsNullOrEmpty(searchString))
            {
                expectedBranches = context.Branches.Where(c => c.Name.Contains(searchString)
                                                                 || c.Company.Name.Contains(searchString));
            }

            // Act
            await pageModel.OnGetAsync(null, searchString, null, null);

            // Assert
            var actualBranches = Assert.IsAssignableFrom<List<Branch>>(pageModel.Branch);
            Assert.Equal(
                expectedBranches.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualBranches.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task Branch_IndexModel_OnGetAsync_PaginationWorkingAsExpected(int pageIndex)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Branches.IndexModel(context, config, logger);
            List<Branch> expectedBranches = new List<Branch>();
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)context.Branches.Count() / (double)PageSize))
            {
                expectedBranches = context.Branches
                    .OrderBy(m => m.Name)
                    .Skip((pageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

            }
            else
            {
                expectedBranches = context.Branches
                    .OrderBy(m => m.Name)
                    .Take(PageSize)
                    .ToList(); ;
            }

            // Act
            await pageModel.OnGetAsync(null, null, null, pageIndex);

            // Assert
            var actualBranches = Assert.IsAssignableFrom<List<Branch>>(pageModel.Branch);
            Assert.Equal(
                expectedBranches.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualBranches.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //CreateModel
        [Fact]
        public async Task Branch_CreateModel_OnPostAsync_BranchIsAdded()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Branches.CreateModel(context, logger);
            var expectedBranch = new Branch 
            {
                Name = "Test Branch",
                BranchState = BranchState.Inactive
            };

            pageModel.Branch = expectedBranch;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, null);

            // Assert
            var actualBranch = await context.Branches.Where(c => c.Name == "Test Branch").FirstOrDefaultAsync();
            Assert.Equal(expectedBranch.Name, actualBranch.Name);
            Assert.Equal(expectedBranch.BranchState, actualBranch.BranchState);
            Assert.IsType<RedirectToPageResult>(result);
        }

        //CreateModel
        [Fact]
        public async Task Branch_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Branches.CreateModel(context, logger);
            var expectedBranch = new Branch
            {
                Name = "Test Branch",
                BranchState = BranchState.Inactive
            };
            pageModel.Branch = expectedBranch;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Branch_DeleteModel_OnGetAsync_BranchIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Branches.DeleteModel(context, logger);
            var testId = 1;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Branch>(pageModel.Branch);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Walmart North America", model.Name);
            Assert.Equal(BranchState.Active, model.BranchState);
        }

        //DeleteModel
        [Fact]
        public async Task Branch_DeleteModel_OnPostAsync_BranchIsDeleted_WhenBranchIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Branches.DeleteModel(context, logger);
            var testId = 1;
            var expectedBranches = context.Branches.Where(c => c.Id != testId).ToList();

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualBranches = await context.Branches.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedBranches.OrderBy(m => m.Id).Select(m => m.Name),
                actualBranches.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Branch_DeleteModel_OnPostAsync_NoBranchIsDeleted_WhenBranchIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Branches.DeleteModel(context, logger);
            var testId = 11;
            var expectedBranches = context.Branches;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualBranches = await context.Branches.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedBranches.OrderBy(m => m.Id).Select(m => m.Name),
                actualBranches.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //EditModel
        [Fact]
        public async Task Branch_EditModel_OnGetAsync_BranchIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.EditModel>>();
            var pageModel = new ERPSystem.Pages.Branches.EditModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Branch>(pageModel.Branch);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Walmart Europe", model.Name);
            Assert.Equal(BranchState.Active, model.BranchState);
        }

        //EditModel
        [Fact]
        public async Task Branch_EditModel_OnPostAsync_BranchIsModified()
        {
            // Arrange
            var testId = 1;
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.EditModel>>();
            var pageModel = new ERPSystem.Pages.Branches.EditModel(context, logger);
            var expectedBranch = context.Branches.FirstOrDefault(m => m.Id == testId);
            pageModel.Branch = expectedBranch;
            pageModel.Branch.Name = "Modified Entity";
            pageModel.Branch.BranchState = BranchState.Inactive;

            // Act
            var result = await pageModel.OnPostAsync(testId, null, null, null, null);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var model = Assert.IsAssignableFrom<Branch>(pageModel.Branch);
            Assert.Equal("Modified Entity", model.Name);
            Assert.Equal(BranchState.Inactive, model.BranchState);
        }

        //EditModel
        [Fact]
        public async Task Branch_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.EditModel>>();
            var pageModel = new ERPSystem.Pages.Branches.EditModel(context, logger);
            int testId = 1;
            var expectedBranch = context.Branches.FirstOrDefault(m => m.Id == testId);
            pageModel.Branch = expectedBranch;
            pageModel.Branch.Name = "Modified Entity";
            pageModel.Branch.BranchState = BranchState.Inactive;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(testId, null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DetailsModel
        [Fact]
        public async Task Branch_DetailsModel_OnGetAsync_BranchIsFetched_WhenBranchIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Branches.DetailsModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Branch>(pageModel.Branch);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Walmart Europe", model.Name);
            Assert.Equal(BranchState.Active, model.BranchState);
        }

        //DetailsModel
        [Fact]
        public async Task Branch_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenBranchIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Branches.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Branches.DetailsModel(context, logger);
            int testId = 11;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
