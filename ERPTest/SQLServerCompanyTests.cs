using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ERPTest
{
    public class SQLServerCompanyTests : CompanyTests, IClassFixture<SharedDatabaseFixture>
    {
        public SQLServerCompanyTests()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options)
        {
        }
    }

}
