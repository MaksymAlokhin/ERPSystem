using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Data
{
    public static class SeedGeneralManager
    {
        #region Create General Managers
        public static GeneralManager gm001 = new GeneralManager
        {
            FirstName = "Xyla",
            LastName = "Garza",
            DateOfBirth = DateTime.Parse("1988-02-18"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm002 = new GeneralManager
        {
            FirstName = "Nash",
            LastName = "Stokes",
            DateOfBirth = DateTime.Parse("1984-03-15"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm003 = new GeneralManager
        {
            FirstName = "Isaiah",
            LastName = "Hoffman",
            DateOfBirth = DateTime.Parse("1995-11-03"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm004 = new GeneralManager
        {
            FirstName = "Orlando",
            LastName = "Reese",
            DateOfBirth = DateTime.Parse("1986-01-23"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm005 = new GeneralManager
        {
            FirstName = "Simon",
            LastName = "Cummings",
            DateOfBirth = DateTime.Parse("2000-12-20"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm006 = new GeneralManager
        {
            FirstName = "Briar",
            LastName = "Monroe",
            DateOfBirth = DateTime.Parse("2001-04-27"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm007 = new GeneralManager
        {
            FirstName = "Celeste",
            LastName = "Bartlett",
            DateOfBirth = DateTime.Parse("1987-12-21"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm008 = new GeneralManager
        {
            FirstName = "Christen",
            LastName = "Osborne",
            DateOfBirth = DateTime.Parse("1993-08-13"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm009 = new GeneralManager
        {
            FirstName = "Gail",
            LastName = "Raymond",
            DateOfBirth = DateTime.Parse("1993-04-06"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm010 = new GeneralManager
        {
            FirstName = "Melvin",
            LastName = "Brewer",
            DateOfBirth = DateTime.Parse("1992-04-25"),
            EmployeeState = EmployeeState.Active
        };
        public static GeneralManager gm011 = new GeneralManager
        {
            FirstName = "Mollie",
            LastName = "Buchanan",
            DateOfBirth = DateTime.Parse("2000-02-16"),
            EmployeeState = EmployeeState.Inactive
        };
        public static GeneralManager gm012 = new GeneralManager
        {
            FirstName = "Yoshio",
            LastName = "Bond",
            DateOfBirth = DateTime.Parse("1993-03-24"),
            EmployeeState = EmployeeState.Inactive
        };
        public static GeneralManager gm013 = new GeneralManager
        {
            FirstName = "Lucy",
            LastName = "Bryant",
            DateOfBirth = DateTime.Parse("2001-05-05"),
            EmployeeState = EmployeeState.Inactive
        };
        public static GeneralManager gm014 = new GeneralManager
        {
            FirstName = "Madison",
            LastName = "Dawson",
            DateOfBirth = DateTime.Parse("1990-11-02"),
            EmployeeState = EmployeeState.Inactive
        };
        public static GeneralManager gm015 = new GeneralManager
        {
            FirstName = "Vanna",
            LastName = "Boyer",
            DateOfBirth = DateTime.Parse("1996-06-28"),
            EmployeeState = EmployeeState.Inactive
        };
        #endregion
        public static List<GeneralManager> data;
        static SeedGeneralManager()
        {
            data = new List<GeneralManager>();
            data.Add(gm011);
            data.Add(gm012);
            data.Add(gm013);
            data.Add(gm014);
            data.Add(gm015);
        }
    }
}
