using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationsInMyMobile.Data;
using ApplicationsInMyMobile.Models;

namespace ApplicationsInMyMobile.Pages.Applications
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationsInMyMobile.Data.AppDbContext _context;

        public CreateModel(ApplicationsInMyMobile.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public App App { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.App.Add(App);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}