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

namespace Esport.Pages.Shared.Equipes
{
    public class DetailsModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public DetailsModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Licencie> LesLicencies { get; set; }
        //public List<SelectListItem> SelectLesLicenciesData { get; private set; }


        public Equipe Equipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipe = await _context.Equipe.Include(i => i.CompoEquipe).ThenInclude(i => i.licencie).FirstOrDefaultAsync(m => m.ID == id);

            if (Equipe == null)
            {
                return NotFound();
            }
            return Page();

        }
    }
}
