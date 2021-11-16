﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;

namespace ERPSystem.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        public int? PageIndex { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public List<int> SelectedProjects { get; set; }
        public SelectList ProjectsSelectList { get; set; }
        public List<SelectListItem> DepartmentHeadList { get; set; }
        public int? DepartmentHeadId;
        public int? FormerDepartmentHeadId;
        public EditModel(ERPSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder,
            string currentFilter, int? pageIndex, int? id)
        {
            PageIndex = pageIndex;
            CurrentSort = sortOrder;
            CurrentFilter = currentFilter;

            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments
                .Include(d => d.DepartmentHead)
                .Include(p => p.Projects)
                .Include(c => c.Company)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Department == null)
            {
                return NotFound();
            }

            DepartmentHeadList = new List<SelectListItem>();
            foreach (Employee dh in _context.Employees
                    .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead)
                    .OrderBy(dh => dh.LastName)
                    .ThenBy(dh => dh.FirstName))
            {
                DepartmentHeadList.Add(new SelectListItem { Value = $"{dh.Id}", Text = $"{dh.FullName}" });
            }
            if (Department.DepartmentHead != null)
            {
                DepartmentHeadId = FormerDepartmentHeadId = Department.DepartmentHead.Id;
            }

            var ProjectsQuery = _context.Projects.OrderBy(p => p.Name);
            ProjectsSelectList = new SelectList(ProjectsQuery.AsNoTracking(), "Id", "Name"); //list, id, value

            SelectedProjects = new List<int>();
            foreach (var project in Department.Projects)
            {
                SelectedProjects.Add(project.Id);
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, int? DepartmentHeadId, int? FormerDepartmentHeadId, string sortOrder,
            string currentFilter, int? pageIndex, int[] SelectedProjects)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var DepartmentToUpdate = _context.Departments
                .Include(d => d.DepartmentHead)
                .Include(p => p.Projects)
                .Include(c => c.Company)
                .Single(m => m.Id == id);

            if (await TryUpdateModelAsync<Department>(
                DepartmentToUpdate,
                "Department",
                d => d.Name, d => d.DepartmentState, d => d.CompanyId))
            {
                Employee dh = await _context.Employees
                        .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead && e.Id == DepartmentHeadId)
                        .FirstOrDefaultAsync();
                if (dh != null)
                {
                    if (dh.Id != FormerDepartmentHeadId && dh.DepartmentId != null)
                    {
                        var oldDepartment = await _context.Departments.FindAsync(dh.DepartmentId);
                        oldDepartment.DepartmentState = DepartmentState.Inactive;
                    }
                    dh.DepartmentId = Department.Id;
                }
                else
                {
                    if (FormerDepartmentHeadId != null)
                    {
                        Employee formerHh = await _context.Employees
                                .Where(e => e.EmployeeRole == EmployeeRole.DepartmentHead && e.Id == FormerDepartmentHeadId)
                                .FirstOrDefaultAsync();
                        formerHh.DepartmentId = null;
                        DepartmentToUpdate.DepartmentState = DepartmentState.Inactive;
                    }
                }

                UpdateProjects(SelectedProjects, DepartmentToUpdate);
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(Department.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }

        private void UpdateProjects(int[] SelectedProjects, Department Department)
        {
            {
                if (SelectedProjects == null)
                {
                    Department.Projects = new List<Project>();
                    return;
                }

                var SelectedProjectsHS = new HashSet<int>(SelectedProjects);
                var DepartmentProjectsHS = new HashSet<int>
                    (Department.Projects.Select(p => p.Id));
                foreach (var project in _context.Projects)
                {
                    //If items are selected
                    if (SelectedProjectsHS.Contains(project.Id))
                    {
                        //If item not present
                        if (!DepartmentProjectsHS.Contains(project.Id))
                        {
                            Department.Projects.Add(project);
                        }
                    }
                    //If items are not selected
                    else
                    {
                        //If item is present
                        if (DepartmentProjectsHS.Contains(project.Id))
                        {
                            var toRemove = Department.Projects.Single(s => s.Id == project.Id);
                            Department.Projects.Remove(toRemove);
                        }
                    }
                }
            }
        }
    }
}
