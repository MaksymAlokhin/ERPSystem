using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Data
{
    public class SeedProjectManager
    {
        #region Create Project Managers
        public static ProjectManager pm001 = new ProjectManager
        {
            FirstName = "Channing",
            LastName = "Fuentes",
            DateOfBirth = DateTime.Parse("1981-11-25"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm002 = new ProjectManager
        {
            FirstName = "Cooper",
            LastName = "Jacobson",
            DateOfBirth = DateTime.Parse("1989-07-21"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm003 = new ProjectManager
        {
            FirstName = "Preston",
            LastName = "Holman",
            DateOfBirth = DateTime.Parse("1996-08-05"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm004 = new ProjectManager
        {
            FirstName = "Judah",
            LastName = "Bush",
            DateOfBirth = DateTime.Parse("2000-10-01"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm005 = new ProjectManager
        {
            FirstName = "Lesley",
            LastName = "Evans",
            DateOfBirth = DateTime.Parse("2001-07-13"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm006 = new ProjectManager
        {
            FirstName = "Astra",
            LastName = "Robbins",
            DateOfBirth = DateTime.Parse("1985-10-04"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm007 = new ProjectManager
        {
            FirstName = "Jade",
            LastName = "Aguilar",
            DateOfBirth = DateTime.Parse("1989-06-08"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm008 = new ProjectManager
        {
            FirstName = "James",
            LastName = "Gonzalez",
            DateOfBirth = DateTime.Parse("2001-09-06"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm009 = new ProjectManager
        {
            FirstName = "Brianna",
            LastName = "Cook",
            DateOfBirth = DateTime.Parse("1993-10-30"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm010 = new ProjectManager
        {
            FirstName = "Rosalyn",
            LastName = "Melton",
            DateOfBirth = DateTime.Parse("2001-06-04"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm011 = new ProjectManager
        {
            FirstName = "Jonah",
            LastName = "Robertson",
            DateOfBirth = DateTime.Parse("1986-05-29"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm012 = new ProjectManager
        {
            FirstName = "Nigel",
            LastName = "Mckinney",
            DateOfBirth = DateTime.Parse("1995-09-14"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm013 = new ProjectManager
        {
            FirstName = "Calvin",
            LastName = "Bowers",
            DateOfBirth = DateTime.Parse("1995-05-29"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm014 = new ProjectManager
        {
            FirstName = "Sylvester",
            LastName = "Burris",
            DateOfBirth = DateTime.Parse("1996-07-29"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm015 = new ProjectManager
        {
            FirstName = "Judah",
            LastName = "Carney",
            DateOfBirth = DateTime.Parse("1987-12-02"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm016 = new ProjectManager
        {
            FirstName = "Madeline",
            LastName = "William",
            DateOfBirth = DateTime.Parse("1999-04-12"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm017 = new ProjectManager
        {
            FirstName = "Dustin",
            LastName = "Guerra",
            DateOfBirth = DateTime.Parse("1982-05-16"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm018 = new ProjectManager
        {
            FirstName = "Dana",
            LastName = "Gardner",
            DateOfBirth = DateTime.Parse("1981-11-08"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm019 = new ProjectManager
        {
            FirstName = "Harper",
            LastName = "Duke",
            DateOfBirth = DateTime.Parse("1994-09-10"),
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm020 = new ProjectManager
        {
            FirstName = "Neville",
            LastName = "Blackwell",
            DateOfBirth = DateTime.Parse("1998-07-12"),
            EmployeeState = EmployeeState.Active
        };
        #endregion
        public static List<ProjectManager> data;
        static SeedProjectManager()
        {
            data = new List<ProjectManager>();
            data.Add(pm014);
            data.Add(pm015);
            data.Add(pm016);
            data.Add(pm017);
            data.Add(pm018);
            data.Add(pm019);
            data.Add(pm020);
        }

    }
}
