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

namespace ERPSystem.Pages.Branches
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public List<int> SelectedEmployees { get; set; }
        public SelectList EmployeesSelectList { get; set; }
        public SelectList CompaniesSelectList { get; set; }

        public CreateModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var EmployeesQuery = _context.Employees
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .ToList()
                .Where(e => !e.GetType().IsSubclassOf(typeof(Employee)));

            EmployeesSelectList = new SelectList(EmployeesQuery, "Id", "FullName"); //list, id, value

            SelectedEmployees = new List<int>();

            Branch = new Branch();
            Branch.BranchState = BranchState.Inactive;

            var CompaniesQuery = _context.Companies.OrderBy(c => c.Name);
            CompaniesSelectList = new SelectList(CompaniesQuery.AsNoTracking(), "Id", "Name"); //list, id, value
            return Page();
        }

        [BindProperty]
        public Branch Branch { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int[] SelectedEmployees)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Branch NewBranch = new Branch();

            if (SelectedEmployees.Length > 0)
            {
                NewBranch.Employees = new List<Employee>();
                _context.Employees.Load();
            }
            foreach (var employee in SelectedEmployees)
            {
                var foundEmployee = await _context.Employees.FindAsync(employee);
                if (foundEmployee != null)
                {
                    NewBranch.Employees.Add(foundEmployee);
                }
            }

            if (await TryUpdateModelAsync<Branch>(
                                            NewBranch,
                                            "Branch",
                                            b => b.Name, b => b.BranchState, b => b.CompanyId))
            {
                _context.Branches.Add(NewBranch);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
