using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedPosition;
using static ERPSystem.Data.SeedProjectManager;

namespace ERPSystem.Data
{
    public static class SeedProject
    {
        #region Create Projects
        public static Project p001 = new Project
        {
            Name = "alpha",
            ProjectManager = pm001,
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0101,pos0102,pos0103,pos0104,pos0105,pos0106,pos0107,pos0108,pos0109
            }
        };
        public static Project p002 = new Project
        {
            Name = "beta",
            ProjectManager = pm002,
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0201,pos0202,pos0203,pos0204,pos0205,pos0206,pos0207,pos0208,pos0209
            }
        };
        public static Project p003 = new Project
        {
            Name = "gamma",
            ProjectManager = pm003,
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0301,pos0302,pos0303,pos0304,pos0305,pos0306,pos0307,pos0308,pos0309
            }
        };
        public static Project p004 = new Project
        {
            Name = "delta",
            ProjectManager = pm004,
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0401,pos0402,pos0403,pos0404,pos0405,pos0406,pos0407,pos0408,pos0409
            }
        };
        public static Project p005 = new Project
        {
            Name = "epsilon",
            ProjectManager = pm005,
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0501,pos0502,pos0503,pos0504,pos0505,pos0506,pos0507,pos0508,pos0509
            }
        };
        public static Project p006 = new Project
        {
            Name = "zeta",
            ProjectManager = pm006,
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0601,pos0602,pos0603,pos0604,pos0605,pos0606,pos0607,pos0608,pos0609
            }
        };
        public static Project p007 = new Project
        {
            Name = "kappa",
            ProjectManager = pm007,
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0701,pos0702,pos0703,pos0704,pos0705,pos0706,pos0707,pos0708,pos0709
            }
        };
        public static Project p008 = new Project
        {
            Name = "omicron",
            ProjectManager = pm008,
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0801,pos0802,pos0803,pos0804,pos0805,pos0806,pos0807,pos0808,pos0809
            }
        };
        public static Project p009 = new Project
        {
            Name = "sigma",
            ProjectManager = pm009,
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos0901,pos0902,pos0903,pos0904,pos0905,pos0906,pos0907,pos0908,pos0909
            }
        };
        public static Project p010 = new Project
        {
            Name = "tau",
            ProjectManager = pm010,
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos1001,pos1002,pos1003,pos1004,pos1005,pos1006,pos1007,pos1008,pos1009
            }
        };
        public static Project p011 = new Project
        {
            Name = "upsilon",
            ProjectManager = pm011,
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos1101,pos1102,pos1103,pos1104,pos1105,pos1106,pos1107,pos1108,pos1109
            }
        };
        public static Project p012 = new Project
        {
            Name = "omega",
            ProjectManager = pm012,
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            ProjectState = ProjectState.Active,
            Positions = new List<Position>
            {
                pos1201,pos1202,pos1203,pos1204,pos1205,pos1206,pos1207,pos1208,pos1209
            }
        };
        #endregion
    }
}
