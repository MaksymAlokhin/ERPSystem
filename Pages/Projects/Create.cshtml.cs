using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Projects
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
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
