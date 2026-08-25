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

namespace ERPSystem.Pages.Positions
{
    public class DetailsModel : PageModel
    {
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IEnumerable<Assignment> AssignmentsList { get; set; }
        public DetailsModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Position Position { get; set; }

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

            AssignmentsList = await _context.Assignments
                .Where(e => e.PositionId == id)
                .OrderBy(e => e.Name)
                .AsNoTracking()
                .ToListAsync();

            Position = await _context.Positions
                .Include(p => p.Project)
                .Include(p => p.Assignments)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Position == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
