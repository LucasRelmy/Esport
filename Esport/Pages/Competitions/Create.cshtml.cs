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

namespace Esport.Pages.Competitions
{
    public class CreateModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public CreateModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int competitionBuilderNum { get; set; }
        public CompetitionBuilder competitionbuilder { get; set; }

        public Competition Competition { get; set; }
        [BindProperty]
        public int nbEquipe { get; set; }
        public List<SelectListItem> SelectTypeCompetition { get; private set; }
        public List<Equipe> Equipes { get; private set; }
        public List<SelectListItem> ListeEquipe { get; private set; }



        public async Task<IActionResult> OnGetAsync()
        {
            SelectTypeCompetition = new List<SelectListItem>();
            SelectTypeCompetition.Add(new SelectListItem
            {
                Text = "Choisir un type de compétition",
                Value = "0"
            });
            SelectTypeCompetition.Add(new SelectListItem
            {
                Text = "Classique",
                Value = "1"
            });
            SelectTypeCompetition.Add(new SelectListItem
            {
                Text = "Round Robin",
                Value = "2"
            });
            ViewData["SelectTypeCompetition"] = new SelectList(SelectTypeCompetition, "Value", "Text");

            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        /*public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Competition.Add(Competition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/

        public async Task OnPostAsync()
        {
            await OnGetAsync();

            if (competitionBuilderNum != 0)
            {

                if(competitionBuilderNum == 1)
                {
                    competitionbuilder = new CompetitionClassiqueBuilder();
                }
                else
                {
                    competitionbuilder = new CompetitionRoundRobinBuilder();

                }

            }
            else
            {
                SelectTypeCompetition = new List<SelectListItem>();
                SelectTypeCompetition.Add(new SelectListItem
                {
                    Text = "Choisir un type de compétition",
                    Value = "0"
                });
                SelectTypeCompetition.Add(new SelectListItem
                {
                    Text = "Classique",
                    Value = "1"
                });
                SelectTypeCompetition.Add(new SelectListItem
                {
                    Text = "Round Robin",
                    Value = "2"
                });
                ViewData["SelectTypeCompetition"] = new SelectList(SelectTypeCompetition, "Value", "Text");

                return;
            }

            if (nbEquipe != 0)
            {
                Equipes = await _context.Equipe.Include(e => e.Nom).Include(e => e.ID).ToListAsync();

                ListeEquipe = new List<SelectListItem>();
                ListeEquipe.Add(new SelectListItem
                {
                    Text = "Choisir une Equipe",
                    Value = "0"
                });
                foreach (Equipe e in Equipes)
                {
                    ListeEquipe.Add(new SelectListItem
                    {
                        Text = e.Nom,
                        Value = e.ID.ToString()
                    });
                }
            }


        }
        
    }
}
