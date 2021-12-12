using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace AssignmentTest
{
    public class SQLServerAssignmentTest : AssignmentTests
    {
        public SQLServerAssignmentTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFAssignmentTests;Trusted_Connection=True;MultipleActiveResultSets=True")
                    .Options)
        {
        }
    }
}
