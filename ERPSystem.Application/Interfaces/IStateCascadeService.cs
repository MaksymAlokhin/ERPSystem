using System.Collections.Generic;

namespace ERPSystem.Application.Interfaces
{
    // Propagates Active/Inactive state changes down (and, where a parent link
    // was removed, up) the Company -> Branch/Department -> Project -> Position -> Assignment
    // hierarchy whenever one of those entities changes state.
    public interface IStateCascadeService
    {
        void UpdateCompanyDependants(List<int> ids);
        void UpdateBranchDependants(List<int> ids);
        void UpdateDepartmentDependants(List<int> ids);
        void UpdateProjectDependants(List<int> ids);
        void UpdatePositionDependants(List<int> ids);
        void UpdateWhenParentIsNull();
    }
}
