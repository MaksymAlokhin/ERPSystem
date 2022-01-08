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

namespace ERPSystem.Pages.Departments
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<DeleteModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IEnumerable<Project> ProjectsList { get; set; }

        public DeleteModel(ERPSystem.Data.ApplicationDbContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Department Department { get; set; }

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

            Department = await _context.Departments
                .Include(d => d.DepartmentHead)
                .Include(c => c.Company)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            ProjectsList = await _context.Projects
                .Where(e => e.DepartmentId == id)
                .Include(p => p.ProjectManager)
                .OrderBy(e => e.Name)
                .AsNoTracking()
                .ToListAsync();

            if (Department == null)
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

            Department = await _context.Departments
                .Include(d => d.DepartmentHead)
                .Include(p => p.Projects)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Department != null)
            {
                _logger.LogInformation("Department deleted: {0}", Department.Name);

                _context.Departments.Remove(Department);
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
