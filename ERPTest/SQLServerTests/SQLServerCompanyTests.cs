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

namespace ERPTest
{
    [Collection("SQL Server Collection")]
    public class SQLServerCompanyTests
    {
        public SQLServerCompanyTests(SQLServerSharedDatabaseFixture fixture)
        {
            Fixture = fixture;
            PageSize = fixture.PageSize;
        }
        public SQLServerSharedDatabaseFixture Fixture { get; }
        private int PageSize;

        //IndexModel
        [Fact]
        public async Task Company_IndexModel_OnGetAsync_CompaniesAreReturned()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var config = new ConfigurationBuilder().Build();
                    var pageModel = new ERPSystem.Pages.Companies.IndexModel(context, config);
                    var expectedCompanies = context.Companies;

                    // Act
                    await pageModel.OnGetAsync(null, null, null, null);

                    // Assert
                    var actualCompanies = Assert.IsAssignableFrom<List<Company>>(pageModel.Company);
                    Assert.Equal(
                        expectedCompanies.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                        actualCompanies.OrderBy(m => m.Name).Select(m => m.Name));
                }
            }
        }

        //IndexModel
        [Fact]
        public async Task Company_IndexModel_OnGetAsync_CompaniesAreReturnedInDescendingOrder()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var config = new ConfigurationBuilder().Build();
                    var pageModel = new ERPSystem.Pages.Companies.IndexModel(context, config);
                    var expectedCompanies = context.Companies;

                    // Act
                    await pageModel.OnGetAsync("name_desc", null, null, null);

                    // Assert
                    var actualCompanies = Assert.IsAssignableFrom<List<Company>>(pageModel.Company);
                    Assert.Equal(
                        expectedCompanies.OrderByDescending(m => m.Name).Take(PageSize).Select(m => m.Name),
                        actualCompanies.OrderByDescending(m => m.Name).Select(m => m.Name));
                }
            }
        }

        //IndexModel
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("e")]
        [InlineData("er")]
        public async Task Company_IndexModel_OnGetAsync_FilteredListOfCompaniesIsReturned(string searchString)
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var config = new ConfigurationBuilder().Build();
                    var pageModel = new ERPSystem.Pages.Companies.IndexModel(context, config);
                    var expectedCompanies = context.Companies.Where(c => c.Name.Contains(searchString)
                                                 || c.GeneralManager.FirstName.Contains(searchString)
                                                  || c.GeneralManager.LastName.Contains(searchString));

                    // Act
                    await pageModel.OnGetAsync(null, searchString, null, null);

                    // Assert
                    var actualCompanies = Assert.IsAssignableFrom<List<Company>>(pageModel.Company);
                    Assert.Equal(
                        expectedCompanies.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                        actualCompanies.OrderBy(m => m.Name).Select(m => m.Name));
                }
            }
        }

        //IndexModel
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public async Task Company_IndexModel_OnGetAsync_Pagination(int pageIndex)
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var config = new ConfigurationBuilder().Build();
                    var pageModel = new ERPSystem.Pages.Companies.IndexModel(context, config);
                    List<Company> expectedCompanies = new List<Company>();
                    if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)context.Companies.Count() / (double)PageSize))
                    {
                        expectedCompanies = context.Companies
                            .OrderBy(m => m.Name)
                            .Skip((pageIndex - 1) * PageSize)
                            .Take(PageSize)
                            .ToList();

                    }
                    else
                    {
                        expectedCompanies = context.Companies
                            .OrderBy(m => m.Name)
                            .Take(PageSize)
                            .ToList(); ;

                    }

                    // Act
                    await pageModel.OnGetAsync(null, null, null, pageIndex);

                    // Assert
                    var actualCompanies = Assert.IsAssignableFrom<List<Company>>(pageModel.Company);
                    Assert.Equal(
                        expectedCompanies.OrderBy(m => m.Name).Take(PageSize).Select(m => m.Name),
                        actualCompanies.OrderBy(m => m.Name).Select(m => m.Name));
                }
            }
        }

        //CreateModel
        [Fact]
        public async Task Company_CreateModel_OnPostAsync_CompanyIsAdded()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.CreateModel(context);
                    var expectedCompany = new Company
                    {
                        Id = 11,
                        Name = "Test Company",
                        CompanyState = CompanyState.Inactive,
                        Branches = new List<Branch>(),
                        Departments = new List<Department>()
                    };
                    pageModel.Company = expectedCompany;

                    // Act
                    var result = await pageModel.OnPostAsync(null, null, null, null, null, null);

                    // Assert
                    var actualCompany = await context.Companies.Where(c => c.Name == "Test Company").FirstOrDefaultAsync();
                    var object1Json = JsonSerializer.Serialize(expectedCompany);
                    var object2Json = JsonSerializer.Serialize(actualCompany);
                    Assert.Equal(object1Json, object2Json);
                    Assert.IsType<RedirectToPageResult>(result);
                }
            }
        }

        //CreateModel
        [Fact]
        public async Task Company_CreateModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.CreateModel(context);
                    var expectedCompany = new Company
                    {
                        Id = 11,
                        Name = "Test Company",
                        CompanyState = CompanyState.Inactive,
                        Branches = new List<Branch>(),
                        Departments = new List<Department>()
                    };
                    pageModel.Company = expectedCompany;

                    // Act
                    pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
                    var result = await pageModel.OnPostAsync(null, null, null, null, null, null);

                    // Assert
                    Assert.IsType<PageResult>(result);
                }
            }
        }

        //DeleteModel
        [Fact]
        public async Task Company_DeleteModel_OnGetAsync_CompanyIsFetched()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.DeleteModel(context);
                    var testId = 1;

                    // Act
                    var result = await pageModel.OnGetAsync(null, null, null, testId);

                    // Assert
                    Assert.IsType<PageResult>(result);
                    var model = Assert.IsAssignableFrom<Company>(pageModel.Company);
                    Assert.Equal(testId, model.Id);
                    Assert.Equal("Exxon Mobil", model.Name);
                    Assert.Equal(CompanyState.Active, model.CompanyState);
                }
            }
        }

        //DeleteModel
        [Fact]
        public async Task Company_DeleteModel_OnPostAsync_CompanyIsDeleted_WhenCompanyIsFound()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.DeleteModel(context);
                    var testId = 1;
                    var expectedCompanies = context.Companies.Where(c => c.Id != testId).ToList();

                    // Act
                    var result = await pageModel.OnPostAsync(null, null, null, testId);

                    // Assert
                    var actualCompanies = await context.Companies.AsNoTracking().ToListAsync();
                    Assert.Equal(
                        expectedCompanies.OrderBy(m => m.Id).Select(m => m.Name),
                        actualCompanies.OrderBy(m => m.Id).Select(m => m.Name));
                    Assert.IsType<RedirectToPageResult>(result);
                }
            }
        }

        //DeleteModel
        [Fact]
        public async Task Company_DeleteModel_OnPostAsync_NoCompanyIsDeleted_WhenCompanyIsNotFound()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.DeleteModel(context);
                    var testId = 11;
                    var expectedCompanies = context.Companies;

                    // Act
                    var result = await pageModel.OnPostAsync(null, null, null, testId);

                    // Assert
                    var actualCompanies = await context.Companies.AsNoTracking().ToListAsync();
                    Assert.Equal(
                        expectedCompanies.OrderBy(m => m.Id).Select(m => m.Name),
                        actualCompanies.OrderBy(m => m.Id).Select(m => m.Name));
                    Assert.IsType<RedirectToPageResult>(result);
                }
            }
        }

        //EditModel
        [Fact]
        public async Task Company_EditModel_OnGetAsync_CompanyIsFetched()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.EditModel(context);
                    int testId = 1;

                    // Act
                    var result = await pageModel.OnGetAsync(null, null, null, testId);

                    // Assert
                    Assert.IsType<PageResult>(result);
                    var model = Assert.IsAssignableFrom<Company>(pageModel.Company);
                    Assert.Equal(testId, model.Id);
                    Assert.Equal("Exxon Mobil", model.Name);
                    Assert.Equal(CompanyState.Active, model.CompanyState);
                }
            }
        }

        //EditModel
        [Fact]
        public async Task Company_EditModel_OnPostAsync_CompanyIsModified()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.EditModel(context);
                    int testId = 1;
                    var expectedCompany = new Company
                    {
                        Name = "Modified Entity",
                        CompanyState = CompanyState.Inactive,
                    };
                    pageModel.Company = expectedCompany;

                    // Act
                    var result = await pageModel.OnPostAsync(testId, null, null, null, null, null, null);

                    // Assert
                    Assert.IsType<RedirectToPageResult>(result);
                    var model = Assert.IsAssignableFrom<Company>(pageModel.Company);
                    Assert.Equal("Modified Entity", model.Name);
                    Assert.Equal(CompanyState.Inactive, model.CompanyState);
                }
            }
        }

        //EditModel
        [Fact]
        public async Task Company_EditModel_OnPostAsync_IfInvalidModel_ReturnPageResult()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.EditModel(context);
                    int testId = 1;
                    var expectedCompany = new Company
                    {
                        Name = "Modified Entity",
                        CompanyState = CompanyState.Inactive,
                    };
                    pageModel.Company = expectedCompany;

                    // Act
                    pageModel.ModelState.AddModelError("Error", "ModelState is invalid");
                    var result = await pageModel.OnPostAsync(testId, null, null, null, null, null, null);

                    // Assert
                    Assert.IsType<PageResult>(result);
                }
            }
        }

        //DetailsModel
        [Fact]
        public async Task Company_DetailsModel_OnGetAsync_CompanyIsFetched_WhenCompanyIsFound()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.DetailsModel(context);
                    int testId = 1;

                    // Act
                    var result = await pageModel.OnGetAsync(null, null, null, testId);

                    // Assert
                    Assert.IsType<PageResult>(result);
                    var model = Assert.IsAssignableFrom<Company>(pageModel.Company);
                    Assert.Equal(testId, model.Id);
                    Assert.Equal("Exxon Mobil", model.Name);
                    Assert.Equal(CompanyState.Active, model.CompanyState);
                }
            }
        }

        //DetailsModel
        [Fact]
        public async Task Company_DetailsModel_OnGetAsync_NotFoundResultReturned_WhenCompanyIsNotFound()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // Arrange
                    var pageModel = new ERPSystem.Pages.Companies.DetailsModel(context);
                    int testId = 11;

                    // Act
                    var result = await pageModel.OnGetAsync(null, null, null, testId);

                    // Assert
                    Assert.IsType<NotFoundResult>(result);
                }
            }
        }
    }
}
