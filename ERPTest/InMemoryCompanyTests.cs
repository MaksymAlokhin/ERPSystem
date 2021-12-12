using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using Microsoft.Extensions.Configuration;

namespace ERPTest
{
    public class InMemoryCompanyTests : CompanyTests
    {

        public InMemoryCompanyTests()
    : base(
        new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options)
        {
        }
    }
}
