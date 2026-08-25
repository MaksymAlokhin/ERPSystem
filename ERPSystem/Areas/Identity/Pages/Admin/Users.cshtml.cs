using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Areas.Identity.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class UsersModel : PageModel
    {
        public ApplicationDbContext _DbCtx { get; set; }

        public IEnumerable<IdentityUser> Users { get; set; }
                        = Enumerable.Empty<IdentityUser>();

        public UsersModel(ApplicationDbContext dbCtx)
        {
            _DbCtx = dbCtx;
        }

        public async Task OnGetAsync()
        {
            Users = await _DbCtx.Users.ToListAsync();
        }
    }
}
