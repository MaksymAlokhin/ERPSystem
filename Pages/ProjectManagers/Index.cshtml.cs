using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.ProjectManagers
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;

        public IndexModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProjectManager> ProjectManager { get;set; }

        public async Task OnGetAsync()
        {
            ProjectManager = await _context.ProjectManagers
                .Include(p => p.Branch)
                .Include(p => p.Project).ToListAsync();
        }
    }
}
