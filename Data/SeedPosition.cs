using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedProject;

namespace ERPSystem.Data
{
    public class SeedPosition
    {
        #region Create Positions
        public static Position pos0101 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0102 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0103 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0104 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0105 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0106 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0107 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0108 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0109 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            PositionState = PositionState.Active,
            Project = p001
        };
        public static Position pos0201 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0202 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0203 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0204 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0205 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0206 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0207 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0208 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0209 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            PositionState = PositionState.Active,
            Project = p002
        };
        public static Position pos0301 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0302 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0303 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0304 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0305 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0306 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0307 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0308 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0309 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            PositionState = PositionState.Active,
            Project = p003
        };
        public static Position pos0401 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0402 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0403 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0404 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0405 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0406 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0407 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0408 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0409 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            PositionState = PositionState.Active,
            Project = p004
        };
        public static Position pos0501 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0502 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0503 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0504 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0505 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0506 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0507 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0508 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0509 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            PositionState = PositionState.Active,
            Project = p005
        };
        public static Position pos0601 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0602 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0603 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0604 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0605 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0606 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0607 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0608 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0609 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            PositionState = PositionState.Active,
            Project = p006
        };
        public static Position pos0701 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0702 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0703 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0704 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0705 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0706 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0707 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0708 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0709 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            PositionState = PositionState.Active,
            Project = p007
        };
        public static Position pos0801 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0802 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0803 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0804 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0805 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0806 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0807 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0808 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0809 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            PositionState = PositionState.Active,
            Project = p008
        };
        public static Position pos0901 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos0902 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos0903 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos0904 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos0905 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos0906 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos0907 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos0908 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos0909 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            PositionState = PositionState.Active,
            Project = p009
        };
        public static Position pos1001 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1002 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1003 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1004 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1005 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1006 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1007 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1008 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1009 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            PositionState = PositionState.Active,
            Project = p010
        };
        public static Position pos1101 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1102 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1103 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1104 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1105 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1106 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1107 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1108 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1109 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            PositionState = PositionState.Active,
            Project = p011
        };
        public static Position pos1201 = new Position
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        public static Position pos1202 = new Position
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        public static Position pos1203 = new Position
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        public static Position pos1204 = new Position
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        public static Position pos1205 = new Position
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        public static Position pos1206 = new Position
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        public static Position pos1207 = new Position
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        public static Position pos1208 = new Position
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        public static Position pos1209 = new Position
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            PositionState = PositionState.Active,
            Project = p012
        };
        #endregion
        public static List<Position> data;
        static SeedPosition()
        {
            data = new List<Position>();
            data.Add(pos0101);
            data.Add(pos0102);
            data.Add(pos0103);
            data.Add(pos0104);
            data.Add(pos0105);
            data.Add(pos0106);
            data.Add(pos0107);
            data.Add(pos0108);
            data.Add(pos0109);
            data.Add(pos0201);
            data.Add(pos0202);
            data.Add(pos0203);
            data.Add(pos0204);
            data.Add(pos0205);
            data.Add(pos0206);
            data.Add(pos0207);
            data.Add(pos0208);
            data.Add(pos0209);
            data.Add(pos0301);
            data.Add(pos0302);
            data.Add(pos0303);
            data.Add(pos0304);
            data.Add(pos0305);
            data.Add(pos0306);
            data.Add(pos0307);
            data.Add(pos0308);
            data.Add(pos0309);
            data.Add(pos0401);
            data.Add(pos0402);
            data.Add(pos0403);
            data.Add(pos0404);
            data.Add(pos0405);
            data.Add(pos0406);
            data.Add(pos0407);
            data.Add(pos0408);
            data.Add(pos0409);
            data.Add(pos0501);
            data.Add(pos0502);
            data.Add(pos0503);
            data.Add(pos0504);
            data.Add(pos0505);
            data.Add(pos0506);
            data.Add(pos0507);
            data.Add(pos0508);
            data.Add(pos0509);
            data.Add(pos0601);
            data.Add(pos0602);
            data.Add(pos0603);
            data.Add(pos0604);
            data.Add(pos0605);
            data.Add(pos0606);
            data.Add(pos0607);
            data.Add(pos0608);
            data.Add(pos0609);
            data.Add(pos0701);
            data.Add(pos0702);
            data.Add(pos0703);
            data.Add(pos0704);
            data.Add(pos0705);
            data.Add(pos0706);
            data.Add(pos0707);
            data.Add(pos0708);
            data.Add(pos0709);
            data.Add(pos0801);
            data.Add(pos0802);
            data.Add(pos0803);
            data.Add(pos0804);
            data.Add(pos0805);
            data.Add(pos0806);
            data.Add(pos0807);
            data.Add(pos0808);
            data.Add(pos0809);
            data.Add(pos0901);
            data.Add(pos0902);
            data.Add(pos0903);
            data.Add(pos0904);
            data.Add(pos0905);
            data.Add(pos0906);
            data.Add(pos0907);
            data.Add(pos0908);
            data.Add(pos0909);
            data.Add(pos1001);
            data.Add(pos1002);
            data.Add(pos1003);
            data.Add(pos1004);
            data.Add(pos1005);
            data.Add(pos1006);
            data.Add(pos1007);
            data.Add(pos1008);
            data.Add(pos1009);
            data.Add(pos1101);
            data.Add(pos1102);
            data.Add(pos1103);
            data.Add(pos1104);
            data.Add(pos1105);
            data.Add(pos1106);
            data.Add(pos1107);
            data.Add(pos1108);
            data.Add(pos1109);
            data.Add(pos1201);
            data.Add(pos1202);
            data.Add(pos1203);
            data.Add(pos1204);
            data.Add(pos1205);
            data.Add(pos1206);
            data.Add(pos1207);
            data.Add(pos1208);
            data.Add(pos1209);
        }
    }
}
