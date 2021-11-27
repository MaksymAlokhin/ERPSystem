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

namespace ERPSystem.Pages.Branches
{
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedEmployees { get; set; }
        public SelectList EmployeesSelectList { get; set; }
        public SelectList CompaniesSelectList { get; set; }
        public EditModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Branch Branch { get; set; }

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

            var EmployeesQuery = _context.Employees
                .Where(e => e.EmployeeRole == EmployeeRole.Employee 
                        || e.EmployeeRole == EmployeeRole.Mentor)
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .AsNoTracking();

            EmployeesSelectList = new SelectList(EmployeesQuery, "Id", "FullName"); //list, id, value
           
            Branch = await _context.Branches
                .Include(b => b.Company)
                .Include(b => b.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (Branch == null)
            {
                return NotFound();
            }

            SelectedEmployees = new List<int>();
            foreach (var employee in Branch.Employees)
            {
                SelectedEmployees.Add(employee.Id);
            }

            var CompaniesQuery = _context.Companies.OrderBy(c => c.Name).AsNoTracking();
            CompaniesSelectList = new SelectList(CompaniesQuery, "Id", "Name"); //list, id, value
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedEmployees)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var BranchToUpdate = await _context.Branches
                .Include(c => c.Company)
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(m => m.Id == id);

                if (await TryUpdateModelAsync<Branch>(
                BranchToUpdate,
                "Branch",
                b => b.Name, b => b.BranchState, b => b.CompanyId))
            {
                UpdateProjects(SelectedEmployees, BranchToUpdate);

                if (BranchToUpdate.BranchState == BranchState.Active)
                {
                    foreach (var employee in BranchToUpdate.Employees)
                        employee.EmployeeState = EmployeeState.Active;
                }
                else
                {
                    foreach (var employee in BranchToUpdate.Employees)
                        employee.EmployeeState = EmployeeState.Inactive;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(Branch.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        private bool BranchExists(int id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }
        private void UpdateProjects(int[] SelectedEmployees, Branch Branch)
        {
            {
                if (SelectedEmployees.Length == 0)
                {
                    Branch.Employees = new List<Employee>();
                    return;
                }

                var SelectedEmployeesHS = new HashSet<int>(SelectedEmployees);
                var BranchEmployeesHS = new HashSet<int>
                    (Branch.Employees.Select(p => p.Id));
                foreach (var employee in _context.Employees)
                {
                    //If items are selected
                    if (SelectedEmployeesHS.Contains(employee.Id))
                    {
                        //If item not present
                        if (!BranchEmployeesHS.Contains(employee.Id))
                        {
                            Branch.Employees.Add(employee);
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (BranchEmployeesHS.Contains(employee.Id))
                        {
                            var toRemove = Branch.Employees.Single(s => s.Id == employee.Id);
                            Branch.Employees.Remove(toRemove);
                            toRemove.EmployeeState = EmployeeState.Inactive;
                        }
                    }
                }
            }
        }
        public async Task<JsonResult> OnGetCompanyAsync(string companyId)
        {
            Utility utility = new Utility(_context);
            return await utility.GetCompanyStateAsync(companyId);
        }
    }
}
