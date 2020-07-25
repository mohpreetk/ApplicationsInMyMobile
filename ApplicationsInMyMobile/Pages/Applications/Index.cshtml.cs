using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationsInMyMobile.Data;
using ApplicationsInMyMobile.Models;

namespace ApplicationsInMyMobile.Pages.Applications
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationsInMyMobile.Data.AppDbContext _context;

        public IndexModel(ApplicationsInMyMobile.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<App> App { get;set; }

        public async Task OnGetAsync()
        {
            App = await _context.App.ToListAsync();
        }
    }
}
