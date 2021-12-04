using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IEnumerable<Project> ProjectsList { get; set; }

        public DetailsModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
