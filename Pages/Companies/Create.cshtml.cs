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

        public IActionResult OnGet()
        {
            GeneralManagerList = new List<SelectListItem>();
            foreach (GeneralManager gm in _context.GeneralManagers)
            {
                GeneralManagerList.Add(new SelectListItem { Value = $"{gm.Id}", Text = $"{gm.FullName}" });
            }

            var BranchesQuery = _context.Branches.OrderBy(b => b.Name);
            BranchesSelectList = new SelectList(BranchesQuery.AsNoTracking(), "Id", "Name"); //list, id, value
            var DepartmentsQuery = _context.Departments.OrderBy(b => b.Name);
            DepartmentsSelectList = new SelectList(DepartmentsQuery.AsNoTracking(), "Id", "Name"); //list, id, value

            SelectedBranches = new List<int>();
            SelectedDepartments = new List<int>();

            Company = new Company();
            Company.CompanyState = CompanyState.Inactive;
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? id, int? GeneralManagerId, int[] SelectedBranches, int[] SelectedDepartments)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NewCompany = new Company();

            if (SelectedDepartments.Length > 0)
            {
                NewCompany.Departments = new List<Department>();
                _context.Departments.Load();
            }
            if (SelectedBranches.Length > 0)
            {
                NewCompany.Branches = new List<Branch>();
                _context.Branches.Load();
            }

            foreach (var department in SelectedDepartments)
            {
                var foundDepartment = await _context.Departments.FindAsync(department);
                if (foundDepartment != null)
                {
                    NewCompany.Departments.Add(foundDepartment);
                }
            }

            foreach (var branch in SelectedBranches)
            {
                var foundBranch = await _context.Branches.FindAsync(branch);
                if (foundBranch != null)
                {
                    NewCompany.Branches.Add(foundBranch);
                }
            }

            if (await TryUpdateModelAsync<Company>(
                                            NewCompany,
                                            "Company",
                                            c => c.Name, c => c.CompanyState))
            {
                if (GeneralManagerId != 0)
                {
                    GeneralManager gm = await _context.GeneralManagers.FindAsync(GeneralManagerId);
                    if(gm.CompanyId != null)
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
                _context.Companies.Add(NewCompany);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
