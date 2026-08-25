using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Domain.Entities;
using ERPSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Projects
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly ERPSystem.Infrastructure.Data.ApplicationDbContext _context;
        private readonly IStateCascadeService _stateCascade;
        private readonly ILogger<DeleteModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public DeleteModel(ERPSystem.Infrastructure.Data.ApplicationDbContext context, IStateCascadeService stateCascade, ILogger<DeleteModel> logger)
        {
            _context = context;
            _stateCascade = stateCascade;
            _logger = logger;
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
                _logger.LogInformation("Project deleted: {0}", Project.Name);

                _context.Projects.Remove(Project);
                await _context.SaveChangesAsync();
            }

            _stateCascade.UpdateWhenParentIsNull();

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
    }
}
