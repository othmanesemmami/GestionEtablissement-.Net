using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThinkPad.Models
{
    public class Professeur
    {
        public Int32 ProfesseurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
       
        public string Specialite { get; set; }
        public Int32 EtablissementId { get; set; } 
        public virtual Etablissement Etablissement { get; set; }
    }

}