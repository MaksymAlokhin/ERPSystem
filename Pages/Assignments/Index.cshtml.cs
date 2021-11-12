using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Assignments
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;

        public IndexModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignment { get;set; }

        public async Task OnGetAsync()
        {
            Assignment = await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Position).ToListAsync();
        }
    }
}
