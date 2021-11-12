using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Positions
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
        ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Position Position { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Positions.Add(Position);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
