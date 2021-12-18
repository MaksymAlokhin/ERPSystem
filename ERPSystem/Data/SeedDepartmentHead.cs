using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedDepartment;


namespace ERPSystem.Data
{
    public static class SeedDepartmentHead
    {
        #region Create Department Heads
        public static Employee dh001 = new Employee
        {
            FirstName = "Miranda",
            LastName = "Ward",
            Department = WalmartMarketing,
            DateOfBirth = DateTime.Parse("1983-05-05"),
            ProfilePicture = "female_080.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh002 = new Employee
        {
            FirstName = "Cassidy",
            LastName = "Blackwell",
            Department = WalmartAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1981-08-14"),
            ProfilePicture = "female_081.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh003 = new Employee
        {
            FirstName = "Giselle",
            LastName = "Whitaker",
            Department = AmazonMarketing,
            DateOfBirth = DateTime.Parse("1988-12-05"),
            ProfilePicture = "female_082.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh004 = new Employee
        {
            FirstName = "Brody",
            LastName = "Roach",
            Department = AmazonAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1999-10-31"),
            ProfilePicture = "male_124.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh005 = new Employee
        {
            FirstName = "Zephr",
            LastName = "Kelley",
            Department = AppleMarketing,
            DateOfBirth = DateTime.Parse("1991-03-31"),
            ProfilePicture = "male_125.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh006 = new Employee
        {
            FirstName = "Dale",
            LastName = "West",
            Department = AppleAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1990-05-09"),
            ProfilePicture = "male_126.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh007 = new Employee
        {
            FirstName = "Iliana",
            LastName = "Ewing",
            Department = FordMotorMarketing,
            DateOfBirth = DateTime.Parse("1988-04-21"),
            ProfilePicture = "female_083.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh008 = new Employee
        {
            FirstName = "Nasim",
            LastName = "Bonner",
            Department = FordMotorAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1999-05-21"),
            ProfilePicture = "male_127.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh009 = new Employee
        {
            FirstName = "Phyllis",
            LastName = "Curtis",
            Department = FedExMarketing,
            DateOfBirth = DateTime.Parse("1988-02-28"),
            ProfilePicture = "male_128.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh010 = new Employee
        {
            FirstName = "Stacy",
            LastName = "Ramirez",
            Department = FedExAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1989-04-05"),
            ProfilePicture = "female_084.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh011 = new Employee
        {
            FirstName = "Deacon",
            LastName = "Roberts",
            Department = BankOfAmericaMarketing,
            DateOfBirth = DateTime.Parse("1984-11-10"),
            ProfilePicture = "male_129.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh012 = new Employee
        {
            FirstName = "Brynn",
            LastName = "Rivas",
            Department = BankOfAmericaAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1981-07-30"),
            ProfilePicture = "male_130.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh013 = new Employee
        {
            FirstName = "Aphrodite",
            LastName = "Rich",
            Department = JohnsonAndJohnsonMarketing,
            DateOfBirth = DateTime.Parse("1996-02-06"),
            ProfilePicture = "female_085.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh014 = new Employee
        {
            FirstName = "Anthony",
            LastName = "Hammond",
            Department = JohnsonAndJohnsonAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1997-07-16"),
            ProfilePicture = "male_131.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh015 = new Employee
        {
            FirstName = "Haley",
            LastName = "Daniels",
            Department = FacebookMarketing,
            DateOfBirth = DateTime.Parse("1993-05-15"),
            ProfilePicture = "male_132.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh016 = new Employee
        {
            FirstName = "Ray",
            LastName = "Franco",
            Department = FacebookAccountingAndFinance,
            DateOfBirth = DateTime.Parse("2000-07-26"),
            ProfilePicture = "male_133.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh017 = new Employee
        {
            FirstName = "Sigourney",
            LastName = "Knight",
            Department = AlphabetMarketing,
            DateOfBirth = DateTime.Parse("1993-03-13"),
            ProfilePicture = "male_134.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh018 = new Employee
        {
            FirstName = "Martina",
            LastName = "Harvey",
            Department = AlphabetAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1991-05-02"),
            ProfilePicture = "female_086.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh019 = new Employee
        {
            FirstName = "Dane",
            LastName = "English",
            Department = ExxonMobilMarketing,
            DateOfBirth = DateTime.Parse("2001-04-07"),
            ProfilePicture = "male_135.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        public static Employee dh020 = new Employee
        {
            FirstName = "Alfreda",
            LastName = "Cline",
            Department = ExxonMobilAccountingAndFinance,
            DateOfBirth = DateTime.Parse("1999-01-07"),
            ProfilePicture = "female_087.jpg",
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.DepartmentHead
        };
        #endregion
        public static List<Employee> data;
        static SeedDepartmentHead()
        {
            data = new List<Employee>();
            data.Add(dh001);
            data.Add(dh002);
            data.Add(dh003);
            data.Add(dh004);
            data.Add(dh005);
            data.Add(dh006);
            data.Add(dh007);
            data.Add(dh008);
            data.Add(dh009);
            data.Add(dh010);
            data.Add(dh011);
            data.Add(dh012);
            data.Add(dh013);
            data.Add(dh014);
            data.Add(dh015);
            data.Add(dh016);
            data.Add(dh017);
            data.Add(dh018);
            data.Add(dh019);
            data.Add(dh020);
        }
    }
}
