using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Branches
{
    public class DetailsModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;

        public DetailsModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Branch Branch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Branch = await _context.Branches
                .Include(b => b.Company).FirstOrDefaultAsync(m => m.Id == id);

            if (Branch == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
