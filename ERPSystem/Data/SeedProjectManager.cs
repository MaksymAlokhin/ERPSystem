using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedProject;

namespace ERPSystem.Data
{
    public class SeedProjectManager
    {
        #region Create Project Managers
        public static Employee pm001 = new Employee
        {
            FirstName = "Channing",
            LastName = "Fuentes",
            DateOfBirth = DateTime.Parse("1981-11-25"),
            ProfilePicture = "male_118.jpg",
            Project = p001,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm002 = new Employee
        {
            FirstName = "Cooper",
            LastName = "Jacobson",
            DateOfBirth = DateTime.Parse("1989-07-21"),
            ProfilePicture = "male_119.jpg",
            Project = p002,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm003 = new Employee
        {
            FirstName = "Preston",
            LastName = "Holman",
            DateOfBirth = DateTime.Parse("1996-08-05"),
            ProfilePicture = "male_120.jpg",
            Project = p003,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm004 = new Employee
        {
            FirstName = "Judah",
            LastName = "Bush",
            DateOfBirth = DateTime.Parse("2000-10-01"),
            ProfilePicture = "male_121.jpg",
            Project = p004,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm005 = new Employee
        {
            FirstName = "Lesley",
            LastName = "Evans",
            DateOfBirth = DateTime.Parse("2001-07-13"),
            ProfilePicture = "female_074.jpg",
            Project = p005,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm006 = new Employee
        {
            FirstName = "Astra",
            LastName = "Robbins",
            DateOfBirth = DateTime.Parse("1985-10-04"),
            ProfilePicture = "female_075.jpg",
            Project = p006,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm007 = new Employee
        {
            FirstName = "Jade",
            LastName = "Aguilar",
            DateOfBirth = DateTime.Parse("1989-06-08"),
            ProfilePicture = "female_076.jpg",
            Project = p007,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm008 = new Employee
        {
            FirstName = "James",
            LastName = "Gonzalez",
            DateOfBirth = DateTime.Parse("2001-09-06"),
            ProfilePicture = "male_122.jpg",
            Project = p008,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm009 = new Employee
        {
            FirstName = "Brianna",
            LastName = "Cook",
            DateOfBirth = DateTime.Parse("1993-10-30"),
            ProfilePicture = "female_077.jpg",
            Project = p009,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm010 = new Employee
        {
            FirstName = "Rosalyn",
            LastName = "Melton",
            DateOfBirth = DateTime.Parse("2001-06-04"),
            ProfilePicture = "female_078.jpg",
            Project = p010,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm011 = new Employee
        {
            FirstName = "Jonah",
            LastName = "Robertson",
            DateOfBirth = DateTime.Parse("1986-05-29"),
            ProfilePicture = "female_079.jpg",
            Project = p011,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        public static Employee pm012 = new Employee
        {
            FirstName = "Nigel",
            LastName = "Mckinney",
            DateOfBirth = DateTime.Parse("1995-09-14"),
            ProfilePicture = "male_123.jpg",
            Project = p012,
            EmployeeState = EmployeeState.Active,
            EmployeeRole = EmployeeRole.ProjectManager
        };
        #endregion
        public static List<Employee> data;
        static SeedProjectManager()
        {
            data = new List<Employee>();
            data.Add(pm001);
            data.Add(pm002);
            data.Add(pm003);
            data.Add(pm004);
            data.Add(pm005);
            data.Add(pm006);
            data.Add(pm007);
            data.Add(pm008);
            data.Add(pm009);
            data.Add(pm010);
            data.Add(pm011);
            data.Add(pm012);
        }
    }
}
