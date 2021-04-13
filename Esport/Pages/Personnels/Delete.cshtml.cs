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

namespace Esport.Pages.Shared.Personnels
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
        public Personnel Personnel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personnel = await _context.Personnel.FirstOrDefaultAsync(m => m.ID == id);

            if (Personnel == null)
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

            Personnel = await _context.Personnel.FindAsync(id);

            if (Personnel != null)
            {
                _context.Personnel.Remove(Personnel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
