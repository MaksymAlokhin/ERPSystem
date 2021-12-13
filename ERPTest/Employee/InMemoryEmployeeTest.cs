using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTest
{
    public class InMemoryEmployeeTest : EmployeeTests
    {
        public InMemoryEmployeeTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("EmployeeTestDatabase")
                    .Options)
        {
        }
    }
}
