using System.Threading.Tasks;

namespace ERPSystem.Application.Interfaces
{
    // Returns "Active"/"Inactive" for a given entity id, used by the AJAX
    // handlers that gray out dropdown options for inactive parents.
    public interface IEntityStateLookupService
    {
        Task<string> GetEmployeeStateAsync(string employeeId);
        Task<string> GetCompanyStateAsync(string companyId);
        Task<string> GetDepartmentStateAsync(string departmentId);
        Task<string> GetBranchStateAsync(string branchId);
        Task<string> GetProjectStateAsync(string projectId);
        Task<string> GetPositionStateAsync(string positionId);
        Task<string> GetAssignmentStateAsync(string assignmentId);
    }
}
