using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<Department> DepartmentsList { get; set; }
        public List<Branch> BranchesList { get; set; }

        public DetailsModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            DepartmentsList = await _context.Departments
                .Where(e => e.CompanyId == id)
                .OrderBy(e => e.Name)
                .AsNoTracking()
                .ToListAsync();

            BranchesList = await _context.Branches
                .Where(e => e.CompanyId == id)
                .OrderBy(e => e.Name)
                .AsNoTracking()
                .ToListAsync();

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
