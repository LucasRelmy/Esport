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
    public class DetailsModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public DetailsModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
