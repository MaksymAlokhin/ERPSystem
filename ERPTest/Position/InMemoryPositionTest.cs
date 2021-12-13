using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace PositionTest
{
    public class InMemoryPositionTest : PositionTests
    {
        public InMemoryPositionTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("PositionTestDatabase")
                    .Options)
        {
        }
    }
}
