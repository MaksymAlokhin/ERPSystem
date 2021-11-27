using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedPosition;
using static ERPSystem.Data.SeedEmployee;

namespace ERPSystem.Data
{
    public class SeedAssignment
    {
        #region Create Assignments
        public static Assignment as0101 = new Assignment
        {
            Name = "Operations Manager Assignment",
            StartDate = DateTime.Parse("2020-12-30"),
            EndDate = DateTime.Parse("2023-03-05"),
            FTE = 0.5,
            Employee = e001,
            AssignmentState = AssignmentState.Active,
            Position = pos0101
        };
        public static Assignment as0102 = new Assignment
        {
            Name = "Quality Control Assignment",
            StartDate = DateTime.Parse("2020-07-10"),
            EndDate = DateTime.Parse("2022-09-09"),
            FTE = 0.5,
            Employee = e002,
            AssignmentState = AssignmentState.Active,
            Position = pos0102
        };
        public static Assignment as0103 = new Assignment
        {
            Name = "Accountant Assignment",
            StartDate = DateTime.Parse("2021-05-10"),
            EndDate = DateTime.Parse("2023-10-09"),
            FTE = 0.5,
            Employee = e003,
            AssignmentState = AssignmentState.Active,
            Position = pos0103
        };
        public static Assignment as0104 = new Assignment
        {
            Name = "Office Manager Assignment",
            StartDate = DateTime.Parse("2021-06-03"),
            EndDate = DateTime.Parse("2022-03-14"),
            FTE = 0.5,
            Employee = e004,
            AssignmentState = AssignmentState.Active,
            Position = pos0104
        };
        public static Assignment as0105 = new Assignment
        {
            Name = "Receptionist Assignment",
            StartDate = DateTime.Parse("2020-09-23"),
            EndDate = DateTime.Parse("2022-05-28"),
            FTE = 0.5,
            Employee = e005,
            AssignmentState = AssignmentState.Active,
            Position = pos0105
        };
        public static Assignment as0106 = new Assignment
        {
            Name = "Supervisor Assignment",
            StartDate = DateTime.Parse("2020-07-28"),
            EndDate = DateTime.Parse("2022-08-03"),
            FTE = 0.5,
            Employee = e006,
            AssignmentState = AssignmentState.Active,
            Position = pos0106
        };
        public static Assignment as0107 = new Assignment
        {
            Name = "Marketing Manager Assignment",
            StartDate = DateTime.Parse("2020-04-29"),
            EndDate = DateTime.Parse("2022-11-04"),
            FTE = 0.5,
            Employee = e007,
            AssignmentState = AssignmentState.Active,
            Position = pos0107
        };
        public static Assignment as0108 = new Assignment
        {
            Name = "Purchasing Manager Assignment",
            StartDate = DateTime.Parse("2020-02-13"),
            EndDate = DateTime.Parse("2022-02-10"),
            FTE = 0.5,
            Employee = e008,
            AssignmentState = AssignmentState.Active,
            Position = pos0108
        };
        public static Assignment as0109 = new Assignment
        {
            Name = "Shipping Manager Assignment",
            StartDate = DateTime.Parse("2021-08-18"),
            EndDate = DateTime.Parse("2022-04-01"),
            FTE = 0.5,
            Employee = e009,
            AssignmentState = AssignmentState.Active,
            Position = pos0109
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
        }
    }
}
