using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using Xunit;

namespace ERPTest
{
    public class InMemorySharedDatabaseFixture : IDisposable
    {
        public ApplicationDbContext context { get; private set; }

        public InMemorySharedDatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase("TestDatabase")
                        .Options;

            context = new ApplicationDbContext(options);

            SeedAssignment(context);
            SeedBranch(context);
            SeedCompany(context);
            SeedDepartment(context);
            SeedEmployee(context);
            SeedPosition(context);
            SeedProject(context);
            SeedReport(context);
        }
        private void SeedAssignment(ApplicationDbContext context)
        {
            Assignment as0101 = new Assignment
            {
                Name = "Operations Manager Assignment",
                StartDate = DateTime.Parse("2020-12-30"),
                EndDate = DateTime.Parse("2023-03-05"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0102 = new Assignment
            {
                Name = "Quality Control Assignment",
                StartDate = DateTime.Parse("2020-07-10"),
                EndDate = DateTime.Parse("2022-09-09"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0103 = new Assignment
            {
                Name = "Accountant Assignment",
                StartDate = DateTime.Parse("2021-05-10"),
                EndDate = DateTime.Parse("2023-10-09"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0104 = new Assignment
            {
                Name = "Office Manager Assignment",
                StartDate = DateTime.Parse("2021-06-03"),
                EndDate = DateTime.Parse("2022-03-14"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0105 = new Assignment
            {
                Name = "Receptionist Assignment",
                StartDate = DateTime.Parse("2020-09-23"),
                EndDate = DateTime.Parse("2022-05-28"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0106 = new Assignment
            {
                Name = "Supervisor Assignment",
                StartDate = DateTime.Parse("2020-07-28"),
                EndDate = DateTime.Parse("2022-08-03"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0107 = new Assignment
            {
                Name = "Marketing Manager Assignment",
                StartDate = DateTime.Parse("2020-04-29"),
                EndDate = DateTime.Parse("2022-11-04"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0108 = new Assignment
            {
                Name = "Purchasing Manager Assignment",
                StartDate = DateTime.Parse("2020-02-13"),
                EndDate = DateTime.Parse("2022-02-10"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };
            Assignment as0109 = new Assignment
            {
                Name = "Shipping Manager Assignment",
                StartDate = DateTime.Parse("2021-08-18"),
                EndDate = DateTime.Parse("2022-04-01"),
                FTE = 0.5,
                AssignmentState = AssignmentState.Active
            };

            context.Add(as0101);
            context.Add(as0102);
            context.Add(as0103);
            context.Add(as0104);
            context.Add(as0105);
            context.Add(as0106);
            context.Add(as0107);
            context.Add(as0108);
            context.Add(as0109);
            context.SaveChanges();
        }
        private void SeedBranch(ApplicationDbContext context)
        {
            Branch WalmartNorthAmerica = new Branch
            {
                Name = "Walmart North America",
                BranchState = BranchState.Active
            };
            Branch WalmartEurope = new Branch
            {
                Name = "Walmart Europe",
                BranchState = BranchState.Active
            };
            Branch AmazonNorthAmerica = new Branch
            {
                Name = "Amazon North America",
                BranchState = BranchState.Active
            };
            Branch AmazonEurope = new Branch
            {
                Name = "Amazon Europe",
                BranchState = BranchState.Active
            };
            Branch AppleNorthAmerica = new Branch
            {
                Name = "Apple North America",
                BranchState = BranchState.Active
            };
            Branch AppleEurope = new Branch
            {
                Name = "Apple Europe",
                BranchState = BranchState.Active
            };
            Branch FordMotorNorthAmerica = new Branch
            {
                Name = "Ford Motor North America",
                BranchState = BranchState.Active
            };
            Branch FordMotorEurope = new Branch
            {
                Name = "Ford Motor Europe",
                BranchState = BranchState.Active
            };
            Branch FedExNorthAmerica = new Branch
            {
                Name = "FedEx North America",
                BranchState = BranchState.Active
            };
            Branch FedExEurope = new Branch
            {
                Name = "FedEx Europe",
                BranchState = BranchState.Active
            };
            context.Add(WalmartNorthAmerica);
            context.Add(WalmartEurope);
            context.Add(AmazonNorthAmerica);
            context.Add(AmazonEurope);
            context.Add(AppleNorthAmerica);
            context.Add(AppleEurope);
            context.Add(FordMotorNorthAmerica);
            context.Add(FordMotorEurope);
            context.Add(FedExNorthAmerica);
            context.Add(FedExEurope);
            context.SaveChanges();
        }
        private void SeedCompany(ApplicationDbContext context)
        {
            Company Walmart = new Company
            {
                Name = "Walmart",
                CompanyState = CompanyState.Active
            };
            Company Amazon = new Company
            {
                Name = "Amazon",
                CompanyState = CompanyState.Active
            };
            Company Apple = new Company
            {
                Name = "Apple",
                CompanyState = CompanyState.Active
            };
            Company FordMotor = new Company
            {
                Name = "Ford Motor",
                CompanyState = CompanyState.Active
            };
            Company FedEx = new Company
            {
                Name = "FedEx",
                CompanyState = CompanyState.Active
            };
            Company BankOfAmerica = new Company
            {
                Name = "Bank of America",
                CompanyState = CompanyState.Active
            };
            Company JohnsonAndJohnson = new Company
            {
                Name = "Johnson & Johnson",
                CompanyState = CompanyState.Active
            };
            Company Facebook = new Company
            {
                Name = "Facebook",
                CompanyState = CompanyState.Active
            };
            Company Alphabet = new Company
            {
                Name = "Alphabet",
                CompanyState = CompanyState.Active
            };
            Company ExxonMobil = new Company
            {
                Name = "Exxon Mobil",
                CompanyState = CompanyState.Active
            };
            context.Add(Walmart);
            context.Add(Amazon);
            context.Add(Apple);
            context.Add(FordMotor);
            context.Add(FedEx);
            context.Add(BankOfAmerica);
            context.Add(JohnsonAndJohnson);
            context.Add(Facebook);
            context.Add(Alphabet);
            context.Add(ExxonMobil);
            context.SaveChanges();
        }
        private void SeedDepartment(ApplicationDbContext context)
        {
            Department WalmartMarketing = new Department
            {
                Name = "Walmart Marketing",
                DepartmentState = DepartmentState.Active
            };
            Department WalmartAccountingAndFinance = new Department
            {
                Name = "Walmart Accounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            Department AmazonMarketing = new Department
            {
                Name = "Amazon Marketing",
                DepartmentState = DepartmentState.Active
            };
            Department AmazonAccountingAndFinance = new Department
            {
                Name = "Amazon Accounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            Department AppleMarketing = new Department
            {
                Name = "Apple Marketing",
                DepartmentState = DepartmentState.Active
            };
            Department AppleAccountingAndFinance = new Department
            {
                Name = "Apple Accounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            Department FordMotorMarketing = new Department
            {
                Name = "Ford Motor Marketing",
                DepartmentState = DepartmentState.Active
            };
            Department FordMotorAccountingAndFinance = new Department
            {
                Name = "Ford Motor Accounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            Department FedExMarketing = new Department
            {
                Name = "FedExMarketing",
                DepartmentState = DepartmentState.Active
            };
            Department FedExAccountingAndFinance = new Department
            {
                Name = "FedExAccounting and Finance",
                DepartmentState = DepartmentState.Active
            };
            context.Add(WalmartMarketing);
            context.Add(WalmartAccountingAndFinance);
            context.Add(AmazonMarketing);
            context.Add(AmazonAccountingAndFinance);
            context.Add(AppleMarketing);
            context.Add(AppleAccountingAndFinance);
            context.Add(FordMotorMarketing);
            context.Add(FordMotorAccountingAndFinance);
            context.Add(FedExMarketing);
            context.Add(FedExAccountingAndFinance);
            context.SaveChanges();
        }
        private void SeedEmployee(ApplicationDbContext context)
        {
            Employee e001 = new Employee
            {
                FirstName = "Beverly",
                LastName = "Diaz",
                DateOfBirth = DateTime.Parse("1993-09-27"),
                ProfilePicture = "female_001.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e002 = new Employee
            {
                FirstName = "Jescie",
                LastName = "Webb",
                DateOfBirth = DateTime.Parse("1987-09-27"),
                ProfilePicture = "female_002.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e003 = new Employee
            {
                FirstName = "Deacon",
                LastName = "Bass",
                DateOfBirth = DateTime.Parse("1990-11-18"),
                ProfilePicture = "male_001.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e004 = new Employee
            {
                FirstName = "Felix",
                LastName = "Chapman",
                DateOfBirth = DateTime.Parse("1995-09-11"),
                ProfilePicture = "male_002.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e005 = new Employee
            {
                FirstName = "Alma",
                LastName = "O'donnell",
                DateOfBirth = DateTime.Parse("1984-07-19"),
                ProfilePicture = "female_003.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e006 = new Employee
            {
                FirstName = "Dante",
                LastName = "Gordon",
                DateOfBirth = DateTime.Parse("1994-10-04"),
                ProfilePicture = "male_003.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e007 = new Employee
            {
                FirstName = "Clarke",
                LastName = "Conley",
                DateOfBirth = DateTime.Parse("1996-04-22"),
                ProfilePicture = "male_004.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e008 = new Employee
            {
                FirstName = "Myles",
                LastName = "Turner",
                DateOfBirth = DateTime.Parse("1993-04-16"),
                ProfilePicture = "male_005.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            Employee e009 = new Employee
            {
                FirstName = "Leroy",
                LastName = "Morrow",
                DateOfBirth = DateTime.Parse("1988-03-15"),
                ProfilePicture = "male_006.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee,
            };
            Employee e010 = new Employee
            {
                FirstName = "Charissa",
                LastName = "Conrad",
                DateOfBirth = DateTime.Parse("1997-07-30"),
                ProfilePicture = "female_004.jpg",
                EmployeeState = EmployeeState.Active,
                EmployeeRole = EmployeeRole.Employee
            };
            context.Add(e001);
            context.Add(e002);
            context.Add(e003);
            context.Add(e004);
            context.Add(e005);
            context.Add(e006);
            context.Add(e007);
            context.Add(e008);
            context.Add(e009);
            context.Add(e010);
            context.SaveChanges();
        }
        private void SeedPosition(ApplicationDbContext context)
        {
            Position pos0101 = new Position
            {
                Name = "Operations Manager",
                StartDate = DateTime.Parse("2020-12-30"),
                EndDate = DateTime.Parse("2023-03-05"),
                PositionState = PositionState.Active
            };
            Position pos0102 = new Position
            {
                Name = "Quality Control",
                StartDate = DateTime.Parse("2020-07-10"),
                EndDate = DateTime.Parse("2022-09-09"),
                PositionState = PositionState.Active
            };
            Position pos0103 = new Position
            {
                Name = "Accountant",
                StartDate = DateTime.Parse("2021-05-10"),
                EndDate = DateTime.Parse("2023-10-09"),
                PositionState = PositionState.Active
            };
            Position pos0104 = new Position
            {
                Name = "Office Manager",
                StartDate = DateTime.Parse("2021-06-03"),
                EndDate = DateTime.Parse("2022-03-14"),
                PositionState = PositionState.Active
            };
            Position pos0105 = new Position
            {
                Name = "Receptionist",
                StartDate = DateTime.Parse("2020-09-23"),
                EndDate = DateTime.Parse("2022-05-28"),
                PositionState = PositionState.Active
            };
            Position pos0106 = new Position
            {
                Name = "Supervisor",
                StartDate = DateTime.Parse("2020-07-28"),
                EndDate = DateTime.Parse("2022-08-03"),
                PositionState = PositionState.Active
            };
            Position pos0107 = new Position
            {
                Name = "Marketing Manager",
                StartDate = DateTime.Parse("2020-04-29"),
                EndDate = DateTime.Parse("2022-11-04"),
                PositionState = PositionState.Active
            };
            Position pos0108 = new Position
            {
                Name = "Purchasing Manager",
                StartDate = DateTime.Parse("2020-02-13"),
                EndDate = DateTime.Parse("2022-02-10"),
                PositionState = PositionState.Active
            };
            Position pos0109 = new Position
            {
                Name = "Shipping Manager",
                StartDate = DateTime.Parse("2021-08-18"),
                EndDate = DateTime.Parse("2022-04-01"),
                PositionState = PositionState.Active
            };
            context.Add(pos0101);
            context.Add(pos0102);
            context.Add(pos0103);
            context.Add(pos0104);
            context.Add(pos0105);
            context.Add(pos0106);
            context.Add(pos0107);
            context.Add(pos0108);
            context.Add(pos0109);
            context.SaveChanges();
        }
        private void SeedProject(ApplicationDbContext context)
        {
            Project p001 = new Project
            {
                Name = "Alpha",
                StartDate = DateTime.Parse("2020-12-30"),
                EndDate = DateTime.Parse("2023-03-05"),
                ProjectState = ProjectState.Active
            };
            Project p002 = new Project
            {
                Name = "Beta",
                StartDate = DateTime.Parse("2020-07-10"),
                EndDate = DateTime.Parse("2022-09-09"),
                ProjectState = ProjectState.Active
            };
            Project p003 = new Project
            {
                Name = "Gamma",
                StartDate = DateTime.Parse("2021-05-10"),
                EndDate = DateTime.Parse("2023-10-09"),
                ProjectState = ProjectState.Active
            };
            Project p004 = new Project
            {
                Name = "Delta",
                StartDate = DateTime.Parse("2021-06-03"),
                EndDate = DateTime.Parse("2022-03-14"),
                ProjectState = ProjectState.Active
            };
            Project p005 = new Project
            {
                Name = "Epsilon",
                StartDate = DateTime.Parse("2020-09-23"),
                EndDate = DateTime.Parse("2022-05-28"),
                ProjectState = ProjectState.Active
            };
            Project p006 = new Project
            {
                Name = "Zeta",
                StartDate = DateTime.Parse("2020-07-28"),
                EndDate = DateTime.Parse("2022-08-03"),
                ProjectState = ProjectState.Active
            };
            Project p007 = new Project
            {
                Name = "Kappa",
                StartDate = DateTime.Parse("2020-04-29"),
                EndDate = DateTime.Parse("2022-11-04"),
                ProjectState = ProjectState.Active
            };
            Project p008 = new Project
            {
                Name = "Omicron",
                StartDate = DateTime.Parse("2020-02-13"),
                EndDate = DateTime.Parse("2022-02-10"),
                ProjectState = ProjectState.Active
            };
            Project p009 = new Project
            {
                Name = "Sigma",
                StartDate = DateTime.Parse("2021-08-18"),
                EndDate = DateTime.Parse("2022-04-01"),
                ProjectState = ProjectState.Active
            };
            Project p010 = new Project
            {
                Name = "Tau",
                StartDate = DateTime.Parse("2019-11-13"),
                EndDate = DateTime.Parse("2023-07-01"),
                ProjectState = ProjectState.Active
            };
            context.Add(p001);
            context.Add(p002);
            context.Add(p003);
            context.Add(p004);
            context.Add(p005);
            context.Add(p006);
            context.Add(p007);
            context.Add(p008);
            context.Add(p009);
            context.Add(p010);
            context.SaveChanges();
        }
        private void SeedReport(ApplicationDbContext context)
        {
            Report r001 = new Report
            {
                Hours = 160.0,
                Date = DateTime.Parse("2021-09-07"),
                ReportState = ReportState.Approved
            };
            Report r002 = new Report
            {
                Hours = 216.0,
                Date = DateTime.Parse("2021-06-13"),
                ReportState = ReportState.Approved
            };
            Report r003 = new Report
            {
                Hours = 88.0,
                Date = DateTime.Parse("2021-08-29"),
                ReportState = ReportState.Approved
            };
            Report r004 = new Report
            {
                Hours = 56.0,
                Date = DateTime.Parse("2021-06-23"),
                ReportState = ReportState.Submitted
            };
            Report r005 = new Report
            {
                Hours = 144.0,
                Date = DateTime.Parse("2021-02-26"),
                ReportState = ReportState.Submitted
            };
            Report r006 = new Report
            {
                Hours = 24.0,
                Date = DateTime.Parse("2021-11-17"),
                ReportState = ReportState.Approved
            };
            Report r007 = new Report
            {
                Hours = 40.0,
                Date = DateTime.Parse("2021-02-16"),
                ReportState = ReportState.Approved
            };
            Report r008 = new Report
            {
                Hours = 72.0,
                Date = DateTime.Parse("2021-01-05"),
                ReportState = ReportState.Approved
            };
            Report r009 = new Report
            {
                Hours = 248.0,
                Date = DateTime.Parse("2021-09-17"),
                ReportState = ReportState.Submitted
            };
            context.Add(r001);
            context.Add(r002);
            context.Add(r003);
            context.Add(r004);
            context.Add(r005);
            context.Add(r006);
            context.Add(r007);
            context.Add(r008);
            context.Add(r009);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
    [CollectionDefinition("InMemory Collection")]
    public class InMemoryCollection : ICollectionFixture<InMemorySharedDatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
