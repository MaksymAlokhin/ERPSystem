using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.GeneralManagers
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;

        public CreateModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name");
        ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public GeneralManager GeneralManager { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GeneralManagers.Add(GeneralManager);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
