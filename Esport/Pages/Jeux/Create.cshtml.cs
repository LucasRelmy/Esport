using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Esport.Data;
using Esport.Models;
using Microsoft.AspNetCore.Authorization;

namespace Esport.Pages.Jeux
{
    [Authorize(Roles = "personnel")]
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
        public Jeu Jeu { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jeu.Add(Jeu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
