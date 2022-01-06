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

namespace ReportTest
{
    public abstract class ReportTests : IDisposable
    {
        public ReportTests(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            PageSize = 7;

            context = new ApplicationDbContext(contextOptions);

            SeedReport(context);
        }
        public ApplicationDbContext context { get; private set; }
        private int PageSize;
        public void Dispose()
        {
            context.Dispose();
        }

        private void SeedReport(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Report r001 = new Report
            {
                Hours = 160.0,
                Date = DateTime.Parse("2021-09-07"),
                ReportState = ReportState.Approved
            };
            Report r002 = new Report
            {
                Hours = 216.0,
                Date = DateTime.Parse("2021-06-13"),
                ReportState = ReportState.Approved
            };
            Report r003 = new Report
            {
                Hours = 88.0,
                Date = DateTime.Parse("2021-08-29"),
                ReportState = ReportState.Approved
            };
            Report r004 = new Report
            {
                Hours = 56.0,
                Date = DateTime.Parse("2021-06-23"),
                ReportState = ReportState.Submitted
            };
            Report r005 = new Report
            {
                Hours = 144.0,
                Date = DateTime.Parse("2021-02-26"),
                ReportState = ReportState.Submitted
            };
            Report r006 = new Report
            {
                Hours = 24.0,
                Date = DateTime.Parse("2021-11-17"),
                ReportState = ReportState.Approved
            };
            Report r007 = new Report
            {
                Hours = 40.0,
                Date = DateTime.Parse("2021-02-16"),
                ReportState = ReportState.Approved
            };
            Report r008 = new Report
            {
                Hours = 72.0,
                Date = DateTime.Parse("2021-01-05"),
                ReportState = ReportState.Approved
            };
            Report r009 = new Report
            {
                Hours = 248.0,
                Date = DateTime.Parse("2021-09-17"),
                ReportState = ReportState.Submitted
            };
            context.Add(r001);
            context.Add(r002);
            context.Add(r003);
            context.Add(r004);
            context.Add(r005);
            context.Add(r006);
            context.Add(r007);
            context.Add(r008);
            context.Add(r009);
            context.SaveChanges();
        }
        //IndexModel
        [Fact]
        public async Task Report_IndexModel_OnGetAsync_ReportsAreReturned()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Reports.IndexModel(context, config, logger);
            var expectedReports = context.Reports;

            // Act
            await pageModel.OnGetAsync(null, null, null, null);

            // Assert
            var actualReports = Assert.IsAssignableFrom<List<Report>>(pageModel.Report);
            Assert.Equal(
                expectedReports.OrderBy(m => m.Date).Take(PageSize).Select(m => m.Date),
                actualReports.OrderBy(m => m.Date).Select(m => m.Date));
        }

        //IndexModel
        [Fact]
        public async Task Report_IndexModel_OnGetAsync_ReportsAreReturnedInDescendingOrder()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Reports.IndexModel(context, config, logger);
            var expectedReports = context.Reports;

            // Act
            await pageModel.OnGetAsync("date_desc", null, null, null);

