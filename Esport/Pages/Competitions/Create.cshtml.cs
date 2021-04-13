using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Esport.Data;
using Esport.Models;

namespace Esport.Pages.Competitions
{
    public class CreateModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public CreateModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Competition Competition { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Competition.Add(Competition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
