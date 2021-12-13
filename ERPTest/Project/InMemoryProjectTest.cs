using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjectTest
{
    public class InMemoryProjectTest : ProjectTests
    {
        public InMemoryProjectTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("ProjectTestDatabase")
                    .Options)
        {
        }
    }
}
