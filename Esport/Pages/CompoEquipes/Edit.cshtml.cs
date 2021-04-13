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

namespace Esport.Pages.Shared.CompoEquipes
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
        public CompoEquipe CompoEquipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompoEquipe = await _context.CompoEquipe
                .Include(c => c.equipe)
                .Include(c => c.licencie).FirstOrDefaultAsync(m => m.ID == id);

            if (CompoEquipe == null)
            {
                return NotFound();
            }
           ViewData["EquipeID"] = new SelectList(_context.Equipe, "ID", "ID");
           ViewData["LicencieID"] = new SelectList(_context.Licencie, "ID", "ID");
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

            _context.Attach(CompoEquipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompoEquipeExists(CompoEquipe.ID))
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

        private bool CompoEquipeExists(int id)
        {
            return _context.CompoEquipe.Any(e => e.ID == id);
        }
    }
}
