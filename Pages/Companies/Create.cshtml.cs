using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Pages.Companies
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<SelectListItem> GeneralManagerList { get; set; }
        public int? GeneralManagerId;
        public List<int> SelectedBranches { get; set; }
        public SelectList BranchesSelectList { get; set; }
        public List<int> SelectedDepartments { get; set; }
        public SelectList DepartmentsSelectList { get; set; }

        public CompanyState State { get; set; }

        public CreateModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string sortOrder,
            string currentFilter, int? pageIndex)
        {
            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            GeneralManagerList = new List<SelectListItem>();
            foreach (Employee gm in _context.Employees
                .Where(e => e.EmployeeRole == EmployeeRole.GeneralManager)
                .OrderBy(gm => gm.LastName).ThenBy(gm => gm.FirstName))
            {
                GeneralManagerList.Add(new SelectListItem { Value = $"{gm.Id}", Text = $"{gm.FullName}" });
            }

            var BranchesQuery = _context.Branches.OrderBy(b => b.Name).AsNoTracking();
            BranchesSelectList = new SelectList(BranchesQuery, "Id", "Name"); //list, id, value
            var DepartmentsQuery = _context.Departments.OrderBy(b => b.Name).AsNoTracking();
            DepartmentsSelectList = new SelectList(DepartmentsQuery, "Id", "Name"); //list, id, value

            SelectedBranches = new List<int>();
            SelectedDepartments = new List<int>();

            Company = new Company();
            Company.CompanyState = CompanyState.Inactive;
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? GeneralManagerId, int[] SelectedBranches, int[] SelectedDepartments)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NewCompany = new Company();

            if (await TryUpdateModelAsync<Company>(
                                            NewCompany,
                                            "Company",
                                            c => c.Name, c => c.CompanyState))
            {
                //Make old company inactive because its GM is now here
                if (GeneralManagerId != null)
                {
                    Employee gm = await _context.Employees
                        .Where(e => e.EmployeeRole == EmployeeRole.GeneralManager && e.Id == GeneralManagerId)
                        .FirstOrDefaultAsync();
                    if (gm.CompanyId != null)
                    {
                        var oldCompany = await _context.Companies.FindAsync(gm.CompanyId);
                        oldCompany.CompanyState = CompanyState.Inactive;
                    }
                    gm.CompanyId = null;
                    NewCompany.GeneralManager = gm;
                }
                else
                {
                    NewCompany.CompanyState = CompanyState.Inactive;
                }

                //Fill Departments and Branches and set their status.
                if (SelectedDepartments.Length > 0)
                {
                    NewCompany.Departments = new List<Department>();
                }
                if (SelectedBranches.Length > 0)
                {
                    NewCompany.Branches = new List<Branch>();
                }

                foreach (var department in SelectedDepartments)
                {
                    var foundDepartment = await _context.Departments.FindAsync(department);
                    if (foundDepartment != null)
                    {
                        NewCompany.Departments.Add(foundDepartment);
                        if (NewCompany.CompanyState == CompanyState.Active)
                        {
                            _context.Entry(foundDepartment)
                                .Reference(d => d.DepartmentHead)
                                .Load();
                            if (foundDepartment.DepartmentHead != null)
                            {
                                if (foundDepartment.DepartmentHead.EmployeeState == EmployeeState.Active)
                                    foundDepartment.DepartmentState = DepartmentState.Active;
                                else
                                    foundDepartment.DepartmentState = DepartmentState.Inactive;
                            }
                            else
                                foundDepartment.DepartmentState = DepartmentState.Inactive;
                        }
                    }
                }

                foreach (var branch in SelectedBranches)
                {
                    var foundBranch = await _context.Branches.FindAsync(branch);
                    if (foundBranch != null)
                    {
                        NewCompany.Branches.Add(foundBranch);
                        if (NewCompany.CompanyState == CompanyState.Active)
                            foundBranch.BranchState = BranchState.Active;
                        else
                            foundBranch.BranchState = BranchState.Inactive;
                    }
                }

                _context.Companies.Add(NewCompany);
                await _context.SaveChangesAsync();

                Utility utility = new Utility(_context);
                utility.UpdateProjectsState();
                utility.UpdatePositionsState();
                utility.UpdateAssignmentsState();

                return RedirectToPage("./Index", new
                {
                    pageIndex = $"{pageIndex}",
                    sortOrder = $"{sortOrder}",
                    currentFilter = $"{currentFilter}"
                });
            }
            return Page();
        }
        public async Task<JsonResult> OnGetEmployeeAsync(string employeeId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetEmployeeStateAsync(employeeId);
        }
    }
}
