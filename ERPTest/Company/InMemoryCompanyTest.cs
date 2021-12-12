using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyTest
{
    public class InMemoryCompanyTest : CompanyTests
    {
        public InMemoryCompanyTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("CompanyTestDatabase")
                    .Options)
        {
        }
    }
}
