using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Companies
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<DeleteModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<Department> DepartmentsList { get; set; }
        public List<Branch> BranchesList { get; set; }

        public DeleteModel(ERPSystem.Data.ApplicationDbContext context, ILogger<DeleteModel> logger)
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
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            DepartmentsList = await _context.Departments
                .Where(e => e.CompanyId == id)
                .Include(e => e.DepartmentHead)
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

        public async Task<IActionResult> OnPostAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Companies
                .Include(g => g.GeneralManager)
                .Include(d => d.Departments)
                .Include(b => b.Branches)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Company != null)
            {
                _logger.LogInformation("Company deleted: {0}", Company.Name);

                _context.Companies.Remove(Company);
                await _context.SaveChangesAsync();
            }

            Utility utility = new Utility(_context);
            utility.UpdateWhenParentIsNull();

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
    }
}
