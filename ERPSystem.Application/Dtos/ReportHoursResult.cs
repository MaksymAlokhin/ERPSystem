using System;

namespace ERPSystem.Application.Dtos
{
    public class ReportHoursResult
    {
        public double hours { get; set; }
        public DateTime date { get; set; }
        public DateTime min { get; set; }
        public DateTime max { get; set; }
    }
}
