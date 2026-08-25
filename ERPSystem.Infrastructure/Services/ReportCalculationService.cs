using ERPSystem.Application;
using ERPSystem.Application.Dtos;
using ERPSystem.Application.Interfaces;
using ERPSystem.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace ERPSystem.Infrastructure.Services
{
    public class ReportCalculationService : IReportCalculationService
    {
        private const double HoursPerWeek = 8.0;
        private readonly ApplicationDbContext _context;

        public ReportCalculationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReportHoursResult> GetHoursAsync(DateTime date, int assignmentId)
        {
            var assignment = await _context.Assignments.FindAsync(assignmentId);
            if (assignment == null)
                return null;

            if (assignment.StartDate > date)
                return null;

            if (assignment.EndDate < date)
            {
                return new ReportHoursResult
                {
                    hours = DateRangeHelper.GetBusinessDays(assignment.StartDate, assignment.EndDate) * HoursPerWeek * assignment.FTE,
                    date = assignment.EndDate,
                    min = assignment.StartDate,
                    max = assignment.EndDate
                };
            }

            return new ReportHoursResult
            {
                hours = DateRangeHelper.GetBusinessDays(assignment.StartDate, date) * HoursPerWeek * assignment.FTE,
                date = date,
                min = assignment.StartDate,
                max = assignment.EndDate
            };
        }
    }
}
