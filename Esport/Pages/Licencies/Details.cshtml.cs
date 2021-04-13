using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Esport.Data;
using Esport.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Esport.Pages.Shared.Licencies
{
    public class DetailsModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public DetailsModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Licencie Licencie { get; set; }
        public List<CompoEquipe> CompoEquipe { get; private set; }
        public IList<Equipe> LesEquipes { get; set; }
        public Equipe Equipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CompoEquipe = await _context.CompoEquipe.Where(m => m.LicencieID == id).ToListAsync();
            LesEquipes = await _context.Equipe.Where(m => m.CompoEquipe == this.CompoEquipe).ToListAsync();

            Licencie = await _context.Licencie.Include(i => i.CompoEquipe).ThenInclude(i => i.equipe).FirstOrDefaultAsync(m => m.ID == id);

            Licencie = await _context.Licencie.FirstOrDefaultAsync(m => m.ID == id);

            if (Licencie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
