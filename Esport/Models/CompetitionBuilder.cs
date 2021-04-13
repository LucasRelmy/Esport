using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public abstract class CompetitionBuilder
    {
        protected Competition competition;
        public Competition getCompetition()
        {
            return competition;
        }
        public void createNewCompetition(List<Equipe> pEquipesParticipantes, Jeu pJeu)
        {
            competition = new Competition(pEquipesParticipantes, pJeu);
        }
        public abstract void buildPhase();
    }
}
