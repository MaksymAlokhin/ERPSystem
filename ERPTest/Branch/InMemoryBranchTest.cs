using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BranchTest
{
    public class InMemoryBranchTest : BranchTests
    {
        public InMemoryBranchTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("BranchTestDatabase")
                    .Options)
        {
        }
    }
}
