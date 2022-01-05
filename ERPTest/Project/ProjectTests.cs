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

namespace ProjectTest
{
    public abstract class ProjectTests : IDisposable
    {
        public ProjectTests(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            PageSize = 7;

            context = new ApplicationDbContext(contextOptions);

            SeedProject(context);
        }
        public ApplicationDbContext context { get; private set; }
        private int PageSize;
        public void Dispose()
        {
            context.Dispose();
        }

        private void SeedProject(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Project p001 = new Project
            {
                Name = "Alpha",
                StartDate = DateTime.Parse("2020-12-30"),
                EndDate = DateTime.Parse("2023-03-05"),
                ProjectState = ProjectState.Active
            };
            Project p002 = new Project
            {
                Name = "Beta",
                StartDate = DateTime.Parse("2020-07-10"),
                EndDate = DateTime.Parse("2022-09-09"),
                ProjectState = ProjectState.Active
            };
            Project p003 = new Project
            {
                Name = "Gamma",
                StartDate = DateTime.Parse("2021-05-10"),
                EndDate = DateTime.Parse("2023-10-09"),
                ProjectState = ProjectState.Active
            };
            Project p004 = new Project
            {
                Name = "Delta",
                StartDate = DateTime.Parse("2021-06-03"),
                EndDate = DateTime.Parse("2022-03-14"),
                ProjectState = ProjectState.Active
            };
            Project p005 = new Project
            {
                Name = "Epsilon",
                StartDate = DateTime.Parse("2020-09-23"),
                EndDate = DateTime.Parse("2022-05-28"),
                ProjectState = ProjectState.Active
            };
            Project p006 = new Project
            {
                Name = "Zeta",
                StartDate = DateTime.Parse("2020-07-28"),
                EndDate = DateTime.Parse("2022-08-03"),
                ProjectState = ProjectState.Active
            };
            Project p007 = new Project
            {
                Name = "Kappa",
                StartDate = DateTime.Parse("2020-04-29"),
                EndDate = DateTime.Parse("2022-11-04"),
                ProjectState = ProjectState.Active
            };
            Project p008 = new Project
            {
                Name = "Omicron",
                StartDate = DateTime.Parse("2020-02-13"),
                EndDate = DateTime.Parse("2022-02-10"),
                ProjectState = ProjectState.Active
            };
            Project p009 = new Project
            {
                Name = "Sigma",
                StartDate = DateTime.Parse("2021-08-18"),
                EndDate = DateTime.Parse("2022-04-01"),
                ProjectState = ProjectState.Active
            };
            Project p010 = new Project
            {
                Name = "Tau",
                StartDate = DateTime.Parse("2019-11-13"),
                EndDate = DateTime.Parse("2023-07-01"),
                ProjectState = ProjectState.Active
            };
            context.Add(p001);
            context.Add(p002);
            context.Add(p003);
            context.Add(p004);
            context.Add(p005);
            context.Add(p006);
            context.Add(p007);
            context.Add(p008);
            context.Add(p009);
            context.Add(p010);
            context.SaveChanges();
        }

        //IndexModel
        [Fact]
        public async Task Project_IndexModel_OnGetAsync_ProjectsAreReturned()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Projects.IndexModel(context, config, logger);
            var expectedProjects = context.Projects;

            // Act
            await pageModel.OnGetAsync(null, null, null, null);

            // Assert
            var actualProjects = Assert.IsAssignableFrom<List<Project>>(pageModel.Project);
            Assert.Equal(
                expectedProjects.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualProjects.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Fact]
        public async Task Project_IndexModel_OnGetAsync_ProjectsAreReturnedInDescendingOrder()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Projects.IndexModel(context, config, logger);
            var expectedProjects = context.Projects;

            // Act
            await pageModel.OnGetAsync("name_desc", null, null, null);

