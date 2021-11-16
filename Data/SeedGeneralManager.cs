using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedCompany;

namespace ERPSystem.Data
{
    public static class SeedGeneralManager
    {
        #region Create General Managers
        public static Employee gm001 = new Employee
        {
            FirstName = "Xyla",
            LastName = "Garza",
            DateOfBirth = DateTime.Parse("1988-02-18"),
            Company = Walmart,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm002 = new Employee
        {
            FirstName = "Nash",
            LastName = "Stokes",
            DateOfBirth = DateTime.Parse("1984-03-15"),
            Company = Amazon,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm003 = new Employee
        {
            FirstName = "Isaiah",
            LastName = "Hoffman",
            DateOfBirth = DateTime.Parse("1995-11-03"),
            Company = Apple,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm004 = new Employee
        {
            FirstName = "Orlando",
            LastName = "Reese",
            DateOfBirth = DateTime.Parse("1986-01-23"),
            Company = FordMotor,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm005 = new Employee
        {
            FirstName = "Simon",
            LastName = "Cummings",
            DateOfBirth = DateTime.Parse("2000-12-20"),
            Company = FedEx,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm006 = new Employee
        {
            FirstName = "Briar",
            LastName = "Monroe",
            DateOfBirth = DateTime.Parse("2001-04-27"),
            Company = BankOfAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm007 = new Employee
        {
            FirstName = "Celeste",
            LastName = "Bartlett",
            DateOfBirth = DateTime.Parse("1987-12-21"),
            Company = JohnsonAndJohnson,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm008 = new Employee
        {
            FirstName = "Christen",
            LastName = "Osborne",
            DateOfBirth = DateTime.Parse("1993-08-13"),
            Company = Facebook,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm009 = new Employee
        {
            FirstName = "Gail",
            LastName = "Raymond",
            DateOfBirth = DateTime.Parse("1993-04-06"),
            Company = Alphabet,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm010 = new Employee
        {
            FirstName = "Melvin",
            LastName = "Brewer",
            DateOfBirth = DateTime.Parse("1992-04-25"),
            Company = ExxonMobil,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        #endregion
        public static List<Employee> data;
        static SeedGeneralManager()
        {
            data = new List<Employee>();
            data.Add(gm001);
            data.Add(gm002);
            data.Add(gm003);
            data.Add(gm004);
            data.Add(gm005);
            data.Add(gm006);
            data.Add(gm007);
            data.Add(gm008);
            data.Add(gm009);
            data.Add(gm010);
        }
    }
}
