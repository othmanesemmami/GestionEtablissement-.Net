using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThinkPad.Models
{
    public class Etablissement
    {
        public Int32 EtablissementId { get; set; }
        public String Nom { get; set; }
        public String Location { get; set; }
        public IList<Etudiant> EtudiantListe { get; set; }
        public IList<Professeur> ProfesseurListe { get; set; }
    }
}