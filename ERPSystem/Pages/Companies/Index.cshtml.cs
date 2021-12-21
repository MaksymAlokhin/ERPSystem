using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ERPSystem.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration Configuration;
        public string NameSort { get; set; }
        public string ManagerSort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Company> Company { get; set; }

        public IndexModel(ERPSystem.Data.ApplicationDbContext context, IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _context = context;
            Configuration = configuration;
            _logger = logger;
        }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ManagerSort = sortOrder == "manager" ? "manager_desc" : "manager";
            StateSort = sortOrder == "state" ? "state_desc" : "state";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;
            IQueryable<Company> companiesIQ = _context.Companies.Include(i => i.GeneralManager);
            if (!String.IsNullOrEmpty(searchString))
            {
                companiesIQ = companiesIQ.Where(s => s.Name.Contains(searchString)
                                       || s.GeneralManager.FirstName.Contains(searchString)
                                       || s.GeneralManager.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    companiesIQ = companiesIQ.OrderByDescending(s => s.Name);
                    break;
                case "manager":
                    companiesIQ = companiesIQ.OrderBy(s => s.GeneralManager.LastName).ThenBy(s => s.GeneralManager.FirstName);
                    break;
                case "manager_desc":
                    companiesIQ = companiesIQ.OrderByDescending(s => s.GeneralManager.LastName).ThenBy(s => s.GeneralManager.FirstName);
                    break;
                case "state":
                    companiesIQ = companiesIQ.OrderBy(s => s.CompanyState).ThenBy(s => s.Name);
                    break;
                case "state_desc":
                    companiesIQ = companiesIQ.OrderByDescending(s => s.CompanyState).ThenBy(s => s.Name);
                    break;
                default:
                    companiesIQ = companiesIQ.OrderBy(s => s.Name);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Company = await PaginatedList<Company>.CreateAsync(
                companiesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            _logger.LogInformation("Displaying page {1} of Companies", pageIndex ?? 1);
        }
        //Method to debug states
        public async Task<IActionResult> OnGetActivateAsync(string sortOrder,
            string currentFilter, int? pageIndex)
        {
            foreach (var company in _context.Companies)
            {
                _context.Entry(company)
                    .Reference(p => p.GeneralManager)
                    .Load();
                if (company.GeneralManager != null)
                {
                    if (company.GeneralManager.EmployeeState == EmployeeState.Active)
                    {
                        company.CompanyState = CompanyState.Active;
                    }
                }
            }
            await _context.SaveChangesAsync();

            _logger.LogInformation("Company Index returned {1} entries", Company.Count());

            return RedirectToPage("./Index", new
            {
                pageIndex = $"{pageIndex}",
                sortOrder = $"{sortOrder}",
                currentFilter = $"{currentFilter}"
            });
        }
    }
}