            // Assert
            var actualReports = Assert.IsAssignableFrom<List<Report>>(pageModel.Report);
            Assert.Equal(
                expectedReports.OrderByDescending(m => m.Date).Take(PageSize).Select(m => m.Date),
                actualReports.OrderByDescending(m => m.Date).Select(m => m.Date));
        }

        //IndexModel
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("e")]
        [InlineData("er")]
        public async Task Report_IndexModel_OnGetAsync_FilteredListOfReportsIsReturned(string searchString)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Reports.IndexModel(context, config, logger);
            IQueryable<Report> expectedReports = context.Reports;
            if (!String.IsNullOrEmpty(searchString))
            {
                expectedReports = expectedReports.Where(s => s.Assignment.Name.Contains(searchString)
                                       || s.Assignment.Employee.LastName.Contains(searchString)
                                       || s.Assignment.Employee.FirstName.Contains(searchString));
            }

            // Act
            await pageModel.OnGetAsync(null, null, searchString, null);

            // Assert
            var actualReports = Assert.IsAssignableFrom<List<Report>>(pageModel.Report);
            Assert.Equal(
                expectedReports.OrderBy(m => m.Date).Take(PageSize).Select(m => m.Date),
                actualReports.OrderBy(m => m.Date).Select(m => m.Date));
        }

        //IndexModel
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task Report_IndexModel_OnGetAsync_PaginationWorkingAsExpected(int pageIndex)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Reports.IndexModel(context, config, logger);
            List<Report> expectedReports = new List<Report>();
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)context.Reports.Count() / (double)PageSize))
            {
                expectedReports = context.Reports
                    .OrderBy(m => m.Date)
                    .Skip((pageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

            }
            else
            {
                expectedReports = context.Reports
                    .OrderBy(m => m.Date)
                    .Take(PageSize)
                    .ToList(); ;
            }

            // Act
            await pageModel.OnGetAsync(null, null, null, pageIndex);

            // Assert
            var actualReports = Assert.IsAssignableFrom<List<Report>>(pageModel.Report);
            Assert.Equal(
                expectedReports.OrderBy(m => m.Date).Take(PageSize).Select(m => m.Date),
                actualReports.OrderBy(m => m.Date).Select(m => m.Date));
        }

        //CreateModel
        [Fact]
        public async Task Report_CreateModel_OnPostAsync_ReportIsAdded()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Reports.CreateModel(context, logger);
            var expectedReport = new Report 
            {
                Hours = 24.0,
                Date = DateTime.Parse("2021-06-07"),
                ReportState = ReportState.Approved
            };

            pageModel.Report = expectedReport;

            // Act
            var result = await pageModel.OnPostAsync(null, expectedReport.Hours);

            // Assert
            var actualReport = await context.Reports.Where(c => c.Date == DateTime.Parse("2021-06-07")).FirstOrDefaultAsync();
            Assert.Equal(expectedReport.Date, actualReport.Date);
            Assert.Equal(expectedReport.Hours, actualReport.Hours);
            Assert.Equal(expectedReport.ReportState, actualReport.ReportState);
            Assert.IsType<RedirectToPageResult>(result);
        }

        //CreateModel
        [Fact]
        public async Task Report_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.CreateModel>>();
            int testId = 1;
            var pageModel = new ERPSystem.Pages.Reports.CreateModel(context, logger);
            var expectedReport = new Report
            {
                Hours = 24.0,
                Date = DateTime.Parse("2021-06-07"),
                ReportState = ReportState.Approved
            };
            pageModel.Report = expectedReport;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(testId, expectedReport.Hours);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Report_DeleteModel_OnGetAsync_ReportIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Reports.DeleteModel(context, logger);
            var testId = 1;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Report>(pageModel.Report);
            Assert.Equal(testId, model.Id);
            Assert.Equal(160.0, model.Hours);
            Assert.Equal(DateTime.Parse("2021-09-07"), model.Date);
            Assert.Equal(ReportState.Approved, model.ReportState);
        }

        //DeleteModel
        [Fact]
        public async Task Report_DeleteModel_OnPostAsync_ReportIsDeleted_WhenReportIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Reports.DeleteModel(context, logger);
            var testId = 1;
            var expectedReports = context.Reports.Where(c => c.Id != testId).ToList();

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualReports = await context.Reports.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedReports.OrderBy(m => m.Id).Select(m => m.Date),
                actualReports.OrderBy(m => m.Id).Select(m => m.Date));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Report_DeleteModel_OnPostAsync_NoReportIsDeleted_WhenReportIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Reports.DeleteModel(context, logger);
            var testId = 11;
            var expectedReports = context.Reports;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualReports = await context.Reports.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedReports.OrderBy(m => m.Id).Select(m => m.Date),
                actualReports.OrderBy(m => m.Id).Select(m => m.Date));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //EditModel
        [Fact]
        public async Task Report_EditModel_OnGetAsync_ReportIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.EditModel>>();
            var pageModel = new ERPSystem.Pages.Reports.EditModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Report>(pageModel.Report);
            Assert.Equal(testId, model.Id);
            Assert.Equal(DateTime.Parse("2021-06-13"), model.Date);
            Assert.Equal(216.0, model.Hours);
            Assert.Equal(ReportState.Submitted, model.ReportState);
        }

        //EditModel
        [Fact]
        public async Task Report_EditModel_OnPostAsync_ReportIsModified()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.EditModel>>();
            var testId = 1;
            var expectedHours = 22.0;
            var expectedDate = DateTime.Parse("2021-07-07");
            var expectedReportState = ReportState.Draft;
            var pageModel = new ERPSystem.Pages.Reports.EditModel(context, logger);
            var expectedReport = context.Reports.FirstOrDefault(m => m.Id == testId);
            pageModel.Report = expectedReport;
            pageModel.Report.Date = expectedDate;
            pageModel.Report.ReportState = expectedReportState;
            pageModel.Report.Hours = expectedHours;

            // Act
            var result = await pageModel.OnPostAsync(testId, null, null, null, expectedHours);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var model = Assert.IsAssignableFrom<Report>(pageModel.Report);
            Assert.Equal(expectedDate, model.Date);
            Assert.Equal(expectedHours, model.Hours);
            Assert.Equal(expectedReportState, model.ReportState);
            var actualReport = context.Reports.FirstOrDefault(m => m.Id == testId);
            Assert.Equal(expectedDate, actualReport.Date);
            Assert.Equal(expectedHours, actualReport.Hours);
            Assert.Equal(expectedReportState, actualReport.ReportState);
        }

        //EditModel
        [Fact]
        public async Task Report_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.EditModel>>();
            var testId = 1;
            var expectedHours = 22.0;
            var expectedDate = DateTime.Parse("2021-07-07");
            var expectedReportState = ReportState.Draft;
            var pageModel = new ERPSystem.Pages.Reports.EditModel(context, logger);
            var expectedReport = context.Reports.FirstOrDefault(m => m.Id == testId);
            pageModel.Report = expectedReport;
            pageModel.Report.Date = expectedDate;
            pageModel.Report.ReportState = expectedReportState;
            pageModel.Report.Hours = expectedHours;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(testId, null, null, null, expectedHours);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DetailsModel
        [Fact]
        public async Task Report_DetailsModel_OnGetAsync_ReportIsFetched_WhenReportIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Reports.DetailsModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Report>(pageModel.Report);
            Assert.Equal(testId, model.Id);
            Assert.Equal(216.0, model.Hours);
            Assert.Equal(DateTime.Parse("2021-06-13"), model.Date);
            Assert.Equal(ReportState.Approved, model.ReportState);
        }

        //DetailsModel
        [Fact]
        public async Task Report_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenReportIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Reports.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Reports.DetailsModel(context, logger);
            int testId = 11;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