            // Assert
            var actualProjects = Assert.IsAssignableFrom<List<Project>>(pageModel.Project);
            Assert.Equal(
                expectedProjects.OrderByDescending(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualProjects.OrderByDescending(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("e")]
        [InlineData("er")]
        public async Task Project_IndexModel_OnGetAsync_FilteredListOfProjectsIsReturned(string searchString)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Projects.IndexModel(context, config, logger);
            IQueryable<Project> expectedProjects = context.Projects;
            if (!String.IsNullOrEmpty(searchString))
            {
                expectedProjects = context.Projects.Where(s => s.Name.Contains(searchString)
                                           || s.Department.Name.Contains(searchString)
                                           || s.ProjectManager.LastName.Contains(searchString)
                                           || s.ProjectManager.FirstName.Contains(searchString));
            }

            // Act
            await pageModel.OnGetAsync(null, searchString, null, null);

            // Assert
            var actualProjects = Assert.IsAssignableFrom<List<Project>>(pageModel.Project);
            Assert.Equal(
                expectedProjects.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualProjects.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //IndexModel
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task Project_IndexModel_OnGetAsync_PaginationWorkingAsExpected(int pageIndex)
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.IndexModel>>();
            var config = new ConfigurationBuilder().Build();
            var pageModel = new ERPSystem.Pages.Projects.IndexModel(context, config, logger);
            List<Project> expectedProjects = new List<Project>();
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)context.Projects.Count() / (double)PageSize))
            {
                expectedProjects = context.Projects
                    .OrderBy(m => m.Name)
                    .Skip((pageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

            }
            else
            {
                expectedProjects = context.Projects
                    .OrderBy(m => m.Name)
                    .Take(PageSize)
                    .ToList(); ;
            }

            // Act
            await pageModel.OnGetAsync(null, null, null, pageIndex);

            // Assert
            var actualProjects = Assert.IsAssignableFrom<List<Project>>(pageModel.Project);
            Assert.Equal(
                expectedProjects.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                actualProjects.OrderBy(m => m.Name).Select(m => m.Name));
        }

        //CreateModel
        [Fact]
        public async Task Project_CreateModel_OnPostAsync_ProjectIsAdded()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Projects.CreateModel(context, logger);
            var expectedProject = new Project
            {
                Name = "Test Project",
                StartDate = DateTime.Parse("2019-11-13"),
                EndDate = DateTime.Parse("2023-07-01"),
                ProjectState = ProjectState.Active
            };

            pageModel.Project = expectedProject;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, null, null);

            // Assert
            var actualProject = await context.Projects.Where(c => c.Name == "Test Project").FirstOrDefaultAsync();
            Assert.Equal(expectedProject.Name, actualProject.Name);
            Assert.Equal(expectedProject.StartDate, actualProject.StartDate);
            Assert.Equal(expectedProject.EndDate, actualProject.EndDate);
            Assert.Equal(expectedProject.ProjectState, actualProject.ProjectState);
            Assert.IsType<RedirectToPageResult>(result);
        }

        //CreateModel
        [Fact]
        public async Task Project_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.CreateModel>>();
            var pageModel = new ERPSystem.Pages.Projects.CreateModel(context, logger);
            var expectedProject = new Project
            {
                Name = "Test Project",
                StartDate = DateTime.Parse("2019-11-13"),
                EndDate = DateTime.Parse("2023-07-01"),
                ProjectState = ProjectState.Active
            };
            pageModel.Project = expectedProject;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(null, null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Project_DeleteModel_OnGetAsync_ProjectIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Projects.DeleteModel(context, logger);
            var testId = 1;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Project>(pageModel.Project);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Alpha", model.Name);
            Assert.Equal(DateTime.Parse("2020-12-30"), model.StartDate);
            Assert.Equal(DateTime.Parse("2023-03-05"), model.EndDate);
            Assert.Equal(ProjectState.Active, model.ProjectState);
        }

