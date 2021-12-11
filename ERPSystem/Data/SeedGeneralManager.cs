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
            ProfilePicture = "female_064.jpg",
            Company = Walmart,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm002 = new Employee
        {
            FirstName = "Nash",
            LastName = "Stokes",
            DateOfBirth = DateTime.Parse("1984-03-15"),
            ProfilePicture = "male_098.jpg",
            Company = Amazon,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm003 = new Employee
        {
            FirstName = "Isaiah",
            LastName = "Hoffman",
            DateOfBirth = DateTime.Parse("1995-11-03"),
            ProfilePicture = "female_065.jpg",
            Company = Apple,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm004 = new Employee
        {
            FirstName = "Orlando",
            LastName = "Reese",
            DateOfBirth = DateTime.Parse("1986-01-23"),
            ProfilePicture = "male_099.jpg",
            Company = FordMotor,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm005 = new Employee
        {
            FirstName = "Simon",
            LastName = "Cummings",
            DateOfBirth = DateTime.Parse("2000-12-20"),
            ProfilePicture = "male_100.jpg",
            Company = FedEx,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm006 = new Employee
        {
            FirstName = "Briar",
            LastName = "Monroe",
            DateOfBirth = DateTime.Parse("2001-04-27"),
            ProfilePicture = "male_101.jpg",
            Company = BankOfAmerica,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm007 = new Employee
        {
            FirstName = "Celeste",
            LastName = "Bartlett",
            DateOfBirth = DateTime.Parse("1987-12-21"),
            ProfilePicture = "female_066.jpg",
            Company = JohnsonAndJohnson,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm008 = new Employee
        {
            FirstName = "Christen",
            LastName = "Osborne",
            DateOfBirth = DateTime.Parse("1993-08-13"),
            ProfilePicture = "female_067.jpg",
            Company = Facebook,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm009 = new Employee
        {
            FirstName = "Gail",
            LastName = "Raymond",
            DateOfBirth = DateTime.Parse("1993-04-06"),
            ProfilePicture = "male_102.jpg",
            Company = Alphabet,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.GeneralManager
        };
        public static Employee gm010 = new Employee
        {
            FirstName = "Melvin",
            LastName = "Brewer",
            DateOfBirth = DateTime.Parse("1992-04-25"),
            ProfilePicture = "male_103.jpg",
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
