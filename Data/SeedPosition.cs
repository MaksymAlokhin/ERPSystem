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
        }
    }
}
