using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Reports
{
    public class DeleteModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public DeleteModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Report Report { get; set; }

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

            Report = await _context.Reports
                .Include(r => r.Assignment)
                .ThenInclude(r => r.Employee).FirstOrDefaultAsync(m => m.Id == id);

            if (Report == null)
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

            Report = await _context.Reports.FindAsync(id);

            if (Report != null)
            {
                _context.Reports.Remove(Report);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
    }
}
