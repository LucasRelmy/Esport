using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Esport.Data;
using Esport.Models;
using Microsoft.AspNetCore.Authorization;

namespace Esport.Pages.Jeux
{
    [Authorize(Roles = "personnel")]
    public class EditModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public EditModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jeu Jeu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jeu = await _context.Jeu.FirstOrDefaultAsync(m => m.ID == id);

            if (Jeu == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Jeu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JeuExists(Jeu.ID))
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

        private bool JeuExists(int id)
        {
            return _context.Jeu.Any(e => e.ID == id);
        }
    }
}
