using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationsInMyMobile.Data;
using ApplicationsInMyMobile.Models;

namespace ApplicationsInMyMobile.Pages.Applications
{
    public class EditModel : PageModel
    {
        private readonly ApplicationsInMyMobile.Data.AppDbContext _context;

        public EditModel(ApplicationsInMyMobile.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(App).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppExists(App.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppExists(int id)
        {
            return _context.App.Any(e => e.Id == id);
        }
    }
}
