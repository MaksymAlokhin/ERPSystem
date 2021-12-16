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

namespace ERPSystem.Pages.Reports
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<DeleteModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public DeleteModel(ERPSystem.Data.ApplicationDbContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
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

            Report = await _context.Reports.Include(a => a.Assignment).Where(r => r.Id == id).FirstOrDefaultAsync();

            if (Report != null)
            {
                if (Report.Assignment != null)
                    _logger.LogInformation("Report deleted for Assignment: {1}", Report.Assignment.Name);

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
