using ERPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERPSystem.Data.SeedAssignment;
using static ERPSystem.Data.SeedEmployee;

namespace ERPSystem.Data
{
    public static class SeedReport
    {
        #region Create Records
        public static Report r001 = new Report
        {
            Hours = 160.0,
            Date = DateTime.Parse("2021-09-07"),
            Assignment = as0101,
            ReportState = ReportState.Approved
        };
        public static Report r002 = new Report
        {
            Hours = 216.0,
            Date = DateTime.Parse("2021-06-13"),
            Assignment = as0102,
            ReportState = ReportState.Approved
        };
        public static Report r003 = new Report
        {
            Hours = 88.0,
            Date = DateTime.Parse("2021-08-29"),
            Assignment = as0103,
            ReportState = ReportState.Approved
        };
        public static Report r004 = new Report
        {
            Hours = 56.0,
            Date = DateTime.Parse("2021-06-23"),
            Assignment = as0104,
            ReportState = ReportState.Submitted
        };
        public static Report r005 = new Report
        {
            Hours = 144.0,
            Date = DateTime.Parse("2021-02-26"),
            Assignment = as0105,
            ReportState = ReportState.Submitted
        };
        public static Report r006 = new Report
        {
            Hours = 24.0,
            Date = DateTime.Parse("2021-11-17"),
            Assignment = as0106,
            ReportState = ReportState.Approved
        };
        public static Report r007 = new Report
        {
            Hours = 40.0,
            Date = DateTime.Parse("2021-02-16"),
            Assignment = as0107,
            ReportState = ReportState.Approved
        };
        public static Report r008 = new Report
        {
            Hours = 72.0,
            Date = DateTime.Parse("2021-01-05"),
            Assignment = as0108,
            ReportState = ReportState.Approved
        };
        public static Report r009 = new Report
        {
            Hours = 248.0,
            Date = DateTime.Parse("2021-09-17"),
            Assignment = as0109,
            ReportState = ReportState.Submitted
        };
        #endregion
        public static List<Report> data;
        static SeedReport()
        {
            data = new List<Report>();
            data.Add(r001);
            data.Add(r002);
            data.Add(r003);
            data.Add(r004);
            data.Add(r005);
            data.Add(r006);
            data.Add(r007);
            data.Add(r008);
            data.Add(r009);
        }
    }
}