        //DeleteModel
        [Fact]
        public async Task Project_DeleteModel_OnPostAsync_ProjectIsDeleted_WhenProjectIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Projects.DeleteModel(context, logger);
            var testId = 1;
            var expectedProjects = context.Projects.Where(c => c.Id != testId).ToList();

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualProjects = await context.Projects.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedProjects.OrderBy(m => m.Id).Select(m => m.Name),
                actualProjects.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //DeleteModel
        [Fact]
        public async Task Project_DeleteModel_OnPostAsync_NoProjectIsDeleted_WhenProjectIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.DeleteModel>>();
            var pageModel = new ERPSystem.Pages.Projects.DeleteModel(context, logger);
            var testId = 11;
            var expectedProjects = context.Projects;

            // Act
            var result = await pageModel.OnPostAsync(null, null, null, testId);

            // Assert
            var actualProjects = await context.Projects.AsNoTracking().ToListAsync();
            Assert.Equal(
                expectedProjects.OrderBy(m => m.Id).Select(m => m.Name),
                actualProjects.OrderBy(m => m.Id).Select(m => m.Name));
            Assert.IsType<RedirectToPageResult>(result);
        }

        //EditModel
        [Fact]
        public async Task Project_EditModel_OnGetAsync_ProjectIsFetched()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.EditModel>>();
            var pageModel = new ERPSystem.Pages.Projects.EditModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Project>(pageModel.Project);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Beta", model.Name);
            Assert.Equal(DateTime.Parse("2020-07-10"), model.StartDate);
            Assert.Equal(DateTime.Parse("2022-09-09"), model.EndDate);
            Assert.Equal(ProjectState.Active, model.ProjectState);
        }

        //EditModel
        [Fact]
        public async Task Project_EditModel_OnPostAsync_ProjectIsModified()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.EditModel>>();
            var testId = 1;
            var pageModel = new ERPSystem.Pages.Projects.EditModel(context, logger);
            var expectedProject = context.Projects.FirstOrDefault(m => m.Id == testId);
            pageModel.Project = expectedProject;
            pageModel.Project.Name = "Modified Entity";
            pageModel.Project.ProjectState = ProjectState.Inactive;

            // Act
            var result = await pageModel.OnPostAsync(testId, null, null, null, null, null);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var model = Assert.IsAssignableFrom<Project>(pageModel.Project);
            Assert.Equal("Modified Entity", model.Name);
            Assert.Equal(ProjectState.Inactive, model.ProjectState);
        }

        //EditModel
        [Fact]
        public async Task Project_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.EditModel>>();
            var pageModel = new ERPSystem.Pages.Projects.EditModel(context, logger);
            int testId = 1;
            var expectedProject = context.Projects.FirstOrDefault(m => m.Id == testId);
            pageModel.Project = expectedProject;
            pageModel.Project.Name = "Modified Entity";
            pageModel.Project.ProjectState = ProjectState.Inactive;

            // Act
            pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
            var result = await pageModel.OnPostAsync(testId, null, null, null, null, null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        //DetailsModel
        [Fact]
        public async Task Project_DetailsModel_OnGetAsync_ProjectIsFetched_WhenProjectIsFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Projects.DetailsModel(context, logger);
            int testId = 2;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<PageResult>(result);
            var model = Assert.IsAssignableFrom<Project>(pageModel.Project);
            Assert.Equal(testId, model.Id);
            Assert.Equal("Beta", model.Name);
            Assert.Equal(DateTime.Parse("2020-07-10"), model.StartDate);
            Assert.Equal(DateTime.Parse("2022-09-09"), model.EndDate);
            Assert.Equal(ProjectState.Active, model.ProjectState);
        }

        //DetailsModel
        [Fact]
        public async Task Project_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenProjectIsNotFound()
        {
            // Arrange
            var logger = Mock.Of<Microsoft.Extensions.Logging.ILogger<ERPSystem.Pages.Projects.DetailsModel>>();
            var pageModel = new ERPSystem.Pages.Projects.DetailsModel(context, logger);
            int testId = 11;

            // Act
            var result = await pageModel.OnGetAsync(null, null, null, testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
