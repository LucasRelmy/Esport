using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public abstract class ResultatCompet : Phase
    {
        protected DateTime date;
        protected Equipe Equipe1;
        protected int manche1;

        protected Equipe Equipe2;
        protected int manche2;
        protected ResultatCompet()
        {
           
        }
        protected ResultatCompet(Equipe pEquipe1, Equipe pEquipe2)
        {
            Equipe1 = pEquipe1;
            Equipe2 = pEquipe2;
        }

        

        public abstract bool Add(ResultatCompet r);
        public abstract bool Remove(ResultatCompet r);

    }
}
