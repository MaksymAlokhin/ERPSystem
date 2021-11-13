using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedPosition;
using static ERPSystem.Data.SeedWorker;

namespace ERPSystem.Data
{
    public class SeedAssignment
    {
        #region Create Assignments
        public static Assignment as0101 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w001,
            AssignmentState = AssignmentState.Active,
            Position = pos0101
        };
        public static Assignment as0102 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w002,
            AssignmentState = AssignmentState.Active,
            Position = pos0102
        };
        public static Assignment as0103 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w003,
            AssignmentState = AssignmentState.Active,
            Position = pos0103
        };
        public static Assignment as0104 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w004,
            AssignmentState = AssignmentState.Active,
            Position = pos0104
        };
        public static Assignment as0105 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w005,
            AssignmentState = AssignmentState.Active,
            Position = pos0105
        };
        public static Assignment as0106 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w006,
            AssignmentState = AssignmentState.Active,
            Position = pos0106
        };
        public static Assignment as0107 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w007,
            AssignmentState = AssignmentState.Active,
            Position = pos0107
        };
        public static Assignment as0108 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w008,
            AssignmentState = AssignmentState.Active,
            Position = pos0108
        };
        public static Assignment as0109 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Worker = w009,
            AssignmentState = AssignmentState.Active,
            Position = pos0109
        };
        public static Assignment as0201 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w010,
            AssignmentState = AssignmentState.Active,
            Position = pos0201
        };
        public static Assignment as0202 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w011,
            AssignmentState = AssignmentState.Active,
            Position = pos0202
        };
        public static Assignment as0203 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w012,
            AssignmentState = AssignmentState.Active,
            Position = pos0203
        };
        public static Assignment as0204 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w013,
            AssignmentState = AssignmentState.Active,
            Position = pos0204
        };
        public static Assignment as0205 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w014,
            AssignmentState = AssignmentState.Active,
            Position = pos0205
        };
        public static Assignment as0206 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w015,
            AssignmentState = AssignmentState.Active,
            Position = pos0206
        };
        public static Assignment as0207 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w016,
            AssignmentState = AssignmentState.Active,
            Position = pos0207
        };
        public static Assignment as0208 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w017,
            AssignmentState = AssignmentState.Active,
            Position = pos0208
        };
        public static Assignment as0209 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Worker = w018,
            AssignmentState = AssignmentState.Active,
            Position = pos0209
        };
        public static Assignment as0301 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w019,
            AssignmentState = AssignmentState.Active,
            Position = pos0301
        };
        public static Assignment as0302 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w020,
            AssignmentState = AssignmentState.Active,
            Position = pos0302
        };
        public static Assignment as0303 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w021,
            AssignmentState = AssignmentState.Active,
            Position = pos0303
        };
        public static Assignment as0304 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w022,
            AssignmentState = AssignmentState.Active,
            Position = pos0304
        };
        public static Assignment as0305 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w023,
            AssignmentState = AssignmentState.Active,
            Position = pos0305
        };
        public static Assignment as0306 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w024,
            AssignmentState = AssignmentState.Active,
            Position = pos0306
        };
        public static Assignment as0307 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w025,
            AssignmentState = AssignmentState.Active,
            Position = pos0307
        };
        public static Assignment as0308 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w026,
            AssignmentState = AssignmentState.Active,
            Position = pos0308
        };
        public static Assignment as0309 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Worker = w027,
            AssignmentState = AssignmentState.Active,
            Position = pos0309
        };
        public static Assignment as0401 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w028,
            AssignmentState = AssignmentState.Active,
            Position = pos0401
        };
        public static Assignment as0402 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w029,
            AssignmentState = AssignmentState.Active,
            Position = pos0402
        };
        public static Assignment as0403 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w030,
            AssignmentState = AssignmentState.Active,
            Position = pos0403
        };
        public static Assignment as0404 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w031,
            AssignmentState = AssignmentState.Active,
            Position = pos0404
        };
        public static Assignment as0405 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w032,
            AssignmentState = AssignmentState.Active,
            Position = pos0405
        };
        public static Assignment as0406 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w033,
            AssignmentState = AssignmentState.Active,
            Position = pos0406
        };
        public static Assignment as0407 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w034,
            AssignmentState = AssignmentState.Active,
            Position = pos0407
        };
        public static Assignment as0408 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w035,
            AssignmentState = AssignmentState.Active,
            Position = pos0408
        };
        public static Assignment as0409 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Worker = w036,
            AssignmentState = AssignmentState.Active,
            Position = pos0409
        };
        public static Assignment as0501 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w037,
            AssignmentState = AssignmentState.Active,
            Position = pos0501
        };
        public static Assignment as0502 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w038,
            AssignmentState = AssignmentState.Active,
            Position = pos0502
        };
        public static Assignment as0503 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w039,
            AssignmentState = AssignmentState.Active,
            Position = pos0503
        };
        public static Assignment as0504 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w040,
            AssignmentState = AssignmentState.Active,
            Position = pos0504
        };
        public static Assignment as0505 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w041,
            AssignmentState = AssignmentState.Active,
            Position = pos0505
        };
        public static Assignment as0506 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w042,
            AssignmentState = AssignmentState.Active,
            Position = pos0506
        };
        public static Assignment as0507 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w043,
            AssignmentState = AssignmentState.Active,
            Position = pos0507
        };
        public static Assignment as0508 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w044,
            AssignmentState = AssignmentState.Active,
            Position = pos0508
        };
        public static Assignment as0509 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Worker = w045,
            AssignmentState = AssignmentState.Active,
            Position = pos0509
        };
        public static Assignment as0601 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w046,
            AssignmentState = AssignmentState.Active,
            Position = pos0601
        };
        public static Assignment as0602 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w047,
            AssignmentState = AssignmentState.Active,
            Position = pos0602
        };
        public static Assignment as0603 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w048,
            AssignmentState = AssignmentState.Active,
            Position = pos0603
        };
        public static Assignment as0604 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w049,
            AssignmentState = AssignmentState.Active,
            Position = pos0604
        };
        public static Assignment as0605 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w050,
            AssignmentState = AssignmentState.Active,
            Position = pos0605
        };
        public static Assignment as0606 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w051,
            AssignmentState = AssignmentState.Active,
            Position = pos0606
        };
        public static Assignment as0607 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w052,
            AssignmentState = AssignmentState.Active,
            Position = pos0607
        };
        public static Assignment as0608 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w053,
            AssignmentState = AssignmentState.Active,
            Position = pos0608
        };
        public static Assignment as0609 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Worker = w054,
            AssignmentState = AssignmentState.Active,
            Position = pos0609
        };
        public static Assignment as0701 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w055,
            AssignmentState = AssignmentState.Active,
            Position = pos0701
        };
        public static Assignment as0702 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w056,
            AssignmentState = AssignmentState.Active,
            Position = pos0702
        };
        public static Assignment as0703 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w057,
            AssignmentState = AssignmentState.Active,
            Position = pos0703
        };
        public static Assignment as0704 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w058,
            AssignmentState = AssignmentState.Active,
            Position = pos0704
        };
        public static Assignment as0705 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w059,
            AssignmentState = AssignmentState.Active,
            Position = pos0705
        };
        public static Assignment as0706 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w060,
            AssignmentState = AssignmentState.Active,
            Position = pos0706
        };
        public static Assignment as0707 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w061,
            AssignmentState = AssignmentState.Active,
            Position = pos0707
        };
        public static Assignment as0708 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w062,
            AssignmentState = AssignmentState.Active,
            Position = pos0708
        };
        public static Assignment as0709 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Worker = w063,
            AssignmentState = AssignmentState.Active,
            Position = pos0709
        };
        public static Assignment as0801 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w064,
            AssignmentState = AssignmentState.Active,
            Position = pos0801
        };
        public static Assignment as0802 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w065,
            AssignmentState = AssignmentState.Active,
            Position = pos0802
        };
        public static Assignment as0803 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w066,
            AssignmentState = AssignmentState.Active,
            Position = pos0803
        };
        public static Assignment as0804 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w067,
            AssignmentState = AssignmentState.Active,
            Position = pos0804
        };
        public static Assignment as0805 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w068,
            AssignmentState = AssignmentState.Active,
            Position = pos0805
        };
        public static Assignment as0806 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w069,
            AssignmentState = AssignmentState.Active,
            Position = pos0806
        };
        public static Assignment as0807 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w070,
            AssignmentState = AssignmentState.Active,
            Position = pos0807
        };
        public static Assignment as0808 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w071,
            AssignmentState = AssignmentState.Active,
            Position = pos0808
        };
        public static Assignment as0809 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Worker = w072,
            AssignmentState = AssignmentState.Active,
            Position = pos0809
        };
        public static Assignment as0901 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w073,
            AssignmentState = AssignmentState.Active,
            Position = pos0901
        };
        public static Assignment as0902 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w074,
            AssignmentState = AssignmentState.Active,
            Position = pos0902
        };
        public static Assignment as0903 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w075,
            AssignmentState = AssignmentState.Active,
            Position = pos0903
        };
        public static Assignment as0904 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w076,
            AssignmentState = AssignmentState.Active,
            Position = pos0904
        };
        public static Assignment as0905 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w077,
            AssignmentState = AssignmentState.Active,
            Position = pos0905
        };
        public static Assignment as0906 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w078,
            AssignmentState = AssignmentState.Active,
            Position = pos0906
        };
        public static Assignment as0907 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w079,
            AssignmentState = AssignmentState.Active,
            Position = pos0907
        };
        public static Assignment as0908 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w080,
            AssignmentState = AssignmentState.Active,
            Position = pos0908
        };
        public static Assignment as0909 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Worker = w081,
            AssignmentState = AssignmentState.Active,
            Position = pos0909
        };
        public static Assignment as1001 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w082,
            AssignmentState = AssignmentState.Active,
            Position = pos1001
        };
        public static Assignment as1002 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w083,
            AssignmentState = AssignmentState.Active,
            Position = pos1002
        };
        public static Assignment as1003 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w084,
            AssignmentState = AssignmentState.Active,
            Position = pos1003
        };
        public static Assignment as1004 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w085,
            AssignmentState = AssignmentState.Active,
            Position = pos1004
        };
        public static Assignment as1005 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w086,
            AssignmentState = AssignmentState.Active,
            Position = pos1005
        };
        public static Assignment as1006 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w087,
            AssignmentState = AssignmentState.Active,
            Position = pos1006
        };
        public static Assignment as1007 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w088,
            AssignmentState = AssignmentState.Active,
            Position = pos1007
        };
        public static Assignment as1008 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w089,
            AssignmentState = AssignmentState.Active,
            Position = pos1008
        };
        public static Assignment as1009 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2019-11-13"),
            EndDate = DateTime.Parse("2023-07-01"),
            FTE = 0.5,
            Worker = w090,
            AssignmentState = AssignmentState.Active,
            Position = pos1009
        };
        public static Assignment as1101 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w091,
            AssignmentState = AssignmentState.Active,
            Position = pos1101
        };
        public static Assignment as1102 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w092,
            AssignmentState = AssignmentState.Active,
            Position = pos1102
        };
        public static Assignment as1103 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w093,
            AssignmentState = AssignmentState.Active,
            Position = pos1103
        };
        public static Assignment as1104 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w094,
            AssignmentState = AssignmentState.Active,
            Position = pos1104
        };
        public static Assignment as1105 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w095,
            AssignmentState = AssignmentState.Active,
            Position = pos1105
        };
        public static Assignment as1106 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w096,
            AssignmentState = AssignmentState.Active,
            Position = pos1106
        };
        public static Assignment as1107 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w097,
            AssignmentState = AssignmentState.Active,
            Position = pos1107
        };
        public static Assignment as1108 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w098,
            AssignmentState = AssignmentState.Active,
            Position = pos1108
        };
        public static Assignment as1109 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-01-07"),
            EndDate = DateTime.Parse("2022-03-05"),
            FTE = 0.5,
            Worker = w099,
            AssignmentState = AssignmentState.Active,
            Position = pos1109
        };
        public static Assignment as1201 = new Assignment
        {
            Name = "Operations Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w100,
            AssignmentState = AssignmentState.Active,
            Position = pos1201
        };
        public static Assignment as1202 = new Assignment
        {
            Name = "Quality Control",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w101,
            AssignmentState = AssignmentState.Active,
            Position = pos1202
        };
        public static Assignment as1203 = new Assignment
        {
            Name = "Accountant",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w102,
            AssignmentState = AssignmentState.Active,
            Position = pos1203
        };
        public static Assignment as1204 = new Assignment
        {
            Name = "Office Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w103,
            AssignmentState = AssignmentState.Active,
            Position = pos1204
        };
        public static Assignment as1205 = new Assignment
        {
            Name = "Receptionist",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w104,
            AssignmentState = AssignmentState.Active,
            Position = pos1205
        };
        public static Assignment as1206 = new Assignment
        {
            Name = "Supervisor",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w105,
            AssignmentState = AssignmentState.Active,
            Position = pos1206
        };
        public static Assignment as1207 = new Assignment
        {
            Name = "Marketing Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w106,
            AssignmentState = AssignmentState.Active,
            Position = pos1207
        };
        public static Assignment as1208 = new Assignment
        {
            Name = "Purchasing Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w107,
            AssignmentState = AssignmentState.Active,
            Position = pos1208
        };
        public static Assignment as1209 = new Assignment
        {
            Name = "Shipping Manager",
            StartDate = DateTime.Parse("2020-01-13"),
            EndDate = DateTime.Parse("2022-05-29"),
            FTE = 0.5,
            Worker = w108,
            AssignmentState = AssignmentState.Active,
            Position = pos1209
        };
        #endregion
        public static List<Assignment> data;
        static SeedAssignment()
        {
            data = new List<Assignment>();
            data.Add(as0101);
            data.Add(as0102);
            data.Add(as0103);
            data.Add(as0104);
            data.Add(as0105);
            data.Add(as0106);
            data.Add(as0107);
            data.Add(as0108);
            data.Add(as0109);
            data.Add(as0201);
            data.Add(as0202);
            data.Add(as0203);
            data.Add(as0204);
            data.Add(as0205);
            data.Add(as0206);
            data.Add(as0207);
            data.Add(as0208);
            data.Add(as0209);
            data.Add(as0301);
            data.Add(as0302);
            data.Add(as0303);
            data.Add(as0304);
            data.Add(as0305);
            data.Add(as0306);
            data.Add(as0307);
            data.Add(as0308);
            data.Add(as0309);
            data.Add(as0401);
            data.Add(as0402);
            data.Add(as0403);
            data.Add(as0404);
            data.Add(as0405);
            data.Add(as0406);
            data.Add(as0407);
            data.Add(as0408);
            data.Add(as0409);
            data.Add(as0501);
            data.Add(as0502);
            data.Add(as0503);
            data.Add(as0504);
            data.Add(as0505);
            data.Add(as0506);
            data.Add(as0507);
            data.Add(as0508);
            data.Add(as0509);
            data.Add(as0601);
            data.Add(as0602);
            data.Add(as0603);
            data.Add(as0604);
            data.Add(as0605);
            data.Add(as0606);
            data.Add(as0607);
            data.Add(as0608);
            data.Add(as0609);
            data.Add(as0701);
            data.Add(as0702);
            data.Add(as0703);
            data.Add(as0704);
            data.Add(as0705);
            data.Add(as0706);
            data.Add(as0707);
            data.Add(as0708);
            data.Add(as0709);
            data.Add(as0801);
            data.Add(as0802);
            data.Add(as0803);
            data.Add(as0804);
            data.Add(as0805);
            data.Add(as0806);
            data.Add(as0807);
            data.Add(as0808);
            data.Add(as0809);
            data.Add(as0901);
            data.Add(as0902);
            data.Add(as0903);
            data.Add(as0904);
            data.Add(as0905);
            data.Add(as0906);
            data.Add(as0907);
            data.Add(as0908);
            data.Add(as0909);
            data.Add(as1001);
            data.Add(as1002);
            data.Add(as1003);
            data.Add(as1004);
            data.Add(as1005);
            data.Add(as1006);
            data.Add(as1007);
            data.Add(as1008);
            data.Add(as1009);
            data.Add(as1101);
            data.Add(as1102);
            data.Add(as1103);
            data.Add(as1104);
            data.Add(as1105);
            data.Add(as1106);
            data.Add(as1107);
            data.Add(as1108);
            data.Add(as1109);
            data.Add(as1201);
            data.Add(as1202);
            data.Add(as1203);
            data.Add(as1204);
            data.Add(as1205);
            data.Add(as1206);
            data.Add(as1207);
            data.Add(as1208);
            data.Add(as1209);
        }
    }
}
