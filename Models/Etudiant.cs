using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThinkPad.Models
{
    public class Etudiant
    {
        public Int32 EtudiantId { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Niveau { get; set; }
        public String Filiere { get; set; }
        public String Adress { get; set; }
        public Int32 EtablissementId { get; set; }

    }
}