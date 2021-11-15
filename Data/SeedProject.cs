using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedDepartment;

namespace ERPSystem.Data
{
    public static class SeedProject
    {
        #region Create Projects
        public static Project p001 = new Project
        {
            Name = "Alpha",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p002 = new Project
        {
            Name = "Beta",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p003 = new Project
        {
            Name = "Gamma",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p004 = new Project
        {
            Name = "Delta",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p005 = new Project
        {
            Name = "Epsilon",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p006 = new Project
        {
            Name = "Zeta",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p007 = new Project
        {
            Name = "Kappa",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p008 = new Project
        {
            Name = "Omicron",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p009 = new Project
        {
            Name = "Sigma",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p010 = new Project
        {
            Name = "Tau",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p011 = new Project
        {
            Name = "Upsilon",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        public static Project p012 = new Project
        {
            Name = "Omega",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            ProjectState = ProjectState.Active,
            Department = WalmartMarketing
        };
        #endregion
        public static List<Project> data;
        static SeedProject()
        {
            data = new List<Project>();
            data.Add(p001);
            data.Add(p002);
            data.Add(p003);
            data.Add(p004);
            data.Add(p005);
            data.Add(p006);
            data.Add(p007);
            data.Add(p008);
            data.Add(p009);
            data.Add(p010);
            data.Add(p011);
            data.Add(p012);
        }
    }
}
