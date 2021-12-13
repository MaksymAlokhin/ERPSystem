/*using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyTest
{
    public class SQLServerCompanyTest : CompanyTests
    {
        public SQLServerCompanyTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCompanyTests;Trusted_Connection=True;MultipleActiveResultSets=True")
                    .Options)
        {
        }
    }
}
*/