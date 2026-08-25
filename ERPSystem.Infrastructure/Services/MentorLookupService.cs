using ERPSystem.Application.Dtos;
using ERPSystem.Application.Interfaces;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Infrastructure.Services
{
    public class MentorLookupService : IMentorLookupService
    {
        private readonly ApplicationDbContext _context;

        public MentorLookupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MentorOption>> GetMentorsByBranchAsync(string branchId)
        {
            if (!string.IsNullOrWhiteSpace(branchId) && Int32.TryParse(branchId, out int id))
            {
                Branch branch = await _context.Branches.FindAsync(id);
                if (branch != null)
                    return await GetMentorsForCompanyAsync(branch.CompanyId);
            }
            return NoMentors();
        }

        public async Task<List<MentorOption>> GetMentorsByDepartmentAsync(string departmentId)
        {
            if (!string.IsNullOrWhiteSpace(departmentId) && Int32.TryParse(departmentId, out int id))
            {
                Department department = await _context.Departments.FindAsync(id);
                if (department != null)
                    return await GetMentorsForCompanyAsync(department.CompanyId);
            }
            return NoMentors();
        }

        public async Task<List<MentorOption>> GetMentorsByProjectAsync(string projectId)
        {
            if (!string.IsNullOrWhiteSpace(projectId) && Int32.TryParse(projectId, out int id))
            {
                Project project = await _context.Projects.FindAsync(id);
                if (project != null)
                {
                    Department department = await _context.Departments.FindAsync(project.DepartmentId);
                    if (department != null)
                        return await GetMentorsForCompanyAsync(department.CompanyId);
                }
            }
            return NoMentors();
        }

        private async Task<List<MentorOption>> GetMentorsForCompanyAsync(int? companyId)
        {
            if (companyId != null)
            {
                Company company = await _context.Companies
                    .Include(c => c.Branches)
                    .ThenInclude(b => b.Employees)
                    .Where(c => c.Id == companyId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                if (company != null && company.Branches.Count > 0)
                {
                    List<Employee> mentors = new List<Employee>();
                    foreach (Branch branch in company.Branches)
                    {
                        foreach (Employee mentor in branch.Employees)
                            mentors.Add(mentor);
                    }
                    return mentors
                        .OrderBy(n => n.FullName)
                        .Select(n => new MentorOption { Id = n.Id, FullName = n.FullName })
                        .ToList();
                }
            }
            return NoMentors();
        }

        private static List<MentorOption> NoMentors()
        {
            return new List<MentorOption>
            {
                new MentorOption { Id = 0, FullName = "No Mentors" }
            };
        }
    }
}
