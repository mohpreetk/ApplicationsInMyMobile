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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationsInMyMobile.Data.AppDbContext _context;

        public DetailsModel(ApplicationsInMyMobile.Data.AppDbContext context)
        {
            _context = context;
        }

        public App App { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            App = await _context.App.FirstOrDefaultAsync(m => m.Id == id);

            if (App == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
