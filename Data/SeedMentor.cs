using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedBranch;

namespace ERPSystem.Data
{
    public static class SeedMentor
    {
        #region Create Mentors
        public static Employee m001 = new Employee
        {
            FirstName = "Colby",
            LastName = "Townsend",
            DateOfBirth = DateTime.Parse("1984-06-02"),
            Branch = WalmartNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m002 = new Employee
        {
            FirstName = "Karly",
            LastName = "Rowe",
            DateOfBirth = DateTime.Parse("1997-01-13"),
            Branch = WalmartEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m003 = new Employee
        {
            FirstName = "Ezra",
            LastName = "Soto",
            DateOfBirth = DateTime.Parse("2001-08-23"),
            Branch = AmazonNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m004 = new Employee
        {
            FirstName = "Clinton",
            LastName = "Bentley",
            DateOfBirth = DateTime.Parse("1988-12-09"),
            Branch = AmazonEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m005 = new Employee
        {
            FirstName = "Vera",
            LastName = "Lawson",
            DateOfBirth = DateTime.Parse("1986-03-03"),
            Branch = AppleNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m006 = new Employee
        {
            FirstName = "Ryder",
            LastName = "Reynolds",
            DateOfBirth = DateTime.Parse("1995-04-21"),
            Branch = AppleEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m007 = new Employee
        {
            FirstName = "Nissim",
            LastName = "Munoz",
            DateOfBirth = DateTime.Parse("1983-05-15"),
            Branch = FordMotorNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m008 = new Employee
        {
            FirstName = "Seth",
            LastName = "Thompson",
            DateOfBirth = DateTime.Parse("1992-11-01"),
            Branch = FordMotorEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m009 = new Employee
        {
            FirstName = "Channing",
            LastName = "Chang",
            DateOfBirth = DateTime.Parse("1998-03-09"),
            Branch = FedExNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m010 = new Employee
        {
            FirstName = "Nissim",
            LastName = "Bryan",
            DateOfBirth = DateTime.Parse("1990-06-06"),
            Branch = FedExEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m011 = new Employee
        {
            FirstName = "Sebastian",
            LastName = "Hansen",
            DateOfBirth = DateTime.Parse("1995-04-29"),
            Branch = BankOfAmericaNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m012 = new Employee
        {
            FirstName = "Lester",
            LastName = "Zamora",
            DateOfBirth = DateTime.Parse("1993-06-11"),
            Branch = BankOfAmericaEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m013 = new Employee
        {
            FirstName = "Scarlett",
            LastName = "Gallegos",
            DateOfBirth = DateTime.Parse("1989-08-25"),
            Branch = JohnsonAndJohnsonNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m014 = new Employee
        {
            FirstName = "Quinn",
            LastName = "Wilder",
            DateOfBirth = DateTime.Parse("2000-12-27"),
            Branch = JohnsonAndJohnsonEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m015 = new Employee
        {
            FirstName = "Barry",
            LastName = "Fuller",
            DateOfBirth = DateTime.Parse("1988-01-27"),
            Branch = FacebookNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m016 = new Employee
        {
            FirstName = "Omar",
            LastName = "Hudson",
            DateOfBirth = DateTime.Parse("1987-05-22"),
            Branch = FacebookEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m017 = new Employee
        {
            FirstName = "Sierra",
            LastName = "Emerson",
            DateOfBirth = DateTime.Parse("1990-09-10"),
            Branch = AlphabetNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m018 = new Employee
        {
            FirstName = "Summer",
            LastName = "Cabrera",
            DateOfBirth = DateTime.Parse("1991-03-06"),
            Branch = AlphabetEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m019 = new Employee
        {
            FirstName = "Melvin",
            LastName = "Sykes",
            DateOfBirth = DateTime.Parse("1993-02-12"),
            Branch = ExxonMobilNorthAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        public static Employee m020 = new Employee
        {
            FirstName = "Rogan",
            LastName = "Warren",
            DateOfBirth = DateTime.Parse("1992-08-24"),
            Branch = ExxonMobilEurope,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.Mentor
        };
        #endregion
        public static List<Employee> data;
        static SeedMentor()
        {
            data = new List<Employee>();
            data.Add(m001);
            data.Add(m002);
            data.Add(m003);
            data.Add(m004);
            data.Add(m005);
            data.Add(m006);
            data.Add(m007);
            data.Add(m008);
            data.Add(m009);
            data.Add(m010);
            data.Add(m011);
            data.Add(m012);
            data.Add(m013);
            data.Add(m014);
            data.Add(m015);
            data.Add(m016);
            data.Add(m017);
            data.Add(m018);
            data.Add(m019);
            data.Add(m020);
        }
    }
}
