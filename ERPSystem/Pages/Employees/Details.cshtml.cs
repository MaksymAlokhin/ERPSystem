﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<DetailsModel> _logger;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public EmployeeRole Role { get; set; }

        public DetailsModel(ERPSystem.Data.ApplicationDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(EmployeeRole Role, string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            this.Role = Role; 
            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(e => e.Branch)
                .Include(e => e.Assignments)
                .Include(e => e.Mentors)
                .Include(e => e.Project)
                .Include(e => e.Company)
                .Include(e => e.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Details displayed for Employee: {0}, {1}", Employee.LastName, Employee.FirstName);

            return Page();
        }
    }
}
