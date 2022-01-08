using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Companies
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<EditModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<SelectListItem> GeneralManagerList { get; set; }
        public int? GeneralManagerId;
        public List<int> SelectedBranches { get; set; }
        public SelectList BranchesSelectList { get; set; }
        public List<int> SelectedDepartments { get; set; }
        public SelectList DepartmentsSelectList { get; set; }
        List<int> CompaniesWithModifiedState { get; set; }
        public EditModel(ERPSystem.Data.ApplicationDbContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            if (id == null)
            {
                return NotFound();
            }
            Company = await _context.Companies
                .Include(g => g.GeneralManager)
                .Include(d => d.Departments)
                .Include(b => b.Branches)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Company == null)
            {
                return NotFound();
            }

            GeneralManagerList = new List<SelectListItem>();
            foreach (Employee gm in _context.Employees
                .Where(e => e.EmployeeRole == EmployeeRole.GeneralManager)
                .OrderBy(gm => gm.LastName).ThenBy(gm => gm.FirstName))
            {
                GeneralManagerList.Add(new SelectListItem { Value = $"{gm.Id}", Text = $"{gm.FullName}" });
            }

            if (Company.GeneralManager != null)
                GeneralManagerId = Company.GeneralManager.Id;

            var BranchesQuery = _context.Branches.OrderBy(b => b.Name).AsNoTracking();
            BranchesSelectList = new SelectList(BranchesQuery, "Id", "Name"); //list, id, value
            var DepartmentsQuery = _context.Departments.OrderBy(b => b.Name).AsNoTracking();
            DepartmentsSelectList = new SelectList(DepartmentsQuery, "Id", "Name"); //list, id, value

            SelectedBranches = new List<int>();
            foreach (var branch in Company.Branches)
            {
                SelectedBranches.Add(branch.Id);
            }
            SelectedDepartments = new List<int>();
            foreach (var department in Company.Departments)
            {
                SelectedDepartments.Add(department.Id);
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, int? GeneralManagerId, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedBranches, int[] SelectedDepartments)
        {
            CompaniesWithModifiedState = new List<int>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var CompanyToUpdate = await _context.Companies
                .Include(g => g.GeneralManager)
                .Include(d => d.Departments)
                .Include(b => b.Branches)
                .FirstOrDefaultAsync(m => m.Id == id);

            CompanyState InitialCompanyState = CompanyToUpdate.CompanyState;

            //Refactored because TryUpdateModelAsync fails while unit testing:
            //https://github.com/dotnet/AspNetCore.Docs/issues/14009
            //if (await TryUpdateModelAsync<Company>(CompanyToUpdate, "Company", c => c.Name, c => c.CompanyState))

            CompanyToUpdate.Name = Company.Name;
            CompanyToUpdate.CompanyState = Company.CompanyState;

            Employee gm = await _context.Employees.FindAsync(GeneralManagerId);

            if (gm != null)
            {
                if (gm.CompanyId != null)
                {
                    if (gm.CompanyId != id) //We stole GM from other company
                    {
                        var oldCompany = await _context.Companies.FindAsync(gm.CompanyId);
                        if (oldCompany.CompanyState != CompanyState.Inactive)
                        {
                            oldCompany.CompanyState = CompanyState.Inactive;
                            CompaniesWithModifiedState.Add(oldCompany.Id);
                        }
                    }
                }
                gm.CompanyId = id;
            }
            else
            {
                if (CompanyToUpdate.GeneralManager != null) //We removed GM
                {
                    Employee formerGm = await _context.Employees
                        .Where(e => e.EmployeeRole == EmployeeRole.GeneralManager
                        && e.Id == CompanyToUpdate.GeneralManager.Id)
                        .FirstOrDefaultAsync();
                    formerGm.CompanyId = null;
                }
            }

            if (CompanyToUpdate.CompanyState != InitialCompanyState)
                CompaniesWithModifiedState.Add(CompanyToUpdate.Id);

            UpdateDepartments(SelectedDepartments, CompanyToUpdate);
            UpdateBrances(SelectedBranches, CompanyToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Utility utility = new Utility(_context);
            utility.UpdateCompanyDependants(CompaniesWithModifiedState);
            utility.UpdateWhenParentIsNull();

            _logger.LogInformation("Company modified: {0}", CompanyToUpdate.Name);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
        private void UpdateDepartments(int[] SelectedDepartments, Company Company)
        {
            {
                if (SelectedDepartments == null || SelectedDepartments.Length == 0)
                {
                    Company.Departments = new List<Department>();
                    return;
                }

                var SelectedDepartmentsHS = new HashSet<int>(SelectedDepartments);
                var CompanyDepartmentsHS = new HashSet<int>
                    (Company.Departments.Select(s => s.Id));
                foreach (var department in _context.Departments)
                {
                    //If items are selected
                    if (SelectedDepartmentsHS.Contains(department.Id))
                    {
                        //If item not present
                        if (!CompanyDepartmentsHS.Contains(department.Id))
                        {
                            Company.Departments.Add(department);
                            if (!CompaniesWithModifiedState.Contains(Company.Id))
                                CompaniesWithModifiedState.Add(Company.Id);
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (CompanyDepartmentsHS.Contains(department.Id))
                        {
                            var toRemove = Company.Departments.Single(s => s.Id == department.Id);
                            Company.Departments.Remove(toRemove);
                            if (!CompaniesWithModifiedState.Contains(Company.Id))
                                CompaniesWithModifiedState.Add(Company.Id);
                        }
                    }
                }
            }
        }
        private void UpdateBrances(int[] SelectedBranches, Company Company)
        {
            {
                if (SelectedBranches == null || SelectedBranches.Length == 0)
                {
                    Company.Branches = new List<Branch>();
                    return;
                }

                var SelectedBranchesHS = new HashSet<int>(SelectedBranches);
                var CompanyBranchesHS = new HashSet<int>
                    (Company.Branches.Select(s => s.Id));
                foreach (var branch in _context.Branches)
                {
                    //If items are selected
                    if (SelectedBranchesHS.Contains(branch.Id))
                    {
                        //If item not present
                        if (!CompanyBranchesHS.Contains(branch.Id))
                        {
                            Company.Branches.Add(branch);
                            if (!CompaniesWithModifiedState.Contains(Company.Id))
                                CompaniesWithModifiedState.Add(Company.Id);
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (CompanyBranchesHS.Contains(branch.Id))
                        {
                            var toRemove = Company.Branches.Single(s => s.Id == branch.Id);
                            Company.Branches.Remove(toRemove);
                        }
                    }
                }
            }
        }
        public async Task<JsonResult> OnGetEmployeeAsync(string employeeId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetEmployeeStateAsync(employeeId);
        }
    }
}
