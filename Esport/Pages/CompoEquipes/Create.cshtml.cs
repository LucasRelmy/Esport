using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Esport.Data;
using Esport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Esport.Pages.Shared.CompoEquipes
{
    [Authorize(Roles = "personnel,organisateur,licencie")]
    public class CreateModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public CreateModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Licencie> LesLicencies { get; set; }
        public List<SelectListItem> SelectLesLicenciesData { get; private set; }
        public IList<Equipe> LesEquipes { get; set; }
        public List<SelectListItem> SelectLesEquipesData { get; private set; }


        /*public IActionResult OnGet()
        {
        //ViewData["EquipeID"] = new SelectList(_context.Equipe, "ID", "ID");
        // ViewData["LicencieID"] = new SelectList(_context.Licencie, "ID", "ID");
            return Page();
        }*/

        public async Task<IActionResult> OnGetAsync()
        {
            //combobox Licencié
            LesLicencies = await _context.Licencie.ToListAsync();

            SelectLesLicenciesData = new List<SelectListItem>();
            SelectLesLicenciesData.Add(new SelectListItem
            {
                Text = "Choisir un licencié",
                Value = "0"
            });
            foreach (Licencie e in LesLicencies)
            {
                SelectLesLicenciesData.Add(new SelectListItem
                {
                    Text = e.NomComplet,
                    Value = e.ID.ToString()
                });
            }

            // Remplissage de la vue
            ViewData["SelectLesLicenciesData"] = new SelectList(SelectLesLicenciesData, "Value", "Text");

            //combobox Licencié

            LesEquipes = await _context.Equipe.ToListAsync();

            SelectLesEquipesData = new List<SelectListItem>();
            SelectLesEquipesData.Add(new SelectListItem
            {
                Text = "Choisir une Equipe",
                Value = "0"
            });
            foreach (Equipe e in LesEquipes)
            {
                SelectLesEquipesData.Add(new SelectListItem
                {
                    Text = e.Nom,
                    Value = e.ID.ToString()
                });
            }

            // Remplissage de la vue
            ViewData["SelectLesEquipesData"] = new SelectList(SelectLesEquipesData, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public CompoEquipe CompoEquipe { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CompoEquipe.Add(CompoEquipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
