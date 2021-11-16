using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;

        public IndexModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
                .Include(e => e.Branch)
                .Include(e => e.Company)
                .Include(e => e.Department)
                .Include(e => e.Project).ToListAsync();
        }
    }
}
