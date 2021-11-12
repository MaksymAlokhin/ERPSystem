using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Data
{
    public static class SeedMentor
    {
        #region Create Employees
        public static Mentor m001 = new Mentor
        {
            FirstName = "Colby",
            LastName = "Townsend",
            DateOfBirth = DateTime.Parse("1984-06-02"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m002 = new Mentor
        {
            FirstName = "Karly",
            LastName = "Rowe",
            DateOfBirth = DateTime.Parse("1997-01-13"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m003 = new Mentor
        {
            FirstName = "Ezra",
            LastName = "Soto",
            DateOfBirth = DateTime.Parse("2001-08-23"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m004 = new Mentor
        {
            FirstName = "Clinton",
            LastName = "Bentley",
            DateOfBirth = DateTime.Parse("1988-12-09"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m005 = new Mentor
        {
            FirstName = "Vera",
            LastName = "Lawson",
            DateOfBirth = DateTime.Parse("1986-03-03"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m006 = new Mentor
        {
            FirstName = "Ryder",
            LastName = "Reynolds",
            DateOfBirth = DateTime.Parse("1995-04-21"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m007 = new Mentor
        {
            FirstName = "Nissim",
            LastName = "Munoz",
            DateOfBirth = DateTime.Parse("1983-05-15"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m008 = new Mentor
        {
            FirstName = "Seth",
            LastName = "Thompson",
            DateOfBirth = DateTime.Parse("1992-11-01"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m009 = new Mentor
        {
            FirstName = "Channing",
            LastName = "Chang",
            DateOfBirth = DateTime.Parse("1998-03-09"),
            EmployeeState = EmployeeState.Active
        };
        public static Mentor m010 = new Mentor
        {
            FirstName = "Nissim",
            LastName = "Bryan",
            DateOfBirth = DateTime.Parse("1990-06-06"),
            EmployeeState = EmployeeState.Active
        };
        #endregion
        public static List<Mentor> data;
        static SeedMentor()
        {
            data = new List<Mentor>();
            data.Add(m006);
            data.Add(m007);
            data.Add(m008);
            data.Add(m009);
            data.Add(m010);
        }

    }
}
