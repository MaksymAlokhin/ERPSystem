﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Reports
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
        ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Report Report { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reports.Add(Report);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}