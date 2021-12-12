using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace AssignmentTest
{
    public class InMemoryAssignmentTest : AssignmentTests
    {
        public InMemoryAssignmentTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("AssignmentTestDatabase")
                    .Options)
        {
        }
    }
}
