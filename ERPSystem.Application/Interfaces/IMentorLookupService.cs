using System.Collections.Generic;
using System.Threading.Tasks;
using ERPSystem.Application.Dtos;

namespace ERPSystem.Application.Interfaces
{
    // Builds the "mentor" dropdown for the Employee form: any employee at any
    // branch of the company reached via the selected branch/department/project.
    public interface IMentorLookupService
    {
        Task<List<MentorOption>> GetMentorsByBranchAsync(string branchId);
        Task<List<MentorOption>> GetMentorsByDepartmentAsync(string departmentId);
        Task<List<MentorOption>> GetMentorsByProjectAsync(string projectId);
    }
}
