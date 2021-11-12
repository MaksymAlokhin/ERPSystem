using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Mentors
{
    public class DeleteModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;

        public DeleteModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mentor Mentor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mentor = await _context.Mentors
                .Include(m => m.Branch).FirstOrDefaultAsync(m => m.Id == id);

            if (Mentor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mentor = await _context.Mentors.FindAsync(id);

            if (Mentor != null)
            {
                _context.Mentors.Remove(Mentor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
