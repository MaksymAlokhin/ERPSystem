using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Branches
{
    public class DetailsModel : PageModel
    {
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        private readonly ILogger<DetailsModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<Employee> EmployeeList { get; set; }

        public DetailsModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

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

            Branch = await _context.Branches
                .Include(b => b.Company)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            EmployeeList = await _context.Employees
                .Where(e => e.BranchId == id)
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .AsNoTracking()
                .ToListAsync();

            if (Branch == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Details displayed for Branch: {0}", Branch.Name);

            return Page();
        }
    }
}
