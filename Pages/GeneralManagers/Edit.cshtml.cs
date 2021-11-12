using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.GeneralManagers
{
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;

        public EditModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GeneralManager GeneralManager { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GeneralManager = await _context.GeneralManagers
                .Include(g => g.Branch).FirstOrDefaultAsync(m => m.Id == id);

            if (GeneralManager == null)
            {
                return NotFound();
            }
           ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GeneralManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralManagerExists(GeneralManager.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GeneralManagerExists(int id)
        {
            return _context.GeneralManagers.Any(e => e.Id == id);
        }
    }
}
