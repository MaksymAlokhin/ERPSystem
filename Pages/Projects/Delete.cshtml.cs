using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Projects
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
        public Project Project { get; set; }

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

            Project = await _context.Projects
                .Include(p => p.Department)
                .Include(p => p.Positions)
                .Include(p => p.ProjectManager)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Project == null)
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

            Project = await _context.Projects
                .Include(p => p.Department)
                .Include(p => p.Positions)
                .Include(p => p.ProjectManager)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Project != null)
            {
                if (Project.Positions != null)
                {
                    foreach (var position in Project.Positions)
                    {
                        position.PositionState = PositionState.Inactive;
                    }
                }

                _context.Projects.Remove(Project);
                await _context.SaveChangesAsync();
            }

            Utility utility = new Utility(_context);
            utility.UpdateAssignmentsState();

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
    }
}
