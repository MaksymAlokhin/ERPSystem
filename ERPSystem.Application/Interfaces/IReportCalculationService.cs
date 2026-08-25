using System;
using System.Threading.Tasks;
using ERPSystem.Application.Dtos;

namespace ERPSystem.Application.Interfaces
{
    // Computes worked hours for an assignment up to a given date, based on
    // business days and the assignment's FTE.
    public interface IReportCalculationService
    {
        Task<ReportHoursResult> GetHoursAsync(DateTime date, int assignmentId);
    }
}
