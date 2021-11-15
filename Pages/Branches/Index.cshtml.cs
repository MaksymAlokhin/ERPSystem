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

namespace ERPSystem.Pages.Branches
{
    public class IndexModel : PageModel
    {
        private readonly ERPSystem.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;
        public string NameSort { get; set; }
        public string StateSort { get; set; }
        public string CompanySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Branch> Branch { get; set; }
        public IndexModel(ERPSystem.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            StateSort = sortOrder == "state" ? "state_desc" : "state";
            CompanySort = sortOrder == "company" ? "company_desc" : "company";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;
            IQueryable<Branch> branchesIQ = _context.Branches.Include(i => i.Company);
            if (!String.IsNullOrEmpty(searchString))
            {
                branchesIQ = branchesIQ.Where(s => s.Name.Contains(searchString)
                                       || s.Company.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    branchesIQ = branchesIQ.OrderByDescending(s => s.Name);
                    break;
                case "state":
                    branchesIQ = branchesIQ.OrderBy(s => s.BranchState).ThenBy(s => s.Name);
                    break;
                case "state_desc":
                    branchesIQ = branchesIQ.OrderByDescending(s => s.BranchState).ThenBy(s => s.Name);
                    break;
                case "company":
                    branchesIQ = branchesIQ.OrderBy(s => s.Company.Name).ThenBy(s => s.Name);
                    break;
                case "company_desc":
                    branchesIQ = branchesIQ.OrderByDescending(s => s.Company.Name).ThenBy(s => s.Name);
                    break;
                default:
                    branchesIQ = branchesIQ.OrderBy(s => s.Name);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 7);
            Branch = await PaginatedList<Branch>.CreateAsync(
                branchesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
