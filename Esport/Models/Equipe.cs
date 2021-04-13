using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public class Equipe
    {
        public int ID { get; set; }
        public string Nom { get; set; }

        public int MancheG { get; set; }
        public int MancheP { get; set; }

        public int CompetitionG { get; set; }
        public int CompetitionP { get; set; }

        public bool Validate { get; set; }

        //Lien ManyToMany
        [Display(Name = "Licenciés dans cette équipe :")]
        public ICollection<CompoEquipe> CompoEquipe { get; set; }
    }
}
