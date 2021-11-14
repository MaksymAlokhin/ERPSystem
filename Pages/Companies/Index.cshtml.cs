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

namespace ERPSystem.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(ERPSystem.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public string NameSort { get; set; }
        public string ManagerSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Company> Company { get; set; }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ManagerSort = sortOrder == "manager" ? "manager_desc" : "manager";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;
            IQueryable<Company> companiesIQ = _context.Companies.Include(i=>i.GeneralManager);
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
                default:
                    companiesIQ = companiesIQ.OrderBy(s => s.Name);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Company = await PaginatedList<Company>.CreateAsync(
                companiesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
