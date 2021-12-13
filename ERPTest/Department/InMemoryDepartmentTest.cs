using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace DepartmentTest
{
    public class InMemoryDepartmentTest : DepartmentTests
    {
        public InMemoryDepartmentTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("DepartmentTestDatabase")
                    .Options)
        {
        }
    }
}
