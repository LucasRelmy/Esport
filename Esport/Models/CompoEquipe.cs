using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public class CompoEquipe
    {
        //Clé primaire 
        public int ID { get; set; }
        //Lien de composition vers l'enseignant 
        public int LicencieID { get; set; }
        public Licencie licencie { get; set; }
        //Lien de composition vers l'UE 
        public int EquipeID { get; set; }
        public Equipe equipe { get; set; }
    }
}
