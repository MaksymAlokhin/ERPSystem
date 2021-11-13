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
        public static ProjectManager pm001 = new ProjectManager
        {
            FirstName = "Channing",
            LastName = "Fuentes",
            DateOfBirth = DateTime.Parse("1981-11-25"),
            Project = p001,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm002 = new ProjectManager
        {
            FirstName = "Cooper",
            LastName = "Jacobson",
            DateOfBirth = DateTime.Parse("1989-07-21"),
            Project = p002,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm003 = new ProjectManager
        {
            FirstName = "Preston",
            LastName = "Holman",
            DateOfBirth = DateTime.Parse("1996-08-05"),
            Project = p003,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm004 = new ProjectManager
        {
            FirstName = "Judah",
            LastName = "Bush",
            DateOfBirth = DateTime.Parse("2000-10-01"),
            Project = p004,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm005 = new ProjectManager
        {
            FirstName = "Lesley",
            LastName = "Evans",
            DateOfBirth = DateTime.Parse("2001-07-13"),
            Project = p005,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm006 = new ProjectManager
        {
            FirstName = "Astra",
            LastName = "Robbins",
            DateOfBirth = DateTime.Parse("1985-10-04"),
            Project = p006,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm007 = new ProjectManager
        {
            FirstName = "Jade",
            LastName = "Aguilar",
            DateOfBirth = DateTime.Parse("1989-06-08"),
            Project = p007,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm008 = new ProjectManager
        {
            FirstName = "James",
            LastName = "Gonzalez",
            DateOfBirth = DateTime.Parse("2001-09-06"),
            Project = p008,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm009 = new ProjectManager
        {
            FirstName = "Brianna",
            LastName = "Cook",
            DateOfBirth = DateTime.Parse("1993-10-30"),
            Project = p009,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm010 = new ProjectManager
        {
            FirstName = "Rosalyn",
            LastName = "Melton",
            DateOfBirth = DateTime.Parse("2001-06-04"),
            Project = p010,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm011 = new ProjectManager
        {
            FirstName = "Jonah",
            LastName = "Robertson",
            DateOfBirth = DateTime.Parse("1986-05-29"),
            Project = p011,
            EmployeeState = EmployeeState.Active
        };
        public static ProjectManager pm012 = new ProjectManager
        {
            FirstName = "Nigel",
            LastName = "Mckinney",
            DateOfBirth = DateTime.Parse("1995-09-14"),
            Project = p012,
            EmployeeState = EmployeeState.Active
        };
        #endregion
        public static List<ProjectManager> data;
        static SeedProjectManager()
        {
            data = new List<ProjectManager>();
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
