using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ERPSystem.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public EmployeeRole Role { get; set; }

        public DeleteModel(ERPSystem.Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        [BindProperty]
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
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(EmployeeRole Role, string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees.FindAsync(id);

            //Delete photo file
            //string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, @"images/avatars"); //webHost adds 'wwwroot'
            //var oldFile = Employee.ProfilePicture;
            //var fileToDelete = string.Empty;
            //if (!string.IsNullOrEmpty(oldFile))
            //{
            //    fileToDelete = Path.Combine(uploadsFolder, oldFile);
            //}

            if (Employee != null)
            {
                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();

                //Delete photo file
                //if (System.IO.File.Exists(fileToDelete))
                //{
                //    System.IO.File.Delete(fileToDelete);
                //}
            }
            await Utility.UpdateStateAsync(_context);
            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}",
                Role = $"{Role}"
            });
        }
    }
}
