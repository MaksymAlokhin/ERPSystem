using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace ReportTest
{
    public class InMemoryReportTest : ReportTests
    {
        public InMemoryReportTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("ReportTestDatabase")
                    .Options)
        {
        }
    }
}
