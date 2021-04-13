using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public class Competition
    {
        public int ID { get; set; }
        private List<Equipe> EquipesParticipantes { get; set; }
        private List<Equipe> EquipesEnLice { get; set; }
        private Jeu Jeu { get; set; }
        public Phase Phase { get; set; }
        Competition() { }
        public Competition(List<Equipe> pEquipesParticipantes, Jeu pJeu)
        {
            EquipesParticipantes = pEquipesParticipantes;
            Jeu = pJeu;
        }
        public Jeu GetJeu()
        {
            return Jeu;
        }
        public void SetJeu(Jeu pJeu)
        {
            Jeu = pJeu;
        }
    }
}
