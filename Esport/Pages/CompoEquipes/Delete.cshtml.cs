using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Esport.Data;
using Esport.Models;

namespace Esport.Pages.Shared.CompoEquipes
{
    public class DeleteModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public DeleteModel(Esport.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompoEquipe = await _context.CompoEquipe.FindAsync(id);

            if (CompoEquipe != null)
            {
                _context.CompoEquipe.Remove(CompoEquipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
