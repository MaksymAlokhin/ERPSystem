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

        public DetailsModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments
                .Include(d => d.Company).FirstOrDefaultAsync(m => m.Id == id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
