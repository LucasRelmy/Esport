using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Esport.Data;
using Esport.Models;
using Microsoft.AspNetCore.Authorization;

namespace Esport.Pages.Shared.Equipes
{
    [Authorize(Roles = "personnel")]
    public class DeleteModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public DeleteModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipe Equipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipe = await _context.Equipe.FirstOrDefaultAsync(m => m.ID == id);

            if (Equipe == null)
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

            Equipe = await _context.Equipe.FindAsync(id);

            if (Equipe != null)
            {
                _context.Equipe.Remove(Equipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
