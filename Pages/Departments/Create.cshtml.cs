using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public List<int> SelectedProjects { get; set; }
        public SelectList ProjectsSelectList { get; set; }
        public List<SelectListItem> DepartmentHeadList { get; set; }
        public int? DepartmentHeadId;


        public CreateModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            DepartmentHeadList = new List<SelectListItem>();
            foreach (Employee dh in _context.Employees
                .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead)
                .OrderBy(dh => dh.LastName).ThenBy(dh => dh.FirstName))
            {
                DepartmentHeadList.Add(new SelectListItem { Value = $"{dh.Id}", Text = $"{dh.FullName}" });
            }

            var ProjectsQuery = _context.Projects.OrderBy(p => p.Name);
            ProjectsSelectList = new SelectList(ProjectsQuery.AsNoTracking(), "Id", "Name"); //list, id, value

            SelectedProjects = new List<int>();
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");

            Department = new Department();
            Department.DepartmentState = DepartmentState.Inactive;

            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? DepartmentHeadId, int[] SelectedProjects)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NewDepartment = new Department();

            if (SelectedProjects.Length > 0)
            {
                NewDepartment.Projects = new List<Project>();
                _context.Projects.Load();
            }

            foreach (var project in SelectedProjects)
            {
                var foundProject = await _context.Projects.FindAsync(project);
                if (foundProject != null)
                {
                    NewDepartment.Projects.Add(foundProject);
                }
            }

            if (await TryUpdateModelAsync<Department>(
                    NewDepartment,
                    "Department",
                    d => d.Name, d => d.DepartmentState, d => d.CompanyId))
            {
                if (DepartmentHeadId != 0)
                {
                    Employee dh = await _context.Employees
                        .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead && e.Id == DepartmentHeadId)
                        .FirstOrDefaultAsync();
                    if (dh.DepartmentId != null)
                    {
                        var oldDepartment = await _context.Departments.FindAsync(dh.DepartmentId);
                        oldDepartment.DepartmentState = DepartmentState.Inactive;
                    }
                    dh.DepartmentId = null;
                    NewDepartment.DepartmentHead = dh;
                }
                else
                {
                    NewDepartment.DepartmentState = DepartmentState.Inactive;
                }
                _context.Departments.Add(NewDepartment);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
