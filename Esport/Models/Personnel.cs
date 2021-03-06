using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esport.Models
{
    public class Personnel
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [Display(Name = "Nom du licencié")]
        public string NomComplet
        {
            get
            {
                return Nom + " " + Prenom;
            }
        }
    }
}
