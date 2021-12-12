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
using Microsoft.AspNetCore.Authorization;

namespace ERPSystem.Pages.Branches
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedEmployees { get; set; }
        public SelectList EmployeesSelectList { get; set; }
        public SelectList CompaniesSelectList { get; set; }

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

            var EmployeesQuery = _context.Employees
                .Where(e => e.EmployeeRole == EmployeeRole.Employee
                        || e.EmployeeRole == EmployeeRole.Mentor)
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .AsNoTracking();

            EmployeesSelectList = new SelectList(EmployeesQuery, "Id", "FullName"); //list, id, value

            SelectedEmployees = new List<int>();

            Branch = new Branch();
            Branch.BranchState = BranchState.Inactive;

            var CompaniesQuery = _context.Companies.OrderBy(c => c.Name).AsNoTracking();
            CompaniesSelectList = new SelectList(CompaniesQuery, "Id", "Name"); //list, id, value
            return Page();
        }

        [BindProperty]
        public Branch Branch { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedEmployees)
        {
            List<int> BranchesWithModifiedState = new List<int>();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Branch NewBranch = new Branch();

            if (SelectedEmployees !=null)
            {
                if (SelectedEmployees.Length > 0)
                {
                    NewBranch.Employees = new List<Employee>();
                }
                foreach (var employee in SelectedEmployees)
                {
                    var foundEmployee = await _context.Employees.FindAsync(employee);
                    if (foundEmployee != null)
                        NewBranch.Employees.Add(foundEmployee);
                }
            }

            //Refactored because TryUpdateModelAsync fails while unit testing:
            //https://github.com/dotnet/AspNetCore.Docs/issues/14009
            //if (await TryUpdateModelAsync<Branch>(NewBranch, "Branch", b => b.Name, b => b.BranchState, b => b.CompanyId))
            //return Page();

            NewBranch.Name = Branch.Name;
            NewBranch.BranchState = Branch.BranchState;
            NewBranch.CompanyId = Branch.CompanyId;

            _context.Branches.Add(NewBranch);
            await _context.SaveChangesAsync();

            BranchesWithModifiedState.Add(NewBranch.Id);

            Utility utility = new Utility(_context);
            utility.UpdateBranchDependants(BranchesWithModifiedState);

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
        public async Task<JsonResult> OnGetCompanyAsync(string companyId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetCompanyStateAsync(companyId);
        }
    }
}
